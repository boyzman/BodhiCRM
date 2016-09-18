/**  
* EMPLOYEE.cs
*
* 功 能： N/A
* 类 名： EMPLOYEE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/2 13:28:57   N/A    初版
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
	/// 员工信息表
	/// </summary>
	[Serializable]
	public partial class EMPLOYEE
	{
		public EMPLOYEE()
		{}
		#region Model
		private decimal _id;
		private string _hospital_code;
		private string _post_name;
		private decimal? _dept_id;
		private decimal? _gender_id;
		private string _real_name;
		private string _telephone;
		private string _email;
		private DateTime? _add_time;
        private string _in_time;
        private string _left_time;
		private string _active="Y";
		private string _status="Y";
		private string _remark;
		/// <summary>
		/// 自增ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 医院code
		/// </summary>
		public string HOSPITAL_CODE
		{
			set{ _hospital_code=value;}
			get{return _hospital_code;}
		}
		/// <summary>
		/// 职务
		/// </summary>
		public string POST_NAME
		{
			set{ _post_name=value;}
			get{return _post_name;}
		}
		/// <summary>
		/// 部门ID
		/// </summary>
		public decimal? DEPT_ID
		{
			set{ _dept_id=value;}
			get{return _dept_id;}
		}
		/// <summary>
		/// 性别(0 女 1 男)
		/// </summary>
		public decimal? GENDER_ID
		{
			set{ _gender_id=value;}
			get{return _gender_id;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string REAL_NAME
		{
			set{ _real_name=value;}
			get{return _real_name;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string TELEPHONE
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string EMAIL
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? ADD_TIME
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 入职时间
		/// </summary>
        public string IN_TIME
		{
			set{ _in_time=value;}
			get{return _in_time;}
		}
		/// <summary>
		/// 离职时间
		/// </summary>
        public string LEFT_TIME
		{
			set{ _left_time=value;}
			get{return _left_time;}
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
		/// 是否在职
		/// </summary>
		public string STATUS
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

