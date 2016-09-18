/**  
* MANAGER.cs
*
* 功 能： N/A
* 类 名： MANAGER
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
	/// 管理员信息表
	/// </summary>
	public partial class MANAGER
	{
		private readonly BodhiCRM.DAL.MANAGER dal=new BodhiCRM.DAL.MANAGER();
		public MANAGER()
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
        /// 查询用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            return dal.Exists(user_name);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.MANAGER model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BodhiCRM.Model.MANAGER model)
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
            return dal.DeleteList(BodhiCRM.Common.PageValidate.SafeLongFilter(IDlist, 0));
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BodhiCRM.Model.MANAGER GetModel(decimal ID)
		{
			
			return dal.GetModel(ID);
		}
        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.MANAGER GetModel(string user_name, string password,string hospital_code)
        {
            return dal.GetModel(user_name, password,hospital_code);
        }
        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.MANAGER GetModel(string user_name, string password,string hospital_code, bool is_encrypt)
        {
            //检查一下是否需要加密
            if (is_encrypt)
            {
                //先取得该用户的随机密钥
                string salt = dal.GetSalt(user_name);
                if (string.IsNullOrEmpty(salt))
                {
                    return null;
                }
                //把明文进行加密重新赋值
                password = DESEncrypt.Encrypt(password, salt);

                //password = DESEncrypt.Encrypt(password);
            }
            return dal.GetModel(user_name, password,hospital_code);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BodhiCRM.Model.MANAGER GetModelByCache(decimal ID)
		{
			
			string CacheKey = "MANAGERModel-" + ID;
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
			return (BodhiCRM.Model.MANAGER)objModel;
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
		public List<BodhiCRM.Model.MANAGER> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BodhiCRM.Model.MANAGER> DataTableToList(DataTable dt)
		{
			List<BodhiCRM.Model.MANAGER> modelList = new List<BodhiCRM.Model.MANAGER>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BodhiCRM.Model.MANAGER model;
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
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

