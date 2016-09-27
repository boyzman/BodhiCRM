/**  
* M_VIPSET.cs
*
* 功 能： N/A
* 类 名： M_VIPSET
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/26 16:44:50   N/A    初版
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
	/// VIP价值规则设置
	/// </summary>
	[Serializable]
	public partial class M_VIPSET
	{
		public M_VIPSET()
		{}
		#region Model
		private decimal _id;
		private string _hospital_code;
		private decimal? _v_id;
		private string _vip_name;
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
		/// 价值规则ID
		/// </summary>
		public decimal? V_ID
		{
			set{ _v_id=value;}
			get{return _v_id;}
		}
		/// <summary>
		/// VIP名称
		/// </summary>
		public string VIP_NAME
		{
			set{ _vip_name=value;}
			get{return _vip_name;}
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

