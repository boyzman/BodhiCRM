/**  
* VISIT.cs
*
* 功 能： N/A
* 类 名： VISIT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/6 10:53:40   N/A    初版
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
	/// 随访记录表
	/// </summary>
	[Serializable]
	public partial class VISIT
	{
		public VISIT()
		{}
		#region Model
		private decimal _id;
        private string _hospital_code;
		private string _patient_sn;
		private decimal _empl_id;
		private string _visit_title;
		private string _visit_type;
		private string _visit_startdt;
		private string _visit_enddt;
		private string _visit_frequency;
		private decimal? _visit_frequencyno;
		private string _visit_status;
		private DateTime _add_time;
		private decimal? _create_user_id;
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
            set { _hospital_code = value; }
            get { return _hospital_code; }
        }
		/// <summary>
		/// 病历号
		/// </summary>
		public string PATIENT_SN
		{
			set{ _patient_sn=value;}
			get{return _patient_sn;}
		}
		/// <summary>
		/// 医师ID
		/// </summary>
		public decimal EMPL_ID
		{
			set{ _empl_id=value;}
			get{return _empl_id;}
		}
		/// <summary>
		/// 随访标题
		/// </summary>
		public string VISIT_TITLE
		{
			set{ _visit_title=value;}
			get{return _visit_title;}
		}
		/// <summary>
		/// 随访类型（关怀慰问、生日祝福、病患访问）
		/// </summary>
		public string VISIT_TYPE
		{
			set{ _visit_type=value;}
			get{return _visit_type;}
		}
		/// <summary>
		/// 随访开始时间
		/// </summary>
		public string VISIT_STARTDT
		{
			set{ _visit_startdt=value;}
			get{return _visit_startdt;}
		}
		/// <summary>
		/// 随访结束时间
		/// </summary>
		public string VISIT_ENDDT
		{
			set{ _visit_enddt=value;}
			get{return _visit_enddt;}
		}
		/// <summary>
		/// 随访频次(天、周、月、季度、年)
		/// </summary>
		public string VISIT_FREQUENCY
		{
			set{ _visit_frequency=value;}
			get{return _visit_frequency;}
		}
		/// <summary>
		/// 频次数
		/// </summary>
		public decimal? VISIT_FREQUENCYNO
		{
			set{ _visit_frequencyno=value;}
			get{return _visit_frequencyno;}
		}
		/// <summary>
		/// 随访进度(未开始、进行中、跟进中、已完成)
		/// </summary>
		public string VISIT_STATUS
		{
			set{ _visit_status=value;}
			get{return _visit_status;}
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
		/// 添加人
		/// </summary>
		public decimal? CREATE_USER_ID
		{
			set{ _create_user_id=value;}
			get{return _create_user_id;}
		}
		/// <summary>
		/// 是否有效
		/// </summary>
		public string STATUS
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 随访内容
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

