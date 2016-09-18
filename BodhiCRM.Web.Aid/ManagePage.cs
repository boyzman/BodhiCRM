using BodhiCRM.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;


namespace BodhiCRM.Web.Aid
{
    public class ManagePage : System.Web.UI.Page
    {
        protected internal Model.SYS_CONFIG sysConfig;

        public ManagePage()
        {
            this.Load += new EventHandler(ManagePage_Load);
            sysConfig = new BLL.SYS_CONFIG().loadConfig();
        }

        private void ManagePage_Load(object sender, EventArgs e)
        {
            //判断管理员是否登录
            if (!IsAdminLogin())
            {
                Response.Write("<script>parent.location.href='" + sysConfig.webpath + sysConfig.webmanagepath + "/login.aspx'</script>");
                Response.End();
            }
        }

        #region 管理员============================================
        /// <summary>
        /// 判断管理员是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsAdminLogin()
        {
            //如果Session为Null
            if (Session[DTKeys.SESSION_ADMIN_INFO] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                string adminname = Utils.GetCookie("AdminName", "BodhiCRM");
                string adminpwd = Utils.GetCookie("AdminPwd", "BodhiCRM");
                string adminhospital = Utils.GetCookie("AdminHospital", "BodhiCRM");
                if (adminname != "" && adminpwd != "")
                {
                    BLL.MANAGER bll = new BLL.MANAGER();
                    Model.MANAGER model = bll.GetModel(adminname, adminpwd,adminhospital);
                    if (model != null)
                    {
                        Session[DTKeys.SESSION_ADMIN_INFO] = model;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 取得管理员信息
        /// </summary>
        public Model.MANAGER GetAdminInfo()
        {
            if (IsAdminLogin())
            {
                Model.MANAGER model = Session[DTKeys.SESSION_ADMIN_INFO] as Model.MANAGER;
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }

        /// <summary>
        /// 检查管理员权限
        /// </summary>
        /// <param name="nav_name">菜单名称</param>
        /// <param name="action_type">操作类型</param>
        public void ChkAdminLevel(string nav_name, string action_type)
        {
            Model.MANAGER model = GetAdminInfo();
            BLL.MANAGER_ROLE bll = new BLL.MANAGER_ROLE();
            bool result = bll.Exists(model.ROLE_ID, nav_name, action_type);

            if (!result)
            {
                string msgbox = "parent.jsdialog(\"错误提示\", \"您没有管理该页面的权限，请勿非法进入！\", \"back\")";
                Response.Write("<script type=\"text/javascript\">" + msgbox + "</script>");
                Response.End();
            }
        }

        /// <summary>
        /// 写入管理日志
        /// </summary>
        /// <param name="action_type"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public bool AddAdminLog(string action_type, string remark)
        {
            if (sysConfig.logstatus > 0)
            {
                Model.MANAGER model = GetAdminInfo();
                bool isNot = new BLL.MANAGER_LOG().Add(int.Parse(model.ID.ToString()), model.HOSPITAL_CODE,model.USER_NAME, action_type,remark,"","");

                return isNot;
            }
            return false;
        }

        #endregion

        #region JS提示============================================
        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        protected void JscriptMsg(string msgtitle, string url)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }
        /// <summary>
        /// 带回传函数的添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="callback">JS回调函数</param>
        protected void JscriptMsg(string msgtitle, string url, string callback)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", " + callback + ")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }
        #endregion

    }
}
