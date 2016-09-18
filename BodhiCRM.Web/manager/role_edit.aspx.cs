using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;

namespace BodhiCRM.Web.manager
{
    public partial class role_edit : Web.Aid.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.id = DTRequest.GetQueryInt("id");

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.MANAGER_ROLE().Exists(this.id))
                {
                    JscriptMsg("角色不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("manager_role", DTEnums.ActionEnum.View.ToString()); //检查权限
                RoleTypeBind(); //绑定角色类型
                NavBind(); //绑定导航
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 角色类型=================================
        private void RoleTypeBind()
        {
            Model.MANAGER model = GetAdminInfo();
            ddlRoleType.Items.Clear();
            ddlRoleType.Items.Add(new ListItem("请选择类型...", ""));
            if (model.ROLE_TYPE < 2)
            {
                ddlRoleType.Items.Add(new ListItem("超级用户", "1"));
            }
            ddlRoleType.Items.Add(new ListItem("系统用户", "2"));
        }
        #endregion

        #region 导航菜单=================================
        private void NavBind()
        {
            BLL.NAVIGATION bll = new BLL.NAVIGATION();
            DataTable dt = bll.GetList(0, DTEnums.NavigationEnum.System.ToString());
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.MANAGER_ROLE bll = new BLL.MANAGER_ROLE();
            Model.MANAGER_ROLE model = bll.GetModel(_id);
            txtRoleName.Text = model.ROLE_NAME;
            ddlRoleType.SelectedValue = model.ROLE_TYPE.ToString();
            //管理权限
            if (model.manager_role_values != null)
            {
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
                    CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
                    for (int n = 0; n < cblActionType.Items.Count; n++)
                    {
                        Model.MANAGER_ROLE_VALUE modelt = model.manager_role_values.Find(p => p.NAV_NAME == navName && p.ACTION_TYPE == cblActionType.Items[n].Value);
                        if (modelt != null)
                        {
                            cblActionType.Items[n].Selected = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.MANAGER_ROLE model = new Model.MANAGER_ROLE();
            BLL.MANAGER_ROLE bll = new BLL.MANAGER_ROLE();

            model.ROLE_NAME = txtRoleName.Text.Trim();
            model.ROLE_TYPE = int.Parse(ddlRoleType.SelectedValue);
            model.HOSPITAL_CODE = Utils.GetCookie("AdminHospital", "BodhiCRM");
            //管理权限
            List<Model.MANAGER_ROLE_VALUE> ls = new List<Model.MANAGER_ROLE_VALUE>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
                CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
                for (int n = 0; n < cblActionType.Items.Count; n++)
                {
                    if (cblActionType.Items[n].Selected == true)
                    {
                        ls.Add(new Model.MANAGER_ROLE_VALUE { NAV_NAME = navName, ACTION_TYPE = cblActionType.Items[n].Value });
                    }
                }
            }
            model.manager_role_values = ls;

            if (bll.Add(model)>0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加管理角色:" + model.ROLE_NAME); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.MANAGER_ROLE bll = new BLL.MANAGER_ROLE();
            Model.MANAGER_ROLE model = bll.GetModel(_id);

            model.ROLE_NAME = txtRoleName.Text.Trim();
            model.ROLE_TYPE = int.Parse(ddlRoleType.SelectedValue);
           
            //管理权限
            List<Model.MANAGER_ROLE_VALUE> ls = new List<Model.MANAGER_ROLE_VALUE>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
                CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
                for (int n = 0; n < cblActionType.Items.Count; n++)
                {
                    if (cblActionType.Items[n].Selected == true)
                    {
                        ls.Add(new Model.MANAGER_ROLE_VALUE { ROLE_ID = _id, NAV_NAME = navName, ACTION_TYPE = cblActionType.Items[n].Value });
                    }
                }
            }
            model.manager_role_values = ls;

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改管理角色:" + model.ROLE_NAME); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //美化导航树结构
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
                string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
                string LitImg1 = "<span class=\"folder-open\"></span>";
                string LitImg2 = "<span class=\"folder-line\"></span>";

                int classLayer = Convert.ToInt32(hidLayer.Value);
                if (classLayer == 1)
                {
                    LitFirst.Text = LitImg1;
                }
                else
                {
                    LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
                }
                //绑定导航权限资源
                string[] actionTypeArr = ((HiddenField)e.Item.FindControl("hidActionType")).Value.Split(',');
                CheckBoxList cblActionType = (CheckBoxList)e.Item.FindControl("cblActionType");
                cblActionType.Items.Clear();
                for (int i = 0; i < actionTypeArr.Length; i++)
                {
                    if (Utils.ActionType().ContainsKey(actionTypeArr[i]))
                    {
                        cblActionType.Items.Add(new ListItem(" " + Utils.ActionType()[actionTypeArr[i]] + " ", actionTypeArr[i]));
                    }
                }
            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("manager_role", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改管理角色成功！", "role_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("manager_role", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加管理角色成功！", "role_list.aspx");
            }
        }

    }
}