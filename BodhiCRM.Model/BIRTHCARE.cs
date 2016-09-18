/**  
* BIRTHCARE.cs
*
* 功 能： N/A
* 类 名： BIRTHCARE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/6 10:53:43   N/A    初版
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
	/// 生日关怀
	/// </summary>
	[Serializable]
	public partial class BIRTHCARE
	{
		public BIRTHCARE()
		{}
		#region Model
		private decimal _id;
        private string _hospital_code;
		private string _patient_sn;
		private decimal? _dept_id;
		private decimal? _sms_id;
		private string _gift_name;
		private string _gift_payment;
		private string _gift_value;
		private string _gift_getdt;
		private DateTime _add_time;
		private decimal _create_user_id;
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
		/// 科室ID
		/// </summary>
		public decimal? DEPT_ID
		{
			set{ _dept_id=value;}
			get{return _dept_id;}
		}
		/// <summary>
		/// 发送短信ID
		/// </summary>
        public decimal? SMS_ID
        {
            set { _sms_id = value; }
            get { return _sms_id; }
        }
		
		/// <summary>
		/// 礼物名称
		/// </summary>
		public string GIFT_NAME
		{
			set{ _gift_name=value;}
			get{return _gift_name;}
		}
		/// <summary>
		/// 礼物领取方式
		/// </summary>
		public string GIFT_PAYMENT
		{
			set{ _gift_payment=value;}
			get{return _gift_payment;}
		}
		/// <summary>
		/// 礼物价值
		/// </summary>
		public string GIFT_VALUE
		{
			set{ _gift_value=value;}
			get{return _gift_value;}
		}
		/// <summary>
		/// 领取时间
		/// </summary>
		public string GIFT_GETDT
		{
			set{ _gift_getdt=value;}
			get{return _gift_getdt;}
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
		/// 创建人
		/// </summary>
		public decimal CREATE_USER_ID
		{
			set{ _create_user_id=value;}
			get{return _create_user_id;}
		}
		/// <summary>
		/// 状态
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

