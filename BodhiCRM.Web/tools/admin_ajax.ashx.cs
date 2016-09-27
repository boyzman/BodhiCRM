using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
using BodhiCRM.Web.Aid;
using BodhiCRM.Common;

namespace BodhiCRM.Web.tools
{
    /// <summary>
    /// admin_ajax 的摘要说明
    /// </summary>
    public class admin_ajax : IHttpHandler, IRequiresSessionState
    {
        Model.SYS_CONFIG siteConfig = new BLL.SYS_CONFIG().loadConfig(); //系统配置信息

        public void ProcessRequest(HttpContext context)
        {
            //检查管理员是否登录
            if (!new ManagePage().IsAdminLogin())
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"尚未登录或已超时，请登录后操作！\"}");
                return;
            }
            //取得处事类型
            string action = DTRequest.GetQueryString("action");
            switch (action)
            {
   
                case "navigation_validate": //验证导航菜单别名是否重复
                    navigation_validate(context);
                    break;
                case "manager_validate": //验证管理员用户名是否重复
                    manager_validate(context);
                    break;
                case "patient_validate": //验证病患病历号是否重复
                    patient_validate(context);
                    break;
                case "patient_mobile_validate": //验证病患手机号是否重复
                    patient_mobile_validate(context);
                    break;
                case "idcard_validate": //验证病患身份证号是否重复
                    idcard_validate(context);
                    break;
             
                case "get_navigation_list": //获取后台导航字符串
                    get_navigation_list(context);
                    break;
                case "get_sms_template": //获取短信模板
                    get_sms_template(context);
                    break;
                case "sms_message_post": //发送手机短信
                    sms_message_post(context);
                    break;
                //case "get_remote_fileinfo": //获取远程文件的信息
                //    get_remote_fileinfo(context);
                //    break;
               
            }
        }


        #region 验证导航菜单别名是否重复========================
        private void navigation_validate(HttpContext context)
        {
            string navname = DTRequest.GetString("param");
            string old_name = DTRequest.GetString("old_name");
            if (string.IsNullOrEmpty(navname))
            {
                context.Response.Write("{ \"info\":\"该导航别名不可为空！\", \"status\":\"n\" }");
                return;
            }
            if (navname.ToLower() == old_name.ToLower())
            {
                context.Response.Write("{ \"info\":\"该导航别名可使用\", \"status\":\"y\" }");
                return;
            }
            //检查保留的名称开头
            if (navname.ToLower().StartsWith("channel_"))
            {
                context.Response.Write("{ \"info\":\"该导航别名系统保留，请更换！\", \"status\":\"n\" }");
                return;
            }
            BLL.NAVIGATION bll = new BLL.NAVIGATION();
            if (bll.Exists(navname))
            {
                context.Response.Write("{ \"info\":\"该导航别名已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"该导航别名可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 验证管理员用户名是否重复========================
        private void manager_validate(HttpContext context)
        {
            string user_name = DTRequest.GetString("param");
            if (string.IsNullOrEmpty(user_name))
            {
                context.Response.Write("{ \"info\":\"请输入用户名\", \"status\":\"n\" }");
                return;
            }
            BLL.MANAGER bll = new BLL.MANAGER();
            if (bll.Exists(user_name))
            {
                context.Response.Write("{ \"info\":\"用户名已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"用户名可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 验证病患病历号是否重复========================
        private void patient_validate(HttpContext context)
        {
            string patient_sn = DTRequest.GetString("param");
            if (string.IsNullOrEmpty(patient_sn))
            {
                context.Response.Write("{ \"info\":\"请输入病历号\", \"status\":\"n\" }");
                return;
            }
            BLL.PATIENT bll = new BLL.PATIENT();
            if (bll.Exists(patient_sn))
            {
                context.Response.Write("{ \"info\":\"病历号已经存在，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"病历号可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 验证病患手机号是否重复========================
        private void patient_mobile_validate(HttpContext context)
        {
            string mobile = DTRequest.GetString("param");
            if (string.IsNullOrEmpty(mobile))
            {
                context.Response.Write("{ \"info\":\"请输入手机号号\", \"status\":\"n\" }");
                return;
            }
            BLL.PATIENT bll = new BLL.PATIENT();
            if (bll.Exists_Mobile(mobile))
            {
                context.Response.Write("{ \"info\":\"手机号已经存在，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"手机号可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 验证病患身份证号是否重复========================
        private void idcard_validate(HttpContext context)
        {
            string idcardno = DTRequest.GetString("param");
            if (string.IsNullOrEmpty(idcardno))
            {
                context.Response.Write("{ \"info\":\"请输入身份证号\", \"status\":\"n\" }");
                return;
            }
            BLL.PATIENT bll = new BLL.PATIENT();
            if (bll.Exists_idcard(idcardno))
            {
                context.Response.Write("{ \"info\":\"身份证号已经存在，请确认！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"身份证号可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 获取后台导航字符串==============================
        private void get_navigation_list(HttpContext context)
        {
            Model.MANAGER adminModel = new ManagePage().GetAdminInfo(); //获得当前登录管理员信息
            if (adminModel == null)
            {
                return;
            }
            Model.MANAGER_ROLE roleModel = new BLL.MANAGER_ROLE().GetModel(adminModel.ROLE_ID); //获得管理角色信息
            if (roleModel == null)
            {
                return;
            }
            DataTable dt = new BLL.NAVIGATION().GetList(0, DTEnums.NavigationEnum.System.ToString());
            this.get_navigation_childs(context, dt, 0, Convert.ToInt32(roleModel.ROLE_TYPE), roleModel.manager_role_values);

        }
        private void get_navigation_childs(HttpContext context, DataTable oldData, int parent_id, int role_type, List<Model.MANAGER_ROLE_VALUE> ls)
        {
            DataRow[] dr = oldData.Select("PARENT_ID=" + parent_id);
            bool isWrite = false; //是否输出开始标签
            for (int i = 0; i < dr.Length; i++)
            {
                //检查是否显示在界面上====================
                bool isActionPass = true;
                if (int.Parse(dr[i]["IS_LOCK"].ToString()) == 1)
                {
                    isActionPass = false;
                }
                //检查管理员权限==========================
                if (isActionPass && role_type > 1)
                {
                    string[] actionTypeArr = dr[i]["action_type"].ToString().Split(',');
                    foreach (string action_type_str in actionTypeArr)
                    {
                        //如果存在显示权限资源，则检查是否拥有该权限
                        if (action_type_str == "Show")
                        {
                            Model.MANAGER_ROLE_VALUE modelt = ls.Find(p => p.NAV_NAME == dr[i]["name"].ToString() && p.ACTION_TYPE == "Show");
                            if (modelt == null)
                            {
                                isActionPass = false;
                            }
                        }
                    }
                }
                //如果没有该权限则不显示
                if (!isActionPass)
                {
                    if (isWrite && i == (dr.Length - 1) && parent_id > 0)
                    {
                        context.Response.Write("</ul>\n");
                    }
                    continue;
                }
                //如果是顶级导航
                if (parent_id == 0)
                {
                    context.Response.Write("<div class=\"list-group\">\n");
                    context.Response.Write("<h1 title=\"" + dr[i]["sub_title"].ToString() + "\">");
                    if (!string.IsNullOrEmpty(dr[i]["icon_url"].ToString().Trim()))
                    {
                        context.Response.Write("<img src=\"" + dr[i]["icon_url"].ToString() + "\" />");
                    }
                    context.Response.Write("</h1>\n");
                    context.Response.Write("<div class=\"list-wrap\">\n");
                    context.Response.Write("<h2>" + dr[i]["title"].ToString() + "<i></i></h2>\n");
                    //调用自身迭代
                    this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), role_type, ls);
                    context.Response.Write("</div>\n");
                    context.Response.Write("</div>\n");
                }
                else //下级导航
                {
                    if (!isWrite)
                    {
                        isWrite = true;
                        context.Response.Write("<ul>\n");
                    }
                    context.Response.Write("<li>\n");
                    context.Response.Write("<a  title=\"" + dr[i]["title"].ToString() + "\" navid=\"" + dr[i]["name"].ToString() + "\"");
                    if (!string.IsNullOrEmpty(dr[i]["link_url"].ToString()))
                    {
                        if (int.Parse(dr[i]["channel_id"].ToString()) > 0)
                        {
                            context.Response.Write(" href=\"" + dr[i]["link_url"].ToString() + "?channel_id=" + dr[i]["channel_id"].ToString() + "\" target=\"mainframe\"");
                        }
                        else
                        {
                            context.Response.Write(" href=\"" + dr[i]["link_url"].ToString() + "\" target=\"mainframe\"");
                        }
                    }
                    if (!string.IsNullOrEmpty(dr[i]["icon_url"].ToString()))
                    {
                        context.Response.Write(" icon=\"" + dr[i]["icon_url"].ToString() + "\"");
                    }
                    context.Response.Write(" target=\"mainframe\">\n");
                    context.Response.Write("<span>" + dr[i]["title"].ToString() + "</span>\n");
                    context.Response.Write("</a>\n");
                    //调用自身迭代
                    this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), role_type, ls);
                    context.Response.Write("</li>\n");

                    if (i == (dr.Length - 1))
                    {
                        context.Response.Write("</ul>\n");
                    }
                }
            }
        }
        #endregion

        #region 获取短信模板========================
        private void get_sms_template(HttpContext context)
        {
            string tempid = DTRequest.GetString("tempid");
            if (string.IsNullOrEmpty(tempid))
            {
                context.Response.Write("{ \"info\":\"请选择模板\", \"status\":\"n\" }");
                return;
            }
            BLL.SMS_TEMPLATE bll = new BLL.SMS_TEMPLATE();
            Model.SMS_TEMPLATE model=bll.GetModelByCode(tempid);
           
            context.Response.Write(model.CONTENT);
            return;
        }
        #endregion

        #region 发送手机短信====================================
        private void sms_message_post(HttpContext context)
        {
            string mobiles = DTRequest.GetFormString("mobiles");
            string content = DTRequest.GetFormString("content");
            if (mobiles == "")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"手机号码不能为空！\"}");
                return;
            }
            if (content == "")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"短信内容不能为空！\"}");
                return;
            }
            //开始发送
            string msg = string.Empty;
            bool result = new BLL.SMS_MESSAGE().Send(mobiles,"", content,null,"" , out msg);
            if (result)
            {
                context.Response.Write("{\"status\": 1, \"msg\": \"" + msg + "\"}");
                return;
            }
            context.Response.Write("{\"status\": 0, \"msg\": \"" + msg + "\"}");
            return;
        }
        #endregion

        #region 获取远程文件的信息==============================
        private void get_remote_fileinfo(HttpContext context)
        {
            string filePath = DTRequest.GetFormString("remotepath");
            if (string.IsNullOrEmpty(filePath))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"没有找到远程附件地址！\"}");
                return;
            }
            if (!filePath.ToLower().StartsWith("http://"))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"不是远程附件地址！\"}");
                return;
            }
            try
            {
                HttpWebRequest _request = (HttpWebRequest)WebRequest.Create(filePath);
                HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
                int fileSize = (int)_response.ContentLength;
                string fileName = filePath.Substring(filePath.LastIndexOf("/") + 1);
                string fileExt = filePath.Substring(filePath.LastIndexOf(".") + 1).ToUpper();
                context.Response.Write("{\"status\": 1, \"msg\": \"获取远程文件成功！\", \"name\": \"" + fileName + "\", \"path\": \"" + filePath + "\", \"size\": " + fileSize + ", \"ext\": \"" + fileExt + "\"}");
            }
            catch
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"远程文件不存在！\"}");
                return;
            }
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}