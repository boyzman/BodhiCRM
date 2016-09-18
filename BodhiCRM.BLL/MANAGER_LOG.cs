/**  
* MANAGER_LOG.cs
*
* 功 能： N/A
* 类 名： MANAGER_LOG
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/24 18:02:49   N/A    初版
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
	/// 管理日志表
	/// </summary>
	public partial class MANAGER_LOG
	{
		private readonly BodhiCRM.DAL.MANAGER_LOG dal=new BodhiCRM.DAL.MANAGER_LOG();
		public MANAGER_LOG()
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
		public bool Add(BodhiCRM.Model.MANAGER_LOG model)
		{
			return dal.Add(model);
		}
        /// <summary>
        /// 增加管理日志
        /// </summary>
        /// <param name="用户id"></param>
        /// <param name="用户名"></param>
        /// <param name="操作类型"></param>
        /// <param name="备注"></param>
        /// <returns></returns>
        public bool Add(int user_id, string hospital_code,string user_name, string action_type, string remark, string logbeforeparam, string logafterparam)
        {
            Model.MANAGER_LOG manager_log_model = new Model.MANAGER_LOG();
            manager_log_model.HOSPITAL_CODE = hospital_code;
            manager_log_model.USER_ID = user_id;
            manager_log_model.USER_NAME = user_name;
            manager_log_model.ACTION_TYPE = action_type;
            manager_log_model.REMARK = remark;
            manager_log_model.USER_IP = DTRequest.GetIP();
            manager_log_model.BEFORE_PARAM = logbeforeparam;
            manager_log_model.AFTER_PARAM = logafterparam;
            manager_log_model.ADD_TIME = DateTime.Now;
            return dal.Add(manager_log_model);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BodhiCRM.Model.MANAGER_LOG model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
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
		public BodhiCRM.Model.MANAGER_LOG GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BodhiCRM.Model.MANAGER_LOG GetModelByCache(int ID)
		{
			
			string CacheKey = "MANAGER_LOGModel-" + ID;
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
			return (BodhiCRM.Model.MANAGER_LOG)objModel;
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
		public List<BodhiCRM.Model.MANAGER_LOG> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BodhiCRM.Model.MANAGER_LOG> DataTableToList(DataTable dt)
		{
			List<BodhiCRM.Model.MANAGER_LOG> modelList = new List<BodhiCRM.Model.MANAGER_LOG>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BodhiCRM.Model.MANAGER_LOG model;
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// 删除7天前的日志数据
        /// </summary>
        public int Delete_Before(int dayCount)
        {
            return dal.Delete_Before(dayCount);
        }
        /// <summary>
        /// 根据用户名返回上一次登录记录
        /// </summary>
        public Model.MANAGER_LOG GetModel(string user_name, int top_num, string action_type)
        {
            return dal.GetModel(user_name, top_num, action_type);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

