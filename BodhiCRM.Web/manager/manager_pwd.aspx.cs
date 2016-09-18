using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;

namespace BodhiCRM.Web.manager
{
    public partial class manager_pwd : Web.Aid.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Model.MANAGER model = GetAdminInfo();
                ShowInfo(Convert.ToInt32(model.ID));
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.MANAGER bll = new BLL.MANAGER();
            Model.MANAGER model = bll.GetModel(_id);
            txtUserName.Text = model.USER_NAME;
            txtRealName.Text = model.REAL_NAME;
            txtTelephone.Text = model.TELEPHONE;
            txtEmail.Text = model.EMAIL;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL.MANAGER bll = new BLL.MANAGER();
            Model.MANAGER model = GetAdminInfo();

            if (DESEncrypt.Encrypt(txtOldPassword.Text.Trim(), model.SALT) != model.PASSWORD)
            {
                JscriptMsg("旧密码不正确！", "");
                return;
            }
            if (txtPassword.Text.Trim() != txtPassword1.Text.Trim())
            {
                JscriptMsg("两次密码不一致！", "");
                return;
            }
            model.PASSWORD = DESEncrypt.Encrypt(txtPassword.Text.Trim(), model.SALT);
            model.REAL_NAME = txtRealName.Text.Trim();
            model.TELEPHONE = txtTelephone.Text.Trim();
            model.EMAIL = txtEmail.Text.Trim();

            if (!bll.Update(model))
            {
                JscriptMsg("保存过程中发生错误！", "");
                return;
            }
            Session[DTKeys.SESSION_ADMIN_INFO] = null;
            JscriptMsg("密码修改成功！", "manager_pwd.aspx");
        }
    }
}