using BodhiCRM.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BodhiCRM.Web.visit
{
    public partial class visit_analysis : Web.Aid.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("visit_analysis", DTEnums.ActionEnum.View.ToString()); //检查权限
            if (!Page.IsPostBack)
            {
                chatsBind();
            }
        }
        #region 数据绑定=================================
        public string chatsBind()
        {
            string json = "";
            Model.MANAGER model = GetAdminInfo(); //取得当前管理员信息
            BLL.VISIT bll = new BLL.VISIT();
            //if (!string.IsNullOrEmpty(sWhere))
            //{
            //    sWhere = " STATUS='Y' and HOSPITAL_CODE='" + model.HOSPITAL_CODE + "' and (PATIENT_SN like '%" + sWhere + "%' or VISIT_STATUS like '%" + sWhere + "%')";
            //}
            DataSet ds = bll.GetList_ByEmpl("v.HOSPITAL_CODE='" + model.HOSPITAL_CODE + "'");
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                json += "['" + dr["ENAME"].ToString() + "'," + dr["TIMES"].ToString() + "],";
            }
            json = json.Substring(0, json.Length - 1);
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
    }
}