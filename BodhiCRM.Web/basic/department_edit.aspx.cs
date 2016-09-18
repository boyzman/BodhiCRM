using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;

namespace BodhiCRM.Web.basic
{
    public partial class department_edit : Web.Aid.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private string level;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            this.id = DTRequest.GetQueryInt("id");
            this.level = DTRequest.GetQueryString("level");
            Model.MANAGER model = new Model.MANAGER();
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.DEPARTMENT().ExistsLevel(this.level))
                {
                    JscriptMsg("部门不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("department_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                model = GetAdminInfo();
                TreeBind(model.HOSPITAL_CODE); //绑定导航菜单
              
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    if (this.level != "0000")
                    {
                        this.ddlParentId.SelectedValue = this.level.ToString();
                    }
                    //txtName.Attributes.Add("ajaxurl", "../tools/admin_ajax.ashx?action=department_validate");
                }
            }
        }

        #region 绑定导航菜单=============================
        private void TreeBind(string hospital_code)
        {
            BLL.DEPARTMENT bll = new BLL.DEPARTMENT();
            DataTable dt = bll.GetList_DataTable("0000",hospital_code);
            this.ddlParentId.Items.Clear();
            this.ddlParentId.Items.Add(new ListItem("无父级导航", "0000"));
            foreach (DataRow dr in dt.Rows)
            {
                string level = dr["DEPT_LEVEL"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["DEPT_NAME"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlParentId.Items.Add(new ListItem(Title, level));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlParentId.Items.Add(new ListItem(Title, level));
                }
            }
        }
        #endregion

        

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.DEPARTMENT bll = new BLL.DEPARTMENT();
            Model.DEPARTMENT model = bll.GetModel(_id);

            ddlParentId.SelectedValue = model.DEPT_UPLEVEL.ToString();
           
            if (model.ACTIVE == "Y")
            {
                cbActive.Checked = true;
            }
            txtName.Text = model.DEPT_NAME;
          
            if (model.IS_SYS == "Y")
            {
                ddlParentId.Enabled = false;
                txtName.ReadOnly = true;
            }
           
            txtRemark.Text = model.DEPT_REMARK;
         
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                Model.DEPARTMENT model = new Model.DEPARTMENT();
                BLL.DEPARTMENT bll = new BLL.DEPARTMENT();

                model.DEPT_NAME = txtName.Text.Trim();
                model.DEPT_LEVEL = bll.GetMaxLevel("");
                model.DEPT_UPLEVEL = ddlParentId.SelectedValue;
                model.HOSPITAL_CODE = Utils.GetCookie("AdminHospital", "BodhiCRM");
                model.ADD_TIME = DateTime.Now;
               
                model.ACTIVE = "N";
                if (cbActive.Checked == true)
                {
                    model.ACTIVE = "Y";
                }
                model.IS_SYS = "N";
                model.DEPT_REMARK = txtRemark.Text.Trim();
               

                if (bll.Add(model))
                {
                    AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加部门信息:" + model.DEPT_NAME); //记录日志
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
                BLL.DEPARTMENT bll = new BLL.DEPARTMENT();
                Model.DEPARTMENT model = bll.GetModel(_id);

                model.DEPT_NAME = txtName.Text.Trim();
                //model.DEPT_LEVEL = bll.GetMaxLevel("");
                model.DEPT_UPLEVEL = ddlParentId.SelectedValue;
                
                model.ADD_TIME = DateTime.Now;

                model.ACTIVE = "N";
                if (cbActive.Checked == true)
                {
                    model.ACTIVE = "Y";
                }
                model.IS_SYS = "N";
                model.DEPT_REMARK = txtRemark.Text.Trim();
               

                if (bll.Update(model))
                {
                    AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "修改部门信息:" + model.DEPT_NAME); //记录日志
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
                ChkAdminLevel("department_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改部门信息成功！", "department_list.aspx", "parent.loadMenuTree");
            }
            else //添加
            {
                ChkAdminLevel("department_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加部门信息成功！", "department_list.aspx", "parent.loadMenuTree");
            }
        }

    }
}