/**  
* FAMILY.cs
*
* 功 能： N/A
* 类 名： FAMILY
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/31 19:17:42   N/A    初版
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
	/// 病患家属基本资料
	/// </summary>
	[Serializable]
	public partial class FAMILY
	{
		public FAMILY()
		{}
		#region Model
		private decimal _id;
		private string _patient_sn;
		private string _patient_relation;
		private string _cname;
		private string _ename;
		private decimal _gender_id;
		private string _birth_date;
		private decimal? _height;
		private decimal? _weight;
		private string _mobile_tel;
		private string _id_card_code;
		private decimal? _create_user_id;
		private DateTime? _create_time;
		private decimal? _modified_user;
		private DateTime? _modified_time;
		private string _status;
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
		/// 病历号(关联病患病历号)
		/// </summary>
		public string PATIENT_SN
		{
			set{ _patient_sn=value;}
			get{return _patient_sn;}
		}
		/// <summary>
		/// 与病患的关系
		/// </summary>
		public string PATIENT_RELATION
		{
			set{ _patient_relation=value;}
			get{return _patient_relation;}
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
		/// 移动电话
		/// </summary>
		public string MOBILE_TEL
		{
			set{ _mobile_tel=value;}
			get{return _mobile_tel;}
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

