/**  
* MANAGER_ROLE.cs
*
* 功 能： N/A
* 类 名： MANAGER_ROLE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/24 18:02:50   N/A    初版
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
	/// 管理角色表
	/// </summary>
	public partial class MANAGER_ROLE
	{
		private readonly BodhiCRM.DAL.MANAGER_ROLE dal=new BodhiCRM.DAL.MANAGER_ROLE();
		public MANAGER_ROLE()
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
		/// 增加一条数据
		/// </summary>
		public int Add(BodhiCRM.Model.MANAGER_ROLE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BodhiCRM.Model.MANAGER_ROLE model)
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
		public BodhiCRM.Model.MANAGER_ROLE GetModel(decimal ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BodhiCRM.Model.MANAGER_ROLE GetModelByCache(decimal ID)
		{
			
			string CacheKey = "MANAGER_ROLEModel-" + ID;
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
			return (BodhiCRM.Model.MANAGER_ROLE)objModel;
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
		public List<BodhiCRM.Model.MANAGER_ROLE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BodhiCRM.Model.MANAGER_ROLE> DataTableToList(DataTable dt)
		{
			List<BodhiCRM.Model.MANAGER_ROLE> modelList = new List<BodhiCRM.Model.MANAGER_ROLE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BodhiCRM.Model.MANAGER_ROLE model;
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
        /// 返回角色名称
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }
        /// <summary>
        /// 检查是否有权限
        /// </summary>
        public bool Exists(decimal role_id, string nav_name, string action_type)
        {
            Model.MANAGER_ROLE model = dal.GetModel(role_id);
            if (model != null)
            {
                if (model.ROLE_TYPE == 1)
                {
                    return true;
                }
                Model.MANAGER_ROLE_VALUE modelt = model.manager_role_values.Find(p => p.NAV_NAME == nav_name && p.ACTION_TYPE == action_type);
                if (modelt != null)
                {
                    return true;
                }
            }
            return false;
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

