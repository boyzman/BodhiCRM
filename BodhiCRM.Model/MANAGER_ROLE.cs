/**  
* MANAGER_ROLE.cs
*
* 功 能： N/A
* 类 名： MANAGER_ROLE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/24 18:02:50   N/A    初版
*
* Copyright (c) 2012 Lussen Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：卢森科技（青岛）科技服务有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
namespace BodhiCRM.Model
{
	/// <summary>
	/// 管理角色表
	/// </summary>
	[Serializable]
	public partial class MANAGER_ROLE
	{
		public MANAGER_ROLE()
		{}
		#region Model
		private decimal _id;
        private string _hospital_code;
		private string _role_name;
		private decimal _role_type;
		private decimal _is_sys=0 ;
		/// <summary>
		/// 自增ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
        /// <summary>
        /// 医院CODE
        /// </summary>
        public string HOSPITAL_CODE
        {
            set { _hospital_code = value; }
            get { return _hospital_code; }
        }
		/// <summary>
		/// 角色名称
		/// </summary>
		public string ROLE_NAME
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		/// <summary>
		/// 角色类型
		/// </summary>
		public decimal ROLE_TYPE
		{
			set{ _role_type=value;}
			get{return _role_type;}
		}
		/// <summary>
		/// 是否系统默认0否1是
		/// </summary>
		public decimal IS_SYS
		{
			set{ _is_sys=value;}
			get{return _is_sys;}
		}

        private List<MANAGER_ROLE_VALUE> _manager_role_values;
        /// <summary>
        /// 权限子类 
        /// </summary>
        public List<MANAGER_ROLE_VALUE> manager_role_values
        {
            set { _manager_role_values = value; }
            get { return _manager_role_values; }
        }
		#endregion Model

	}
}

