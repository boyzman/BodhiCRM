using BodhiCRM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace BodhiCRM.Web.visit
{
    public partial class visit_list : Web.Aid.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                // ChkAdminLevel("archives_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("1=1" + CombSqlTxt(keywords), "add_time asc,id desc");
            }
        }
        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.VISIT bll = new BLL.VISIT();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("visit_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords) && _keywords != "病历号、患者姓名、患者电话、随访人")
            {
                strTemp.Append(" and (CNAME like  '%" + _keywords + "%' or v.PATIENT_SN like '%" + _keywords + "%' or MOBILE_TEL like '%" + _keywords + "%' or ENAME like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("visit_page_size", "BodhiCRMPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("visit_list.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("visit_page_size", "BodhiCRMPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("visit_list.aspx", "keywords={0}", this.keywords));
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("rptList_visit_detail") as Repeater;
               
                DataRowView rowv = (DataRowView)e.Item.DataItem;

                string pid = rowv["ID"].ToString();

                string sWhere = "VISIT_ID='" + pid + "'";
                BLL.VISIT_DETAIL bll = new BLL.VISIT_DETAIL();
                rep.DataSource = bll.GetList(sWhere);
                rep.DataBind();


            }
        }


    }
}