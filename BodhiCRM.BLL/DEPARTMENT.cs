/**  
* DEPARTMENT.cs
*
* 功 能： N/A
* 类 名： DEPARTMENT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/30 17:31:53   N/A    初版
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
	/// 部门信息表
	/// </summary>
	public partial class DEPARTMENT
	{
		private readonly BodhiCRM.DAL.DEPARTMENT dal=new BodhiCRM.DAL.DEPARTMENT();
		public DEPARTMENT()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			return dal.Exists(ID);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsLevel(string level)
        {
            return dal.ExistsLevel(level);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.DEPARTMENT model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BodhiCRM.Model.DEPARTMENT model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(BodhiCRM.Common.PageValidate.SafeLongFilter(IDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BodhiCRM.Model.DEPARTMENT GetModel(decimal ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BodhiCRM.Model.DEPARTMENT GetModelByCache(decimal ID)
		{
			
			string CacheKey = "DEPARTMENTModel-" + ID;
			object objModel = BodhiCRM.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = BodhiCRM.Common.ConfigHelper.GetConfigInt("ModelCache");
						BodhiCRM.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BodhiCRM.Model.DEPARTMENT)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList_DataTable(string DEPT_UPLEVEL, string HOSPITAL_CODE)
        {
            return dal.GetList_DataTable(DEPT_UPLEVEL,HOSPITAL_CODE);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BodhiCRM.Model.DEPARTMENT> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BodhiCRM.Model.DEPARTMENT> DataTableToList(DataTable dt)
		{
			List<BodhiCRM.Model.DEPARTMENT> modelList = new List<BodhiCRM.Model.DEPARTMENT>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BodhiCRM.Model.DEPARTMENT model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// 获取最大的部门level（从0000开始）
        /// </summary>
        public string GetMaxLevel(string strWhere)
        {
            return dal.GetMaxLevel(strWhere);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

