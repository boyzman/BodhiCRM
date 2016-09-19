using BodhiCRM.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BodhiCRM.Web.sms
{
    public partial class sms_send : Web.Aid.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sms_send", DTEnums.ActionEnum.Add.ToString()); //检查权限
                Model.MANAGER model = GetAdminInfo(); //取得管理员信息
                tempBind(ddlsmsTemplate);
                
            }
        }
        #region 角色类型=================================
        private void tempBind(DropDownList ddl)
        {
            BLL.SMS_TEMPLATE bll = new BLL.SMS_TEMPLATE();
            DataTable dt = bll.GetList(" STATUS='Y' ").Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择模板...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["TITLE"].ToString(), dr["CALL_INDEX"].ToString()));
            }
        }
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //BodhiCRM.Web.SMSService.TemplateSMSServiceClient smsClient = new SMSService.TemplateSMSServiceClient();
            BLL.SMS_MESSAGE bll = new BLL.SMS_MESSAGE();
            string sMobile = Request.Form["hdMobile"].ToString();
            
            //string sMobile=hidMobile.Value;
            string sName=hidName.Value;
            if (string.IsNullOrEmpty(sMobile))
            {
                JscriptMsg("没有接收方！", "back");
                return;
            }
            string[] toDate = new string[] { "菩提医疗", "" };
            List<System.String> listS = new List<System.String>(toDate);
            string outMsg = string.Empty;
            bool result = bll.Send(sMobile, sName, txtContent.Text, listS, "TestSMS", out outMsg);
            JscriptMsg(outMsg, "back");
            //string[] arrMobile = sMobile.Split(',');
            //string[] arrName = sName.Split(',');
            //int i = 0;
            //int success = 0;
            //int fail = 0;
            //foreach (string s in arrMobile)
            //{
            //    if(!string.IsNullOrEmpty(s))
            //    {
            //        String key = "TestSMS";
            //        String toTel = s;
            //        String[] toDate = new String[] { arrName[i], "菩提医疗", "" };
            //        String outMsg = String.Empty;
            //        bool state = smsClient.SendTemplateSMSS(key, toTel, toDate, out outMsg);
            //        if (state)
            //        {
            //            success++;
            //            JscriptMsg("发送信息成功"+success+"条", "back");
                        
            //        }
            //        else
            //        {
            //            fail++;
            //            JscriptMsg("发送信息失败" + fail + "条", "back");
            //        }
                   
            //    }
            //    i++;
            //}
            
        }
    }
}