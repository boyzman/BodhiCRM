/**  
* M_LABEL.cs
*
* 功 能： N/A
* 类 名： M_LABEL
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/26 16:44:54   N/A    初版
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
	/// 标签管理
	/// </summary>
	[Serializable]
	public partial class M_LABEL
	{
		public M_LABEL()
		{}
		#region Model
		private decimal _id;
		private string _hospital_code;
		private string _label_type;
		private string _label_name;
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
		/// 标签类型
		/// </summary>
		public string LABEL_TYPE
		{
			set{ _label_type=value;}
			get{return _label_type;}
		}
		/// <summary>
		/// 标签名称
		/// </summary>
		public string LABEL_NAME
		{
			set{ _label_name=value;}
			get{return _label_name;}
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

