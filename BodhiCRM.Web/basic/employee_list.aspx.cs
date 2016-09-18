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
    public partial class employee_list : Web.Aid.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string empl_status=string.Empty;//员工状态
        protected string keywords = string.Empty;//关键字
        protected int depart_id;
        protected string depart_name = string.Empty; //部门名称
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("employee_list", DTEnums.ActionEnum.View.ToString()); //检查权限

            this.empl_status = DTRequest.GetQueryString("empl_status");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.depart_id = DTRequest.GetQueryInt("depart_id");
            this.pageSize = GetPageSize(10); //每页数量
         
            if (!Page.IsPostBack)
            {
                Model.MANAGER model = GetAdminInfo(); //取得当前管理员信息
                TreeBind("ACTIVE='Y' and HOSPITAL_CODE='"+model.HOSPITAL_CODE+"'"); //绑定类别
                RptBind("id>0" + CombSqlTxt(this.empl_status, this.keywords, this.depart_id), "  id desc");
            }
        }

        #region 绑定组别=================================
        private void TreeBind(string strWhere)
        {           
            BLL.DEPARTMENT dbll = new BLL.DEPARTMENT();
            DataTable ddt = dbll.GetList(strWhere).Tables[0];

            this.ddlDepartId.Items.Clear();
            this.ddlDepartId.Items.Add(new ListItem("所有部门", "0"));
           
            foreach (DataRow dr in ddt.Rows)
            {
                string Id = dr["id"].ToString();
                string Title = dr["Dept_NAME"].ToString().Trim();
                this.ddlDepartId.Items.Add(new ListItem(Title, Id));
            }
            this.ddlStatusId.Items.Clear();//shelf_type
            this.ddlStatusId.Items.Add(new ListItem("所有状态", ""));
            this.ddlStatusId.Items.Add(new ListItem("在职", "Y"));
            this.ddlStatusId.Items.Add(new ListItem("离职", "N"));
        }

        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.ddlDepartId.SelectedValue = this.depart_id.ToString();
            this.ddlStatusId.SelectedValue = this.empl_status.ToString();
            this.txtKeywords.Text = this.keywords;
            BLL.EMPLOYEE bll = new BLL.EMPLOYEE();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("employee_list.aspx", "empl_status={0}&keywords={1}&page={2}&depart_id={3}",
                empl_status.ToString(), this.keywords, "__id__", this.depart_id.ToString());
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _empl_status, string _keywords,  int _departid)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_departid > 0)
            {
                strTemp.Append(" and dept_id=" + _departid);
            }
            if (!string.IsNullOrEmpty(_empl_status))
            {
                strTemp.Append(" and status='" + _empl_status+"'");
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (REAL_NAME like '%" + _keywords + "%' or TELEPHONE like '%" + _keywords + "%' or EMAIL like '%" + _keywords + "%' )");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("employee_list_page_size", "BodhiCRMPage"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("employee_list.aspx", "empl_status={0}&keywords={1}&depart_id={2}",
              empl_status.ToString(), txtKeywords.Text, depart_id.ToString()));
        }

        protected void ddlDepartId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("employee_list.aspx", "empl_status={0}&keywords={1}&depart_id={2}",
              empl_status.ToString(), txtKeywords.Text, depart_id.ToString()));
        }
       
        protected void ddlStatusId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("employee_list.aspx", "empl_status={0}&keywords={1}&depart_id={2}",
               empl_status.ToString(), txtKeywords.Text, depart_id.ToString()));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("employee_list_page_size", "BodhiCRMPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("employee_list.aspx", "empl_status={0}&keywords={1}&depart_id={2}",
                     empl_status.ToString(), this.keywords, this.depart_id.ToString()));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("employee_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.FAMILY bll = new BLL.FAMILY();
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
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除员工信息" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("employee_list.aspx", "empl_status={0}&keywords={1}&depart_id={2}",
                     empl_status.ToString(), this.keywords, this.depart_id.ToString()));
        }
    }
}