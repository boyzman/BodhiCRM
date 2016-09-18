using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;
using System.Data;

namespace BodhiCRM.Web.basic
{
    public partial class employee_edit : Web.Aid.ManagePage
    {
       
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.EMPLOYEE().Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("patient_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.MANAGER model = GetAdminInfo(); //取得当前管理员信息
                deptBind(model.HOSPITAL_CODE,"0000");
                //Model.MANAGER model = GetAdminInfo(); //取得管理员信息
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }
            }
        }

        #region 绑定部门=================================
        private void deptBind(string hospital_code,string uplevel)
        {
            BLL.DEPARTMENT bll = new BLL.DEPARTMENT();
            DataTable dt = bll.GetList_DataTable(uplevel,hospital_code);

            //this.ddlDepartId.Items.Clear();
            //this.ddlDepartId.Items.Add(new ListItem("无上级部门", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["CLASS_LAYER"].ToString());
                string Title = dr["DEPT_NAME"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlDepartId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlDepartId.Items.Add(new ListItem(Title, Id));
                }
            }

        }
        #endregion
        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            BLL.EMPLOYEE bll = new BLL.EMPLOYEE();
            Model.EMPLOYEE model = bll.GetModel(id);
            txtEmplName.Text = model.REAL_NAME;
            ddlDepartId.SelectedValue = model.DEPT_ID.ToString();
            rblStatus.SelectedValue = model.ACTIVE.ToString();
           
            rblPrepay.SelectedValue = model.GENDER_ID.ToString();
            txtTel.Text = model.TELEPHONE;
            txtEmail.Text = model.EMAIL;
            rblStatus.SelectedValue = model.STATUS;
            ddlPost.SelectedValue = model.POST_NAME;
            rblActive.SelectedValue = model.ACTIVE;
            txtHireddt.Text = model.IN_TIME;
            if (model.LEFT_TIME != null)
            {
                txtLeavedt.Text = model.LEFT_TIME;
            }

            txtRemark.Text = model.REMARK;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.MANAGER adminModel = GetAdminInfo(); //获得当前登录管理员信息
            if (adminModel == null)
            {
                return false;
            }
            bool result = false;
            BLL.EMPLOYEE bll = new BLL.EMPLOYEE();
            Model.EMPLOYEE model = new Model.EMPLOYEE();

            model.HOSPITAL_CODE = adminModel.HOSPITAL_CODE;
            model.DEPT_ID = Int32.Parse(ddlDepartId.SelectedValue);
            model.POST_NAME = ddlPost.SelectedValue;
            model.STATUS = rblStatus.SelectedValue;
            model.REAL_NAME = txtEmplName.Text.Trim();
            model.GENDER_ID = Int32.Parse(rblPrepay.SelectedValue);
            model.EMAIL = txtEmail.Text.Trim();
            model.TELEPHONE = txtTel.Text.Trim();
            model.ADD_TIME = DateTime.Now;
            model.STATUS = rblStatus.SelectedValue;
            model.ACTIVE = rblActive.SelectedValue;
            
            model.IN_TIME = this.txtHireddt.Text;
           
            model.LEFT_TIME =this.txtLeavedt.Text;
        
            model.REMARK = txtRemark.Text.Trim();

            if (bll.Add(model) == true)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加员工:" + model.REAL_NAME); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int id)
        {
            bool result = false;
            Model.MANAGER adminModel = GetAdminInfo(); //获得当前登录管理员信息
            if (adminModel == null)
            {
                return false;
            }
            BLL.EMPLOYEE bll = new BLL.EMPLOYEE();
            Model.EMPLOYEE model = bll.GetModel(id);

            //model.HOSPITAL_CODE = adminModel.HOSPITAL_CODE;
            model.DEPT_ID = Int32.Parse(ddlDepartId.SelectedValue);
            model.POST_NAME = ddlPost.SelectedValue;
            model.STATUS = rblStatus.SelectedValue;
            model.REAL_NAME = txtEmplName.Text.Trim();
            model.GENDER_ID = Int32.Parse(rblPrepay.SelectedValue);
            model.EMAIL = txtEmail.Text.Trim();
            model.TELEPHONE =txtTel.Text.Trim();
            model.STATUS = rblStatus.SelectedValue;
            model.ACTIVE = rblActive.SelectedValue;
            
            model.IN_TIME = this.txtHireddt.Text;
          
            model.LEFT_TIME = this.txtLeavedt.Text;
            model.REMARK = txtRemark.Text.Trim();
            if (bll.Update(model))
            {

                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改员工信息:" + model.REAL_NAME); //记录日志
                result = true;
            }
            return result;
            
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("employee_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改员工信息成功！", "employee_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("employee_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加员工信息成功！", "employee_list.aspx");
            }
        }
    }
}