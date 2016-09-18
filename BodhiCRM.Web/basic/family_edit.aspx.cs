using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;

namespace BodhiCRM.Web.basic
{
    public partial class family_edit : Web.Aid.ManagePage
    {
       
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id=0;
        protected string areaAll = "";//地区全局变量，便于前台调用
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
                if (!new BLL.FAMILY().Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("family_list", DTEnums.ActionEnum.View.ToString()); //检查权限
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
            BLL.FAMILY bll = new BLL.FAMILY();
            Model.FAMILY model = bll.GetModel(id);
            BLL.PATIENT bll_p = new BLL.PATIENT();
            Model.PATIENT model_p = bll_p.GetModel(model.PATIENT_SN);
            if (model.STATUS == "Y")
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            txtPNAME.Text = model_p.CNAME;
            hidSn.Value = model.PATIENT_SN;
            txtIdcard.Text = model.ID_CARD_CODE;
            ddlRelation.SelectedValue = model.PATIENT_RELATION;
            txtCNAME.Text = model.CNAME;
            if (model.GENDER_ID == 1)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            txtBIRTH_DATE.Text = model.BIRTH_DATE;
            if (!string.IsNullOrEmpty(model.BIRTH_DATE))
            {
                txtAge.Text = Utils.CalculateAgeCorrect(DateTime.Parse(model.BIRTH_DATE), DateTime.Now).ToString();
            }
            txtHeight.Text = model.HEIGHT.ToString();
            txtWeight.Text = model.WEIGHT.ToString();
            txtTel.Text = model.MOBILE_TEL;
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
            Model.FAMILY model = new Model.FAMILY();
            BLL.FAMILY bll = new BLL.FAMILY();
            model.PATIENT_SN = hidSn.Value.Trim();
            model.PATIENT_RELATION = ddlRelation.SelectedValue.Trim();
            model.CNAME = txtCNAME.Text.Trim();
            model.BIRTH_DATE = txtBIRTH_DATE.Text.Trim();
            model.CREATE_TIME = DateTime.Now;
            model.CREATE_USER_ID = adminModel.ID;
          
            if (cbGENDER_ID.Checked == true)
            {
                model.GENDER_ID = 1;
            }
            else
            {
                model.GENDER_ID = 0;
            }
            model.HEIGHT = decimal.Parse(txtHeight.Text.Trim());
            model.WEIGHT = decimal.Parse(txtWeight.Text.Trim());
           
            model.MOBILE_TEL = txtTel.Text.Trim();
            model.ID_CARD_CODE = txtIdcard.Text.Trim();
            model.REMARK = txtRemark.Text.Trim();
            if (cbIsLock.Checked == true)
            {
                model.STATUS = "Y";
            }
            else
            {
                model.STATUS = "N";
            }
            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加病患家属信息:" + model.ID); //记录日志
                return true;
            }
            return false;
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
            BLL.FAMILY bll = new BLL.FAMILY();
            Model.FAMILY model = bll.GetModel(id);

            model.PATIENT_SN = hidSn.Value.Trim();
            model.PATIENT_RELATION = ddlRelation.SelectedValue.Trim();
            model.CNAME = txtCNAME.Text.Trim();
           
            model.BIRTH_DATE = txtBIRTH_DATE.Text.Trim();
            model.MODIFIED_TIME = DateTime.Now;
            model.MODIFIED_USER = adminModel.ID;
            
            if (cbGENDER_ID.Checked == true)
            {
                model.GENDER_ID = 1;
            }
            else
            {
                model.GENDER_ID = 0;
            }
            model.HEIGHT = decimal.Parse(txtHeight.Text.Trim());
            model.WEIGHT = decimal.Parse(txtWeight.Text.Trim());
           
            model.MOBILE_TEL = txtTel.Text.Trim();
            model.ID_CARD_CODE = txtIdcard.Text.Trim();
            model.REMARK = txtRemark.Text.Trim();
            if (cbIsLock.Checked == true)
            {
                model.STATUS = "Y";
            }
            else
            {
                model.STATUS = "N";
            }
            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改病患家属信息:" + model.ID); //记录日志
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
                ChkAdminLevel("family_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改病患家属信息成功！", "family_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("family_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加病患家属信息成功！", "family_list.aspx");
            }
        }
    }
}