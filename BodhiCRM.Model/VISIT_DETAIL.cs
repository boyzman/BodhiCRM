/**  
* VISIT_DETAIL.cs
*
* 功 能： N/A
* 类 名： VISIT_DETAIL
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/6 10:53:42   N/A    初版
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
	/// 随访记录明细表
	/// </summary>
	[Serializable]
	public partial class VISIT_DETAIL
	{
		public VISIT_DETAIL()
		{}
		#region Model
		private decimal _id;
		private decimal? _visit_id;
		private string _visit_dt;
		private string _visit_detail_status;
		private decimal? _visit_user_id;
		private string _visit_nextdt;
		private DateTime? _add_time;
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
		/// 随访ID
		/// </summary>
		public decimal? VISIT_ID
		{
			set{ _visit_id=value;}
			get{return _visit_id;}
		}
		/// <summary>
		/// 随访时间
		/// </summary>
		public string VISIT_DT
		{
			set{ _visit_dt=value;}
			get{return _visit_dt;}
		}
		/// <summary>
		/// 随访进度(未开始、进行中、跟进中、已完成)
		/// </summary>
		public string VISIT_DETAIL_STATUS
		{
			set{ _visit_detail_status=value;}
			get{return _visit_detail_status;}
		}
		/// <summary>
		/// 随访人（最终记录增加修改人）
		/// </summary>
		public decimal? VISIT_USER_ID
		{
			set{ _visit_user_id=value;}
			get{return _visit_user_id;}
		}
		/// <summary>
		/// 计划下次随访时间
		/// </summary>
		public string VISIT_NEXTDT
		{
			set{ _visit_nextdt=value;}
			get{return _visit_nextdt;}
		}
		/// <summary>
		/// 增加时间
		/// </summary>
		public DateTime? ADD_TIME
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 随访记录
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

