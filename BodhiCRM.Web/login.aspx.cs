using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using BodhiCRM.Common;
using System.Data;

namespace BodhiCRM.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUserName.Text = Utils.GetCookie("CRMRememberName");
                HospBind(ddlHospitalcode);
            }
        }
        #region 医院下拉框=================================
        private void HospBind(DropDownList ddl)
        {
            BLL.HOSPITAL bll = new BLL.HOSPITAL();
            DataTable dt = bll.GetList("ACTIVE='Y'").Tables[0];

            //ddl.Items.Clear();
            //ddl.Items.Add(new ListItem("请选择角色...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["HOSPITAL_NAME"].ToString(), dr["HOSPITAL_CODE"].ToString()));
            }
        }
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string userPwd = txtPassword.Text.Trim();
            string hosipital_code = ddlHospitalcode.SelectedItem.Value.ToString();
            if (userName.Equals("") || userPwd.Equals(""))
            {
                msgtip.InnerHtml = "请输入用户名或密码";
                return;
            }
            if (Session["AdminLoginSun"] == null)
            {
                Session["AdminLoginSun"] = 1;
            }
            else
            {
                Session["AdminLoginSun"] = Convert.ToInt32(Session["AdminLoginSun"]) + 1;
            }
            //判断登录错误次数
            if (Session["AdminLoginSun"] != null && Convert.ToInt32(Session["AdminLoginSun"]) > 5)
            {
                msgtip.InnerHtml = "错误超过5次，关闭浏览器重新登录！";
                return;
            }
            BLL.MANAGER bll = new BLL.MANAGER();
            Model.MANAGER model = bll.GetModel(userName, userPwd, hosipital_code,true);
            if (model == null)
            {
                msgtip.InnerHtml = "用户名或密码有误，请重试！";
                return;
            }
            Session[DTKeys.SESSION_ADMIN_INFO] = model;
            Session.Timeout = 45;
            //写入登录日志
            Model.SYS_CONFIG siteConfig = new BLL.SYS_CONFIG().loadConfig();
            if (siteConfig.logstatus > 0)
            {
                new BLL.MANAGER_LOG().Add(Convert.ToInt32(model.ID),model.HOSPITAL_CODE, model.USER_NAME, DTEnums.ActionEnum.Login.ToString(), "用户登录","","");
            }
            //写入Cookies
            Utils.WriteCookie("CRMRememberName", model.USER_NAME, 14400);
            Utils.WriteCookie("AdminName", "BodhiCRM", model.USER_NAME);
            Utils.WriteCookie("AdminPwd", "BodhiCRM", model.PASSWORD);
            Utils.WriteCookie("AdminHospital", "BodhiCRM", model.HOSPITAL_CODE);
            Response.Redirect("index.aspx");
            return;
        }

    }
}