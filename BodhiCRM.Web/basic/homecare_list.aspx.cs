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

namespace BodhiCRM.Web.basic
{
    public partial class homecare_list : Web.Aid.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;//关键字
        protected string visitdt = string.Empty;//探访时间
        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("homecare_list", DTEnums.ActionEnum.View.ToString()); //检查权限
            this.keywords = DTRequest.GetQueryString("keywords");
            this.visitdt = DTRequest.GetQueryString("visitdt");     
            this.pageSize = GetPageSize(10); //每页数量
            //txtVisitdt.Attributes["onblur"] = ClientScript.GetPostBackEventReference(txtVisitdt, null);
            if (!Page.IsPostBack)
            {
                Model.MANAGER model = GetAdminInfo(); //取得当前管理员信息
               
                RptBind("id>0" + CombSqlTxt(this.visitdt,this.keywords), "  id desc");
            }
        }


        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtVisitdt.Text = this.visitdt;
            this.txtKeywords.Text = this.keywords;
            BLL.HOMECARE bll = new BLL.HOMECARE();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("homecare_list.aspx", "keywords={0}&page={1}&visitdt={2}",
                 this.keywords, "__id__", this.visitdt.ToString());
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _visitdt,string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();

            if (!string.IsNullOrEmpty(_visitdt))
            {
                strTemp.Append(" and VISIT_DT='" + _visitdt + "'");
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (PNAME like '%" + _keywords + "%' or ENAME like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("homecare_list_page_size", "BodhiCRMPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("homecare_list.aspx", "keywords={0}&page={1}&visitdt={2}",
                 txtKeywords.Text.Trim(), "__id__", txtVisitdt.Text.Trim()));
        }
       
        //protected void txtVisitdt_TextChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect(Utils.CombUrlTxt("homecare_list.aspx", "keywords={0}&page={1}&visitdt={2}",
        //        this.keywords, "__id__", this.visitdt.ToString()));
        //}
       
      
        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("homecare_list_page_size", "BodhiCRMPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("homecare_list.aspx", "keywords={0}&page={1}&visitdt={2}",
                this.keywords, "__id__", this.visitdt.ToString()));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("homecare_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.HOMECARE bll = new BLL.HOMECARE();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value.ToString());
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除居家护理信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("homecare_list.aspx", "keywords={0}&page={1}&visitdt={2}",
                this.keywords, "__id__", this.visitdt.ToString()));
        }

        
    }
}