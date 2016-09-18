/**  
* HOSPITAL.cs
*
* 功 能： N/A
* 类 名： HOSPITAL
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/31 13:49:31   N/A    初版
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
	/// 医院(诊所)信息
	/// </summary>
	[Serializable]
	public partial class HOSPITAL
	{
		public HOSPITAL()
		{}
		#region Model

		private string _hospital_code;
		private string _hospital_name;
		private string _abbreviation;
		private string _address;
		private string _hospital_phone;
		private string _fee_license;
		private string _active="Y";
		private string _hospital_name_en;
		/// <summary>
		/// 院區代碼(病歷號第一碼)
		/// </summary>
		public string HOSPITAL_CODE
		{
			set{ _hospital_code=value;}
			get{return _hospital_code;}
		}
		/// <summary>
		/// 院區名稱
		/// </summary>
		public string HOSPITAL_NAME
		{
			set{ _hospital_name=value;}
			get{return _hospital_name;}
		}
		/// <summary>
		/// 院區簡稱
		/// </summary>
		public string ABBREVIATION
		{
			set{ _abbreviation=value;}
			get{return _abbreviation;}
		}
		/// <summary>
		/// 院區地址
		/// </summary>
		public string ADDRESS
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 醫院電話
		/// </summary>
		public string HOSPITAL_PHONE
		{
			set{ _hospital_phone=value;}
			get{return _hospital_phone;}
		}
		/// <summary>
		/// 收費許可證號
		/// </summary>
		public string FEE_LICENSE
		{
			set{ _fee_license=value;}
			get{return _fee_license;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string ACTIVE
		{
			set{ _active=value;}
			get{return _active;}
		}
		/// <summary>
		/// 英文名
		/// </summary>
		public string HOSPITAL_NAME_EN
		{
			set{ _hospital_name_en=value;}
			get{return _hospital_name_en;}
		}
		#endregion Model

	}
}

