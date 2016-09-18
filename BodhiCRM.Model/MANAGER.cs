/**  
* MANAGER.cs
*
* 功 能： N/A
* 类 名： MANAGER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/24 18:02:48   N/A    初版
*
* Copyright (c) 2012 Lussen Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：卢森科技（青岛）科技服务有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace BodhiCRM.Model
{
	/// <summary>
	/// 管理员信息表
	/// </summary>
	[Serializable]
	public partial class MANAGER
	{
		public MANAGER()
		{}
		#region Model
		private decimal _id;
		private string _hospital_code;
		private decimal _role_id;
		private decimal _role_type=2 ;
		private string _user_name;
		private string _password;
		private string _salt;
		private string _real_name;
		private string _telephone;
		private string _email;
		private decimal _is_lock=0 ;
		private DateTime _add_time;
		/// <summary>
		/// 自增ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 医院ID
		/// </summary>
		public string HOSPITAL_CODE
		{
			set{ _hospital_code=value;}
			get{return _hospital_code;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public decimal ROLE_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 管理员类型1超管2系管
		/// </summary>
		public decimal ROLE_TYPE
		{
			set{ _role_type=value;}
			get{return _role_type;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string USER_NAME
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 登录密码
		/// </summary>
		public string PASSWORD
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 6位随机字符串,加密用到
		/// </summary>
		public string SALT
		{
			set{ _salt=value;}
			get{return _salt;}
		}
		/// <summary>
		/// 用户昵称
		/// </summary>
		public string REAL_NAME
		{
			set{ _real_name=value;}
			get{return _real_name;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string TELEPHONE
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string EMAIL
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 是否锁定
		/// </summary>
		public decimal IS_LOCK
		{
			set{ _is_lock=value;}
			get{return _is_lock;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime ADD_TIME
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}
}

