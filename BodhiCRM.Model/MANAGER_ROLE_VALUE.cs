/**  
* MANAGER_ROLE_VALUE.cs
*
* 功 能： N/A
* 类 名： MANAGER_ROLE_VALUE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/24 18:02:53   N/A    初版
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
	/// 管理角色权限表
	/// </summary>
	[Serializable]
	public partial class MANAGER_ROLE_VALUE
	{
		public MANAGER_ROLE_VALUE()
		{}
		#region Model
		private decimal _id;
		private decimal _role_id;
		private string _nav_name;
		private string _action_type;
		/// <summary>
		/// 自增ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 导航名称
		/// </summary>
		public string NAV_NAME
		{
			set{ _nav_name=value;}
			get{return _nav_name;}
		}
		/// <summary>
		/// 权限类型
		/// </summary>
		public string ACTION_TYPE
		{
			set{ _action_type=value;}
			get{return _action_type;}
		}
		#endregion Model

	}
}

