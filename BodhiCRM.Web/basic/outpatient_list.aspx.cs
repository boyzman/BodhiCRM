﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;
using BodhiCRM.Web.Aid;
using System.Text;
using System.Data;

namespace BodhiCRM.Web.basic
{
    public partial class outpatient_list : Web.Aid.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");
            this.page = DTRequest.GetQueryInt("page");
            this.pageSize = GetPageSize(10); //每页数量

            if (page != 0)
            {
                RptBind("1=1" + CombSqlTxt(keywords), "visit_date asc,patient_sn desc");
            }
            
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("outpatient_list", DTEnums.ActionEnum.View.ToString()); //检查权限
            }
        }
        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.OUTPATIENT bll = new BLL.OUTPATIENT();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("outpatient_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                //strTemp.Append(" and (p.CNAME like  '%" + _keywords + "%' or r.PATIENT_SN like '%" + _keywords + "%' or p.MOBILE_TEL like '%" + _keywords + "%' or p.ID_CARD_CODE like '%" + _keywords + "%')");
                strTemp.Append(" and r.PATIENT_SN like '%" + _keywords + "%'");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("outpatient_page_size", "BodhiCRMPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Response.Redirect(Utils.CombUrlTxt("outpatient_list.aspx", "keywords={0}", txtKeywords.Text));
            this.keywords = txtKeywords.Text;
            RptBind("1=1" + CombSqlTxt(keywords), "visit_date asc,patient_sn desc");
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("outpatient_page_size", "BodhiCRMPage", _pagesize.ToString(), 14400);
                }
            }
            //Response.Redirect(Utils.CombUrlTxt("outpatient_list.aspx", "keywords={0}", this.keywords));
            RptBind("1=1" + CombSqlTxt(keywords), "visit_date asc,patient_sn desc");
        }

    }
}