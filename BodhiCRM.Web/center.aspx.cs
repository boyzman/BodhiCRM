using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;

namespace BodhiCRM.Web
{
    public partial class center : Web.Aid.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Model.MANAGER admin_info = GetAdminInfo(); //管理员信息
                //登录信息
                if (admin_info != null)
                {
                    BLL.MANAGER_LOG bll = new BLL.MANAGER_LOG();
                    Model.MANAGER_LOG model1 = bll.GetModel(admin_info.USER_NAME, 1, DTEnums.ActionEnum.Login.ToString());
                    if (model1 != null)
                    {
                        //本次登录
                        litIP.Text = model1.USER_IP;
                    }
                    Model.MANAGER_LOG model2 = bll.GetModel(admin_info.USER_NAME, 2, DTEnums.ActionEnum.Login.ToString());
                    if (model2 != null)
                    {
                        //上一次登录
                        litBackIP.Text = model2.USER_IP;
                        litBackTime.Text = model2.ADD_TIME.ToString();
                    }
                }
                
            }
        }
    }
}