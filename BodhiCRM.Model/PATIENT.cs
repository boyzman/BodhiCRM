/**  
* PATIENT.cs
*
* 功 能： N/A
* 类 名： PATIENT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/29 19:58:43   N/A    初版
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
	/// 病患基本资料
	/// </summary>
	[Serializable]
	public partial class PATIENT
	{
		public PATIENT()
		{}
		#region Model
		private string _patient_sn;
		private string _cname;
		private string _ename;
		private decimal _gender_id;
		private string _birth_date;
		private decimal? _height;
		private decimal? _weight;
		private string _home_tel;
		private string _mobile_tel;
		private string _e_mail;
        private string _home_province_id;
        private string _home_city_id;
        private string _home_section_id;
		private string _address;
		private string _post_code;
		private string _id_card_code;
		private decimal? _create_user_id;
		private DateTime? _create_time;
		private decimal? _modified_user;
		private DateTime? _modified_time;
        private string _status;
		private string _remark;
        private string _label;
		/// <summary>
		/// 病历号
		/// </summary>
		public string PATIENT_SN
		{
			set{ _patient_sn=value;}
			get{return _patient_sn;}
		}
		/// <summary>
		/// 中文姓名(中文)
		/// </summary>
		public string CNAME
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 英文姓名
		/// </summary>
		public string ENAME
		{
			set{ _ename=value;}
			get{return _ename;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public decimal GENDER_ID
		{
			set{ _gender_id=value;}
			get{return _gender_id;}
		}
		/// <summary>
		/// 出生日期
		/// </summary>
		public string BIRTH_DATE
		{
			set{ _birth_date=value;}
			get{return _birth_date;}
		}
		/// <summary>
		/// 身高
		/// </summary>
		public decimal? HEIGHT
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 体重
		/// </summary>
		public decimal? WEIGHT
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 住宅电话
		/// </summary>
		public string HOME_TEL
		{
			set{ _home_tel=value;}
			get{return _home_tel;}
		}
		/// <summary>
		/// 移动电话
		/// </summary>
		public string MOBILE_TEL
		{
			set{ _mobile_tel=value;}
			get{return _mobile_tel;}
		}
		/// <summary>
		/// Email地址
		/// </summary>
		public string E_MAIL
		{
			set{ _e_mail=value;}
			get{return _e_mail;}
		}
		/// <summary>
		/// 住址地区(省) LOCATIONS.LOCATION_ID(LOCATIONS.LOCATION_TYPE_ID=1)
		/// </summary>
		public string HOME_PROVINCE_ID
		{
			set{ _home_province_id=value;}
			get{return _home_province_id;}
		}
		/// <summary>
		/// 住址地区(市) LOCATIONS.LOCATION_ID(LOCATIONS.LOCATION_TYPE_ID=2)
		/// </summary>
		public string HOME_CITY_ID
		{
			set{ _home_city_id=value;}
			get{return _home_city_id;}
		}
		/// <summary>
		/// 住址地区(区、县) LOCATIONS.LOCATION_ID(LOCATIONS.LOCATION_TYPE_ID=3)
		/// </summary>
		public string HOME_SECTION_ID
		{
			set{ _home_section_id=value;}
			get{return _home_section_id;}
		}
		/// <summary>
		/// 地址(中文)
		/// </summary>
		public string ADDRESS
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 住址邮编
		/// </summary>
		public string POST_CODE
		{
			set{ _post_code=value;}
			get{return _post_code;}
		}
		/// <summary>
		/// 身份证证件号码
		/// </summary>
		public string ID_CARD_CODE
		{
			set{ _id_card_code=value;}
			get{return _id_card_code;}
		}
		/// <summary>
		/// 建立者代码
		/// </summary>
		public decimal? CREATE_USER_ID
		{
			set{ _create_user_id=value;}
			get{return _create_user_id;}
		}
		/// <summary>
		/// 建立时间
		/// </summary>
		public DateTime? CREATE_TIME
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 最后维护此笔资料的人员
		/// </summary>
		public decimal? MODIFIED_USER
		{
			set{ _modified_user=value;}
			get{return _modified_user;}
		}
		/// <summary>
		/// 最后维护此笔资料的时间
		/// </summary>
		public DateTime? MODIFIED_TIME
		{
			set{ _modified_time=value;}
			get{return _modified_time;}
		}
        /// <summary>
        /// 状态
        /// </summary>
        public string STATUS
        {
            set { _status = value; }
            get { return _status; }
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
        /// 标签
        /// </summary>
        public string LABEL
        {
            set { _label = value; }
            get { return _label; }
        }
		#endregion Model

	}
}

