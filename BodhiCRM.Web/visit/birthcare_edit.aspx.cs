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
    public partial class birthcare_edit : Web.Aid.ManagePage
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
                if (!new BLL.BIRTHCARE().Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("birthcare_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.MANAGER model = GetAdminInfo(); //取得当前管理员信息
                deptBind(model.HOSPITAL_CODE, "0000");
                //Model.MANAGER model = GetAdminInfo(); //取得管理员信息
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }
            }
        }

        #region 绑定部门=================================
        private void deptBind(string hospital_code, string uplevel)
        {
            BLL.DEPARTMENT bll = new BLL.DEPARTMENT();
            DataTable dt = bll.GetList_DataTable(uplevel, hospital_code);

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
            BLL.BIRTHCARE bll = new BLL.BIRTHCARE();
            Model.BIRTHCARE model = bll.GetModel(id);

            ddlDepartId.SelectedValue = model.DEPT_ID.ToString();
            txtPNAME.Text = new BodhiCRM.BLL.PATIENT().GetModel(model.PATIENT_SN).CNAME;
            hidSn.Value = model.PATIENT_SN;
            txtGName.Text = model.GIFT_NAME;
            txtGDate.Text = model.GIFT_GETDT;
            txtGPayment.Text = model.GIFT_PAYMENT;
            txtGValue.Text = model.GIFT_VALUE;
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
            BLL.BIRTHCARE bll = new BLL.BIRTHCARE();
            Model.BIRTHCARE model = new Model.BIRTHCARE();

            model.HOSPITAL_CODE = adminModel.HOSPITAL_CODE;
            model.DEPT_ID = Int32.Parse(ddlDepartId.SelectedValue);
            model.PATIENT_SN = hidSn.Value.ToString();
            model.CREATE_USER_ID = adminModel.ID;
            model.GIFT_GETDT = txtGDate.Text.Trim();
            model.GIFT_NAME = txtGName.Text.Trim();
            model.GIFT_PAYMENT = txtGPayment.Text.Trim();
            model.GIFT_VALUE = txtGValue.Text.Trim();
            model.REMARK = txtRemark.Text.Trim();
            model.STATUS = "Y";

            if (bll.Add(model) == true)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), adminModel.REAL_NAME+"添加生日关怀信息:" + model.ID); //记录日志
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
            BLL.BIRTHCARE bll = new BLL.BIRTHCARE();
            Model.BIRTHCARE model = bll.GetModel(id);

            model.DEPT_ID = Int32.Parse(ddlDepartId.SelectedValue);
            model.PATIENT_SN = hidSn.Value.ToString();
            model.CREATE_USER_ID = adminModel.ID;
            model.GIFT_GETDT = txtGDate.Text.Trim();
            model.GIFT_NAME = txtGName.Text.Trim();
            model.GIFT_PAYMENT = txtGPayment.Text.Trim();
            model.GIFT_VALUE = txtGValue.Text.Trim();
            model.REMARK = txtRemark.Text.Trim();
            model.STATUS = "Y";
           
            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), adminModel.REAL_NAME + "修改生日关怀信息:" + model.ID); //记录日志
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
                ChkAdminLevel("birthcare_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改生日关怀信息成功！", "birthcare_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("birthcare_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加生日关怀信息成功！", "birthcare_list.aspx");
            }
        }
    }
}