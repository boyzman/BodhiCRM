using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;

namespace BodhiCRM.Web.settings
{
    public partial class nav_edit : Web.Aid.ManagePage
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
                if (!new BLL.NAVIGATION().Exists(this.id))
                {
                    JscriptMsg("导航不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_navigation", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(DTEnums.NavigationEnum.System.ToString()); //绑定导航菜单
                ActionTypeBind(); //绑定操作权限类型
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    if (this.id > 0)
                    {
                        this.ddlParentId.SelectedValue = this.id.ToString();
                    }
                    txtName.Attributes.Add("ajaxurl", "../tools/admin_ajax.ashx?action=navigation_validate");
                }
            }
        }

        #region 绑定导航菜单=============================
        private void TreeBind(string nav_type)
        {
            BLL.NAVIGATION bll = new BLL.NAVIGATION();
            DataTable dt = bll.GetList(0, nav_type);

            this.ddlParentId.Items.Clear();
            this.ddlParentId.Items.Add(new ListItem("无父级导航", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 绑定操作权限类型=========================
        private void ActionTypeBind()
        {
            cblActionType.Items.Clear();
            foreach (KeyValuePair<string, string> kvp in Utils.ActionType())
            {
                cblActionType.Items.Add(new ListItem(kvp.Value + "(" + kvp.Key + ")", kvp.Key));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.NAVIGATION bll = new BLL.NAVIGATION();
            Model.NAVIGATION model = bll.GetModel(_id);

            ddlParentId.SelectedValue = model.PARENT_ID.ToString();
            txtSortId.Text = model.SORT_ID.ToString();
            if (model.IS_LOCK == 1)
            {
                cbIsLock.Checked = true;
            }
            txtName.Text = model.NAME;
            txtName.Attributes.Add("ajaxurl", "../tools/admin_ajax.ashx?action=navigation_validate&old_name=" + Utils.UrlEncode(model.NAME));
            txtName.Focus(); //设置焦点，防止JS无法提交
            if (model.IS_SYS == 1)
            {
                ddlParentId.Enabled = false;
                txtName.ReadOnly = true;
            }
            txtTitle.Text = model.TITLE;
            txtSubTitle.Text = model.SUB_TITLE;
            txtIconUrl.Text = model.ICON_URL;
            txtLinkUrl.Text = model.LINK_URL;
            txtRemark.Text = model.REMARK;
            //赋值操作权限类型
            string[] actionTypeArr = model.ACTION_TYPE.Split(',');
            for (int i = 0; i < cblActionType.Items.Count; i++)
            {
                for (int n = 0; n < actionTypeArr.Length; n++)
                {
                    if (actionTypeArr[n].ToLower() == cblActionType.Items[i].Value.ToLower())
                    {
                        cblActionType.Items[i].Selected = true;
                    }
                }
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                Model.NAVIGATION model = new Model.NAVIGATION();
                BLL.NAVIGATION bll = new BLL.NAVIGATION();

                model.NAV_TYPE = DTEnums.NavigationEnum.System.ToString();
                model.NAME = txtName.Text.Trim();
                model.TITLE = txtTitle.Text.Trim();
                model.SUB_TITLE = txtSubTitle.Text.Trim();
                model.ICON_URL = txtIconUrl.Text.Trim();
                model.LINK_URL = txtLinkUrl.Text.Trim();
                model.SORT_ID = int.Parse(txtSortId.Text.Trim());
                model.IS_LOCK = 0;
                if (cbIsLock.Checked == true)
                {
                    model.IS_LOCK = 1;
                }
                model.REMARK = txtRemark.Text.Trim();
                model.PARENT_ID = int.Parse(ddlParentId.SelectedValue);

                //添加操作权限类型
                string action_type_str = string.Empty;
                for (int i = 0; i < cblActionType.Items.Count; i++)
                {
                    if (cblActionType.Items[i].Selected && Utils.ActionType().ContainsKey(cblActionType.Items[i].Value))
                    {
                        action_type_str += cblActionType.Items[i].Value + ",";
                    }
                }
                model.ACTION_TYPE = Utils.DelLastComma(action_type_str);

                if (bll.Add(model))
                {
                    AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加导航菜单:" + model.TITLE); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            try
            {
                BLL.NAVIGATION bll = new BLL.NAVIGATION();
                Model.NAVIGATION model = bll.GetModel(_id);

                model.NAME = txtName.Text.Trim();
                model.TITLE = txtTitle.Text.Trim();
                model.SUB_TITLE = txtSubTitle.Text.Trim();
                model.ICON_URL = txtIconUrl.Text.Trim();
                model.LINK_URL = txtLinkUrl.Text.Trim();
                model.SORT_ID = int.Parse(txtSortId.Text.Trim());
                model.IS_LOCK = 0;
                if (cbIsLock.Checked == true)
                {
                    model.IS_LOCK = 1;
                }
                model.REMARK = txtRemark.Text.Trim();
                if (model.IS_SYS == 0)
                {
                    int parentId = int.Parse(ddlParentId.SelectedValue);
                    //如果选择的父ID不是自己,则更改
                    if (parentId != model.ID)
                    {
                        model.PARENT_ID = parentId;
                    }
                }

                //添加操作权限类型
                string action_type_str = string.Empty;
                for (int i = 0; i < cblActionType.Items.Count; i++)
                {
                    if (cblActionType.Items[i].Selected && Utils.ActionType().ContainsKey(cblActionType.Items[i].Value))
                    {
                        action_type_str += cblActionType.Items[i].Value + ",";
                    }
                }
                model.ACTION_TYPE = Utils.DelLastComma(action_type_str);

                if (bll.Update(model))
                {
                    AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "修改导航菜单:" + model.TITLE); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("sys_navigation", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改导航菜单成功！", "nav_list.aspx", "parent.loadMenuTree");
            }
            else //添加
            {
                ChkAdminLevel("sys_navigation", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加导航菜单成功！", "nav_list.aspx", "parent.loadMenuTree");
            }
        }

    }
}