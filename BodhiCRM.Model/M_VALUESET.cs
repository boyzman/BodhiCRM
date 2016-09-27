/**  
* M_VALUESET.cs
*
* 功 能： N/A
* 类 名： M_VALUESET
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/26 16:44:42   N/A    初版
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
	/// 价值规则设置
	/// </summary>
	[Serializable]
	public partial class M_VALUESET
	{
		public M_VALUESET()
		{}
		#region Model
		private decimal _id;
		private string _hospital_code;
		private string _title;
		private string _v_type="按金额";
		private string _cur_value;
		private string _min_value;
		private string _max_value;
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
		/// 价值标题
		/// </summary>
		public string TITLE
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 价值类型(按金额、按病种)
		/// </summary>
		public string V_TYPE
		{
			set{ _v_type=value;}
			get{return _v_type;}
		}
		/// <summary>
		/// 价值标准值
		/// </summary>
		public string CUR_VALUE
		{
			set{ _cur_value=value;}
			get{return _cur_value;}
		}
		/// <summary>
		/// 最小价值值
		/// </summary>
		public string MIN_VALUE
		{
			set{ _min_value=value;}
			get{return _min_value;}
		}
		/// <summary>
		/// 最大价值值
		/// </summary>
		public string MAX_VALUE
		{
			set{ _max_value=value;}
			get{return _max_value;}
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

