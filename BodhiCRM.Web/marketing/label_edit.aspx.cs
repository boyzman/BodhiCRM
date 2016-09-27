using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;
using System.Data;

namespace BodhiCRM.Web.marketing
{
    public partial class label_edit : Web.Aid.ManagePage
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
                if (!new BLL.M_LABEL().Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("label_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.MANAGER model = GetAdminInfo(); //取得当前管理员信息
                
                //Model.MANAGER model = GetAdminInfo(); //取得管理员信息
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            BLL.M_LABEL bll = new BLL.M_LABEL();
            Model.M_LABEL model = bll.GetModel(id);
            txtLNAME.Text = model.LABEL_NAME;
            cbStatus.Checked = model.STATUS == "Y";
            txtRemark.Text = model.REMARK;
            ddlType.SelectedValue = model.LABEL_TYPE;
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
            BLL.M_LABEL bll = new BLL.M_LABEL();
            Model.M_LABEL model = new Model.M_LABEL();

            model.HOSPITAL_CODE = adminModel.HOSPITAL_CODE;
            model.LABEL_NAME = txtLNAME.Text;
            model.STATUS = cbStatus.Checked ? "Y" : "N";
            model.REMARK = txtRemark.Text;
            model.LABEL_TYPE = ddlType.SelectedValue;
            if (bll.Add(model) == true)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), adminModel.REAL_NAME+"添加标签信息:" + model.ID); //记录日志
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
            BLL.M_LABEL bll = new BLL.M_LABEL();
            Model.M_LABEL model = bll.GetModel(id);

            model.HOSPITAL_CODE = adminModel.HOSPITAL_CODE;
            model.LABEL_NAME = txtLNAME.Text;
            model.STATUS = cbStatus.Checked ? "Y" : "N";
            model.REMARK = txtRemark.Text;
            model.LABEL_TYPE = ddlType.SelectedValue;
            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), adminModel.REAL_NAME + "修改标签信息:" + model.ID); //记录日志
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
                ChkAdminLevel("label_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改标签信息成功！", "label_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("label_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加标签信息成功！", "label_list.aspx");
            }
        }
    }
}