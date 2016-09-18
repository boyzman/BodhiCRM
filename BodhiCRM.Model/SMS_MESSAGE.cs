/**  
* SMS_MESSAGE.cs
*
* 功 能： N/A
* 类 名： SMS_MESSAGE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/18 14:26:00   N/A    初版
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
	/// 会员短消息
	/// </summary>
	[Serializable]
	public partial class SMS_MESSAGE
	{
		public SMS_MESSAGE()
		{}
		#region Model
		private decimal _id;
		private decimal? _tid;
		private string _call_index;
		private string _type="系统消息";
		private string _post_user_name;
		private string _get_user_name;
		private string _patient_sn;
		private string _patient_mobile;
		private decimal _parent_id=0 ;
		private string _is_read="N";
		private string _title;
		private string _content;
		private string _post_time;
		private string _read_time;
		private string _status="N";
		private string _datas;
		private string _error_message;
		/// <summary>
		/// 自增ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 模板ID
		/// </summary>
		public decimal? TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 模板简称
		/// </summary>
		public string CALL_INDEX
		{
			set{ _call_index=value;}
			get{return _call_index;}
		}
		/// <summary>
		/// 短信息类型0系统消息1收件箱2发件箱
		/// </summary>
		public string TYPE
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 发件人
		/// </summary>
		public string POST_USER_NAME
		{
			set{ _post_user_name=value;}
			get{return _post_user_name;}
		}
		/// <summary>
		/// 收件人
		/// </summary>
		public string GET_USER_NAME
		{
			set{ _get_user_name=value;}
			get{return _get_user_name;}
		}
		/// <summary>
		/// 病患病历号
		/// </summary>
		public string PATIENT_SN
		{
			set{ _patient_sn=value;}
			get{return _patient_sn;}
		}
		/// <summary>
		/// 病患手机号
		/// </summary>
		public string PATIENT_MOBILE
		{
			set{ _patient_mobile=value;}
			get{return _patient_mobile;}
		}
		/// <summary>
		/// 关联父ID（0表示无父类）(回复)
		/// </summary>
		public decimal PARENT_ID
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 未阅N\已阅Y
		/// </summary>
		public string IS_READ
		{
			set{ _is_read=value;}
			get{return _is_read;}
		}
		/// <summary>
		/// 短信息标题
		/// </summary>
		public string TITLE
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 短信息内容
		/// </summary>
		public string CONTENT
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 发送时间
		/// </summary>
		public string POST_TIME
		{
			set{ _post_time=value;}
			get{return _post_time;}
		}
		/// <summary>
		/// 阅读时间
		/// </summary>
		public string READ_TIME
		{
			set{ _read_time=value;}
			get{return _read_time;}
		}
		/// <summary>
		/// 是否发送成功
		/// </summary>
		public string STATUS
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 内容里的标签关键字(逗号隔开)
		/// </summary>
		public string DATAS
		{
			set{ _datas=value;}
			get{return _datas;}
		}
		/// <summary>
		/// 错误信息
		/// </summary>
		public string ERROR_MESSAGE
		{
			set{ _error_message=value;}
			get{return _error_message;}
		}
		#endregion Model

	}
}

