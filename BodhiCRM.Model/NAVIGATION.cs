/**  
* NAVIGATION.cs
*
* 功 能： N/A
* 类 名： NAVIGATION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/25 13:56:23   N/A    初版
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
	/// 系统导航菜单(模块)
	/// </summary>
	[Serializable]
	public partial class NAVIGATION
	{
		public NAVIGATION()
		{}
		#region Model
		private decimal _id;
		private decimal? _parent_id=0;
		private decimal? _channel_id=0;
		private string _nav_type="";
		private string _name="";
		private string _title="";
		private string _sub_title="";
		private string _icon_url="";
		private string _link_url="";
		private decimal? _sort_id=99;
		private decimal? _is_lock=0;
		private string _remark="";
		private string _action_type="";
		private decimal? _is_sys=0;
		private decimal? _is_account=1;
		/// <summary>
		/// 自增ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 所属父导航ID
		/// </summary>
		public decimal? PARENT_ID
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 所属频道ID
		/// </summary>
		public decimal? CHANNEL_ID
		{
			set{ _channel_id=value;}
			get{return _channel_id;}
		}
		/// <summary>
		/// 导航类别
		/// </summary>
		public string NAV_TYPE
		{
			set{ _nav_type=value;}
			get{return _nav_type;}
		}
		/// <summary>
		/// 导航ID
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
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
		/// 副标题
		/// </summary>
		public string SUB_TITLE
		{
			set{ _sub_title=value;}
			get{return _sub_title;}
		}
		/// <summary>
		/// 图标地址
		/// </summary>
		public string ICON_URL
		{
			set{ _icon_url=value;}
			get{return _icon_url;}
		}
		/// <summary>
		/// 链接地址
		/// </summary>
		public string LINK_URL
		{
			set{ _link_url=value;}
			get{return _link_url;}
		}
		/// <summary>
		/// 排序数字
		/// </summary>
		public decimal? SORT_ID
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 是否隐藏0显示1隐藏
		/// </summary>
		public decimal? IS_LOCK
		{
			set{ _is_lock=value;}
			get{return _is_lock;}
		}
		/// <summary>
		/// 备注说明
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 权限资源
		/// </summary>
		public string ACTION_TYPE
		{
			set{ _action_type=value;}
			get{return _action_type;}
		}
		/// <summary>
		/// 系统默认
		/// </summary>
		public decimal? IS_SYS
		{
			set{ _is_sys=value;}
			get{return _is_sys;}
		}
		/// <summary>
		/// 0 否 1是
		/// </summary>
		public decimal? IS_ACCOUNT
		{
			set{ _is_account=value;}
			get{return _is_account;}
		}
		#endregion Model

	}
}

