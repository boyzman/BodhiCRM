/**  
* DEPARTMENT.cs
*
* 功 能： N/A
* 类 名： DEPARTMENT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/30 17:31:53   N/A    初版
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
	/// 部门信息表
	/// </summary>
	[Serializable]
	public partial class DEPARTMENT
	{
		public DEPARTMENT()
		{}
		#region Model
		private decimal _id;
		private string _hospital_code;
		private string _dept_level;
		private string _dept_uplevel;
		private string _dept_name;
		private string _dept_remark;
		private DateTime _add_time;
		private string _active="Y";
		private string _is_sys="Y";
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
			set{ _hospital_code=value;}
			get{return _hospital_code;}
		}
		/// <summary>
		/// 部门级别
		/// </summary>
		public string DEPT_LEVEL
		{
			set{ _dept_level=value;}
			get{return _dept_level;}
		}
		/// <summary>
		/// 上级部门
		/// </summary>
		public string DEPT_UPLEVEL
		{
			set{ _dept_uplevel=value;}
			get{return _dept_uplevel;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string DEPT_NAME
		{
			set{ _dept_name=value;}
			get{return _dept_name;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string DEPT_REMARK
		{
			set{ _dept_remark=value;}
			get{return _dept_remark;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime ADD_TIME
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 是否有效
		/// </summary>
		public string ACTIVE
		{
			set{ _active=value;}
			get{return _active;}
		}
		/// <summary>
		/// 是否默认
		/// </summary>
		public string IS_SYS
		{
			set{ _is_sys=value;}
			get{return _is_sys;}
		}
		#endregion Model

	}
}

