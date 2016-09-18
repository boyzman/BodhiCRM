using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;

namespace BodhiCRM.Web.basic
{
    public partial class patient_edit : Web.Aid.ManagePage
    {
       
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private string sn = "";
        protected string areaAll = "";//地区全局变量，便于前台调用
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            sn = DTRequest.GetQueryString("sn");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (string.IsNullOrEmpty(sn))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.PATIENT().Exists(sn))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("patient_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                //Model.MANAGER model = GetAdminInfo(); //取得管理员信息
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(sn);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(string sn)
        {
            BLL.PATIENT bll = new BLL.PATIENT();
            Model.PATIENT model = bll.GetModel(sn);
            txtProvince.Value = model.HOME_PROVINCE_ID.ToString();
            txtCity.Value = model.HOME_CITY_ID.ToString();
            txtArea.Value = model.HOME_SECTION_ID.ToString();
            if (model.STATUS == "Y")
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            txtSN.Text = model.PATIENT_SN;
            txtSN.ReadOnly = true;
            txtSN.Attributes.Remove("ajaxurl");
            txtIdcard.Text = model.ID_CARD_CODE;
            txtIdcard.ReadOnly = true;
            txtIdcard.Attributes.Remove("ajaxurl");
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
            txtAddress.Text = model.ADDRESS;
            txtTel.Text = model.MOBILE_TEL;
            txtEMAIL.Text = model.E_MAIL;
            areaAll = model.HOME_PROVINCE_ID + "," + model.HOME_CITY_ID + "," + model.HOME_SECTION_ID;
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
            Model.PATIENT model = new Model.PATIENT();
            BLL.PATIENT bll = new BLL.PATIENT();
            model.PATIENT_SN = txtSN.Text.Trim();
            model.CNAME = txtCNAME.Text.Trim();
            model.ENAME=
            model.ADDRESS = txtAddress.Text.Trim();
            model.BIRTH_DATE = txtBIRTH_DATE.Text.Trim();
            model.CREATE_TIME = DateTime.Now;
            model.CREATE_USER_ID = adminModel.ID;
            model.E_MAIL = txtEMAIL.Text.Trim();
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
            model.HOME_CITY_ID  = Request["txtCity"];
            model.HOME_PROVINCE_ID = Request["txtProvince"];
            model.HOME_SECTION_ID = Request["txtArea"];
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
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加病患信息:" + model.PATIENT_SN); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(string sn)
        {
            bool result = false;
            Model.MANAGER adminModel = GetAdminInfo(); //获得当前登录管理员信息
            if (adminModel == null)
            {
                return false;
            }
            BLL.PATIENT bll = new BLL.PATIENT();
            Model.PATIENT model = bll.GetModel(sn);

            model.PATIENT_SN = txtSN.Text.Trim();
            model.CNAME = txtCNAME.Text.Trim();
            model.ADDRESS = txtAddress.Text.Trim();
            model.BIRTH_DATE = txtBIRTH_DATE.Text.Trim();
            model.MODIFIED_TIME = DateTime.Now;
            model.MODIFIED_USER = adminModel.ID;
            model.E_MAIL = txtEMAIL.Text.Trim();
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
            model.HOME_CITY_ID = Request["txtCity"];
            model.HOME_PROVINCE_ID = Request["txtProvince"];
            model.HOME_SECTION_ID = Request["txtArea"];
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
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改病患信息:" + model.PATIENT_SN); //记录日志
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
                ChkAdminLevel("patient_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.sn))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改病患信息成功！", "patient_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("patient_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加病患信息成功！", "patient_list.aspx");
            }
        }
    }
}