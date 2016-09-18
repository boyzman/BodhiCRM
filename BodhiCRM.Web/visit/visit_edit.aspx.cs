using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;
using System.Data;

namespace BodhiCRM.Web.visit
{
    public partial class visit_edit : Web.Aid.ManagePage
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
                if (!new BLL.VISIT().Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("visit_calendar", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.MANAGER model = GetAdminInfo(); //取得当前管理员信息
                emplBind("ACTIVE='Y' and HOSPITAL_CODE='" + model.HOSPITAL_CODE + "'");
                //Model.MANAGER model = GetAdminInfo(); //取得管理员信息
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }
            }
        }

        #region 绑定部门=================================
        private void emplBind(string strWhere)
        {
            BLL.EMPLOYEE bll = new BLL.EMPLOYEE();
            DataTable dt = bll.GetList(strWhere).Tables[0];

            this.ddlEmplId.Items.Clear();
            this.ddlEmplId.Items.Add(new ListItem("请选择随访人员", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlEmplId.Items.Add(new ListItem(dr["REAL_NAME"].ToString(), dr["ID"].ToString()));
            }

        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            BLL.VISIT bll = new BLL.VISIT();
            Model.VISIT model = bll.GetModel(id);

            ddlEmplId.SelectedValue = model.EMPL_ID.ToString();
            txtPNAME.Text = new BodhiCRM.BLL.PATIENT().GetModel(model.PATIENT_SN).CNAME;
            hidSn.Value = model.PATIENT_SN;
            txtVisitTitle.Text = model.VISIT_TITLE;
            txtVisitSdt.Text = model.VISIT_STARTDT;
            txtVisitEdt.Text = model.VISIT_ENDDT;
            ddlVisitType.SelectedValue = model.VISIT_TYPE;
            ddlFreq.SelectedValue = model.VISIT_FREQUENCY;
            txtFeqNo.Text = model.VISIT_FREQUENCYNO.ToString();
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
            BLL.VISIT bll = new BLL.VISIT();
            Model.VISIT model = new Model.VISIT();

            model.HOSPITAL_CODE = adminModel.HOSPITAL_CODE;
            model.EMPL_ID = Int32.Parse(ddlEmplId.SelectedValue);
            model.PATIENT_SN = hidSn.Value.ToString();
            model.VISIT_STARTDT = txtVisitSdt.Text.Trim();
            model.VISIT_ENDDT = txtVisitEdt.Text.Trim();
            model.VISIT_FREQUENCY = ddlFreq.SelectedValue;

            model.VISIT_FREQUENCYNO = Utils.StrToInt(txtFeqNo.Text.Trim(),0);
            model.VISIT_STATUS = rbFreqStatus.SelectedValue;
            model.VISIT_TITLE = txtVisitTitle.Text.Trim();
            model.VISIT_TYPE = ddlVisitType.SelectedValue;
            model.ADD_TIME = DateTime.Now;
            model.CREATE_USER_ID = adminModel.ID;
            model.REMARK = txtRemark.Text;


            if (bll.Add(model) == true)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), adminModel.REAL_NAME + "添加随访信息:" + model.ID); //记录日志
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
            BLL.VISIT bll = new BLL.VISIT();
            Model.VISIT model = bll.GetModel(id);

            model.EMPL_ID = Int32.Parse(ddlEmplId.SelectedValue);
            model.PATIENT_SN = hidSn.Value.ToString();
            model.VISIT_STARTDT = txtVisitSdt.Text.Trim();
            model.VISIT_ENDDT = txtVisitEdt.Text.Trim();
            model.VISIT_FREQUENCY = ddlFreq.SelectedValue;
            model.VISIT_FREQUENCYNO = decimal.Parse(txtFeqNo.Text.Trim());
            model.VISIT_STATUS = rbFreqStatus.SelectedValue;
            model.VISIT_TITLE = txtVisitTitle.Text.Trim();
            model.VISIT_TYPE = ddlVisitType.SelectedValue;
            model.ADD_TIME = DateTime.Now;
            model.CREATE_USER_ID = adminModel.ID;
            model.REMARK = txtRemark.Text;

            if (bll.Update(model))
            {

                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), adminModel.REAL_NAME + "修改随访信息:" + model.ID); //记录日志
                result = true;
            }
            return result;

        }
        #endregion

        #region 删除操作=================================
        private void DoDelete(int id)
        {
            Model.MANAGER adminModel = GetAdminInfo(); //获得当前登录管理员信息
           
            int sucCount = 0;
            int errorCount = 0;
            BLL.VISIT bll = new BLL.VISIT();
            
            if (bll.Delete(id))
            {
                sucCount += 1;
            }
            else
            {
                errorCount += 1;
            }

            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), adminModel.REAL_NAME + "删除随访信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", "visit_calendar.aspx");

        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("visit_calendar", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改随访信息成功！", "visit_calendar.aspx");
            }
            else //添加
            {
                ChkAdminLevel("visit_calendar", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加随访信息成功！", "visit_calendar.aspx");
            }
        }

        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("visit_calendar", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            DoDelete(this.id);
        }
        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("visit_calendar", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            DoDelete(this.id);
        }
    }
}