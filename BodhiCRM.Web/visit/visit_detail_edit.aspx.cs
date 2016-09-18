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
    public partial class visit_detail_edit : Web.Aid.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private int pid = 0;
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
                if (!new BLL.VISIT_DETAIL().Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Add.ToString())
            {
                if (!int.TryParse(Request.QueryString["pid"] as string, out this.pid))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("visit_list", DTEnums.ActionEnum.View.ToString()); //检查权限
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
            BLL.VISIT_DETAIL bll = new BLL.VISIT_DETAIL();
            Model.VISIT_DETAIL model = bll.GetModel(id);

            txtVisitdt.Text = model.VISIT_DT;
            txtVisitNextdt.Text = model.VISIT_NEXTDT;
            rbFreqStatus.SelectedValue = model.VISIT_DETAIL_STATUS;
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
            BLL.VISIT_DETAIL bll = new BLL.VISIT_DETAIL();
            Model.VISIT_DETAIL model = new Model.VISIT_DETAIL();

            model.VISIT_ID = this.pid;
            model.VISIT_DT = txtVisitdt.Text.Trim();
            model.VISIT_NEXTDT = txtVisitNextdt.Text.Trim();
            model.VISIT_DETAIL_STATUS = rbFreqStatus.SelectedValue.ToString();
            model.VISIT_USER_ID = adminModel.ID;
            model.REMARK = txtRemark.Text;

            if (bll.Add(model) == true)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), adminModel.REAL_NAME + "添加随访记录:" + model.REMARK); //记录日志
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
            BLL.VISIT_DETAIL bll = new BLL.VISIT_DETAIL();
            Model.VISIT_DETAIL model = bll.GetModel(id);

            //model.VISIT_ID = this.pid;
            model.VISIT_DT = txtVisitdt.Text.Trim();
            model.VISIT_NEXTDT = txtVisitNextdt.Text.Trim();
            model.VISIT_DETAIL_STATUS = rbFreqStatus.SelectedValue.ToString();
            model.VISIT_USER_ID = adminModel.ID;
            model.REMARK = txtRemark.Text;

            if (bll.Update(model))
            {

                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), adminModel.REAL_NAME + "添加随访记录:" + model.REMARK); //记录日志
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

            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), adminModel.REAL_NAME + "删除随访记录" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", "visit_calendar.aspx");

        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("visit_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改随访记录成功！", "visit_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("visit_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加随访记录成功！", "visit_list.aspx");
            }
        }

        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("visit_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            DoDelete(this.id);
        }
     
    }
}