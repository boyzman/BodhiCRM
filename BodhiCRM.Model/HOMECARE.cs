/**  
* HOMECARE.cs
*
* 功 能： N/A
* 类 名： HOMECARE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/3 13:29:14   N/A    初版
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
	/// 居家护理信息
	/// </summary>
	[Serializable]
	public partial class HOMECARE
	{
		public HOMECARE()
		{}
		#region Model
		private decimal _id;
        private string _hospital_code;
		private string _patient_sn;
		private decimal _employee_id;
		private string _visit_dt;
		private string _visit_place;
		private DateTime _add_time;
		private decimal _create_user_id;
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
        /// 院區代碼(病歷號第一碼)
        /// </summary>
        public string HOSPITAL_CODE
        {
            set { _hospital_code = value; }
            get { return _hospital_code; }
        }
		/// <summary>
		/// 患者病历号
		/// </summary>
		public string PATIENT_SN
		{
			set{ _patient_sn=value;}
			get{return _patient_sn;}
		}
		/// <summary>
		/// 医师ID
		/// </summary>
		public decimal EMPLOYEE_ID
		{
			set{ _employee_id=value;}
			get{return _employee_id;}
		}
		/// <summary>
		/// 探访时间
		/// </summary>
		public string VISIT_DT
		{
			set{ _visit_dt=value;}
			get{return _visit_dt;}
		}
		/// <summary>
		/// 探访地点
		/// </summary>
		public string VISIT_PLACE
		{
			set{ _visit_place=value;}
			get{return _visit_place;}
		}
		/// <summary>
		/// 录入时间
		/// </summary>
		public DateTime ADD_TIME
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 创建人ID
		/// </summary>
		public decimal CREATE_USER_ID
		{
			set{ _create_user_id=value;}
			get{return _create_user_id;}
		}
		/// <summary>
		/// 备注（检查结果）
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

