/**  
* MANAGER_LOG.cs
*
* 功 能： N/A
* 类 名： MANAGER_LOG
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/24 18:02:49   N/A    初版
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
	/// 管理日志表
	/// </summary>
	[Serializable]
	public partial class MANAGER_LOG
	{
		public MANAGER_LOG()
		{}
		#region Model
		private decimal _id;
        private string _hospital_code;
		private decimal _user_id;
		private string _user_name;
		private string _action_type;
		private string _remark;
		private string _user_ip;
		private DateTime _add_time;
        private string _before_param;
        private string _after_param;
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
		/// 用户ID
		/// </summary>
		public decimal USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
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
		/// 操作类型
		/// </summary>
		public string ACTION_TYPE
		{
			set{ _action_type=value;}
			get{return _action_type;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 用户IP
		/// </summary>
		public string USER_IP
		{
			set{ _user_ip=value;}
			get{return _user_ip;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime ADD_TIME
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string BEFORE_PARAM
        {
            set { _before_param = value; }
            get { return _before_param; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AFTER_PARAM
        {
            set { _after_param = value; }
            get { return _after_param; }
        }
		#endregion Model

	}
}

