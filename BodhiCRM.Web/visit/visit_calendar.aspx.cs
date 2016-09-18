using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;
using System.Data;
using BodhiCRM.BLL;
using System.Text;

namespace BodhiCRM.Web.visit
{
    public partial class visit_calendar : Web.Aid.ManagePage
    {
        protected string keywords = string.Empty;//关键字
        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("visit_calendar", DTEnums.ActionEnum.View.ToString()); //检查权限
            this.keywords = DTRequest.GetQueryString("keywords");
            if (!Page.IsPostBack)
            {
                Model.MANAGER model = GetAdminInfo(); //取得当前管理员信息
            }
        }

        #region 数据绑定=================================
        public string CalenBind(string sWhere)
        {
            string json = "";
            Model.MANAGER model = GetAdminInfo(); //取得当前管理员信息
            BLL.VISIT bll = new BLL.VISIT();
            if (!string.IsNullOrEmpty(sWhere))
            {
                sWhere = " STATUS='Y' and HOSPITAL_CODE='" + model.HOSPITAL_CODE + "' and (PATIENT_SN like '%" + sWhere + "%' or VISIT_STATUS like '%" + sWhere + "%')";
            }
            DataSet ds=bll.GetList(sWhere);
            DataTable dt = ds.Tables[0];
            foreach(DataRow dr in dt.Rows)
            {
                json += "{  id: '" + dr["ID"].ToString() + "',title: '" + dr["VISIT_TITLE"].ToString() + "',url:'visit_edit.aspx?action=" + DTEnums.ActionEnum.Edit + "&id=" + dr["ID"].ToString() + "',start: new Date(" + setstr(DateTime.Parse((dr["VISIT_STARTDT"].ToString()))) + "),end: new Date(" + setstr(DateTime.Parse((dr["VISIT_ENDDT"].ToString()))) + "),className: 'label-important'},";
            }
            return json;
        }
        /// <summary>
        /// 设置前台页面数据绑定事json时期格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string setstr(DateTime dt)
        {
            return dt.Year.ToString() + "," + (dt.Month - 1).ToString() + "," + dt.Day.ToString() + "," + dt.Hour.ToString() + "," + dt.Minute.ToString();
        }
        #endregion

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("visit_calendar.aspx", "keywords={0}",
                txtKeywords.Text.Trim() == "患者病历号、随访进度" ? "" : txtKeywords.Text.Trim()));
        }
    }
}