using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;

namespace BodhiCRM.Web.sms
{
    public partial class sms_template_edit : Web.Aid.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.SMS_TEMPLATE().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sms_template", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.SMS_TEMPLATE bll = new BLL.SMS_TEMPLATE();
            Model.SMS_TEMPLATE model = bll.GetModel(_id);

            txtTitle.Text = model.TITLE;
            txtCallIndex.Text = model.CALL_INDEX;
            txtContent.Text = model.CONTENT;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.SMS_TEMPLATE model = new Model.SMS_TEMPLATE();
            BLL.SMS_TEMPLATE bll = new BLL.SMS_TEMPLATE();

            model.TITLE = txtTitle.Text.Trim();
            model.CALL_INDEX = txtCallIndex.Text.Trim();
            model.CONTENT = txtContent.Text;

            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加短信模板:" + model.TITLE); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.SMS_TEMPLATE bll = new BLL.SMS_TEMPLATE();
            Model.SMS_TEMPLATE model = bll.GetModel(_id);

            model.TITLE = txtTitle.Text.Trim();
            model.CALL_INDEX = txtCallIndex.Text.Trim();
            model.CONTENT = txtContent.Text;

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改短信模板:" + model.TITLE); //记录日志
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
                ChkAdminLevel("sms_template", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", string.Empty);
                    return;
                }
                JscriptMsg("修改短信模板成功！", "sms_template_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("sms_template", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", string.Empty);
                    return;
                }
                JscriptMsg("添加短信模板成功！", "sms_template_list.aspx");
            }
        }

    }
}