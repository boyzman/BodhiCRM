/**  
* PATIENT.cs
*
* 功 能： N/A
* 类 名： OUTPATIENT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/29 19:58:43   N/A    初版
*
* Copyright (c) 2012 Lussen Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：卢森科技（青岛）科技服务有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using BodhiCRM.Common;
using BodhiCRM.Model;
namespace BodhiCRM.BLL
{
	/// <summary>
	/// 病患基本资料
	/// </summary>
	public partial class OUTPATIENT
	{
		private readonly BodhiCRM.DAL.OUTPATIENT dal;
		public OUTPATIENT()
		{
            dal = new DAL.OUTPATIENT();
        }
        public OUTPATIENT(string conString)
        {
            dal = new DAL.OUTPATIENT(conString);
        }
		#region  BasicMethod
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

