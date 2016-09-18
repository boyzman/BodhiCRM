using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BodhiCRM.Common;

namespace BodhiCRM.Web.manager
{
    public partial class manager_edit : Web.Aid.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.MANAGER().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("manager_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.MANAGER model = GetAdminInfo(); //取得管理员信息
                RoleBind(ddlRoleId, model.ROLE_TYPE,model.HOSPITAL_CODE);
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 角色类型=================================
        private void RoleBind(DropDownList ddl, decimal role_type,string hospital_code)
        {
            BLL.MANAGER_ROLE bll = new BLL.MANAGER_ROLE();
            DataTable dt = bll.GetList(" HOSPITAL_CODE='"+hospital_code+"'").Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择角色...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["role_type"]) >= Convert.ToInt32(role_type))
                {
                    ddl.Items.Add(new ListItem(dr["role_name"].ToString(), dr["id"].ToString()));
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.MANAGER bll = new BLL.MANAGER();
            Model.MANAGER model = bll.GetModel(_id);
            ddlRoleId.SelectedValue = model.ROLE_ID.ToString();
            if (model.IS_LOCK == 0)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            txtUserName.Text = model.USER_NAME;
            txtUserName.ReadOnly = true;
            txtUserName.Attributes.Remove("ajaxurl");
            if (!string.IsNullOrEmpty(model.PASSWORD))
            {
                txtPassword.Attributes["value"] = txtPassword1.Attributes["value"] = defaultpassword;
            }
            txtRealName.Text = model.REAL_NAME;
            txtTelephone.Text = model.TELEPHONE;
            txtEmail.Text = model.EMAIL;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.MANAGER model = new Model.MANAGER();
            BLL.MANAGER bll = new BLL.MANAGER();
            model.ROLE_ID = int.Parse(ddlRoleId.SelectedValue);
            model.ROLE_TYPE = new BLL.MANAGER_ROLE().GetModel(model.ROLE_ID).ROLE_TYPE;
            if (cbIsLock.Checked == true)
            {
                model.IS_LOCK = 0;
            }
            else
            {
                model.IS_LOCK = 1;
            }
            //检测用户名是否重复
            if (bll.Exists(txtUserName.Text.Trim()))
            {
                return false;
            }
            model.USER_NAME = txtUserName.Text.Trim();
            //获得6位的salt加密字符串
            model.SALT = Utils.GetCheckCode(6);
            //以随机生成的6位字符串做为密钥加密
            model.PASSWORD = DESEncrypt.Encrypt(txtPassword.Text.Trim(), model.SALT);
            model.REAL_NAME = txtRealName.Text.Trim();
            model.TELEPHONE = txtTelephone.Text.Trim();
            model.EMAIL = txtEmail.Text.Trim();
            model.ADD_TIME = DateTime.Now;
            model.HOSPITAL_CODE = Utils.GetCookie("AdminHospital", "BodhiCRM"); 
            if (bll.Add(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加管理员:" + model.USER_NAME); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(decimal _id)
        {
            bool result = false;
            BLL.MANAGER bll = new BLL.MANAGER();
            Model.MANAGER model = bll.GetModel(_id);

            model.ROLE_ID = int.Parse(ddlRoleId.SelectedValue);
            model.ROLE_TYPE = new BLL.MANAGER_ROLE().GetModel(model.ROLE_ID).ROLE_TYPE;
            if (cbIsLock.Checked == true)
            {
                model.IS_LOCK = 0;
            }
            else
            {
                model.IS_LOCK = 1;
            }
            //判断密码是否更改
            if (txtPassword.Text.Trim() != defaultpassword)
            {
                //获取用户已生成的salt作为密钥加密
                model.PASSWORD = DESEncrypt.Encrypt(txtPassword.Text.Trim(), model.SALT);
            }
            model.REAL_NAME = txtRealName.Text.Trim();
            model.TELEPHONE = txtTelephone.Text.Trim();
            model.EMAIL = txtEmail.Text.Trim();

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改管理员:" + model.USER_NAME); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("manager_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改管理员信息成功！", "manager_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("manager_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加管理员信息成功！", "manager_list.aspx");
            }
        }
    }
}