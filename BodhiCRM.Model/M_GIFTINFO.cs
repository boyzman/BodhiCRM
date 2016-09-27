/**  
* M_GIFTINFO.cs
*
* 功 能： N/A
* 类 名： M_GIFTINFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/26 16:44:56   N/A    初版
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
	/// 礼品登记
	/// </summary>
	[Serializable]
	public partial class M_GIFTINFO
	{
		public M_GIFTINFO()
		{}
		#region Model
		private decimal _id;
		private string _hospital_code;
		private string _info_title;
		private string _gift_name;
		private string _cur_time;
		private string _get_time;
		private string _end_time;
		private string _status="Y";
		private string _remark;
		/// <summary>
		/// 自增长
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
		/// 活动标题
		/// </summary>
		public string INFO_TITLE
		{
			set{ _info_title=value;}
			get{return _info_title;}
		}
		/// <summary>
		/// 礼品名称
		/// </summary>
		public string GIFT_NAME
		{
			set{ _gift_name=value;}
			get{return _gift_name;}
		}
		/// <summary>
		/// 预取时间
		/// </summary>
		public string CUR_TIME
		{
			set{ _cur_time=value;}
			get{return _cur_time;}
		}
		/// <summary>
		/// 实取时间
		/// </summary>
		public string GET_TIME
		{
			set{ _get_time=value;}
			get{return _get_time;}
		}
		/// <summary>
		/// 截止时间
		/// </summary>
		public string END_TIME
		{
			set{ _end_time=value;}
			get{return _end_time;}
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

