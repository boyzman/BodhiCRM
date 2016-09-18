/**  
* SMS_TEMPLATE.cs
*
* 功 能： N/A
* 类 名： SMS_TEMPLATE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/12 9:53:20   N/A    初版
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
	/// 手机短信模板
	/// </summary>
	[Serializable]
	public partial class SMS_TEMPLATE
	{
		public SMS_TEMPLATE()
		{}
		#region Model
		private decimal _id;
		private string _title;
		private string _call_index;
		private string _content;
		private string _is_sys="Y";
		private string _status="Y";
		/// <summary>
		/// 自增ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string TITLE
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 调用别名
		/// </summary>
		public string CALL_INDEX
		{
			set{ _call_index=value;}
			get{return _call_index;}
		}
		/// <summary>
		/// 短信内容
		/// </summary>
		public string CONTENT
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 系统默认
		/// </summary>
		public string IS_SYS
		{
			set{ _is_sys=value;}
			get{return _is_sys;}
		}
		/// <summary>
		/// 是否有效
		/// </summary>
		public string STATUS
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

