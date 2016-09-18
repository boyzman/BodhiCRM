/**  
* HOSPITAL.cs
*
* 功 能： N/A
* 类 名： HOSPITAL
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/31 13:49:31   N/A    初版
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
	/// 医院(诊所)信息
	/// </summary>
	public partial class HOSPITAL
	{
		private readonly BodhiCRM.DAL.HOSPITAL dal=new BodhiCRM.DAL.HOSPITAL();
		public HOSPITAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string HOSPITAL_CODE)
		{
			return dal.Exists(HOSPITAL_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.HOSPITAL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BodhiCRM.Model.HOSPITAL model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string HOSPITAL_CODE)
		{
			
			return dal.Delete(HOSPITAL_CODE);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string HOSPITAL_CODElist )
		{
			return dal.DeleteList(BodhiCRM.Common.PageValidate.SafeLongFilter(HOSPITAL_CODElist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BodhiCRM.Model.HOSPITAL GetModel(string HOSPITAL_CODE)
		{
			
			return dal.GetModel(HOSPITAL_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BodhiCRM.Model.HOSPITAL GetModelByCache(string HOSPITAL_CODE)
		{
			
			string CacheKey = "HOSPITALModel-" + HOSPITAL_CODE;
			object objModel = BodhiCRM.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(HOSPITAL_CODE);
					if (objModel != null)
					{
						int ModelCache = BodhiCRM.Common.ConfigHelper.GetConfigInt("ModelCache");
						BodhiCRM.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BodhiCRM.Model.HOSPITAL)objModel;
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
		public List<BodhiCRM.Model.HOSPITAL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BodhiCRM.Model.HOSPITAL> DataTableToList(DataTable dt)
		{
			List<BodhiCRM.Model.HOSPITAL> modelList = new List<BodhiCRM.Model.HOSPITAL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BodhiCRM.Model.HOSPITAL model;
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

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

