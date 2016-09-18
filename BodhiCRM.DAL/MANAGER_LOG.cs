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
using System.Text;
using System.Data.OracleClient;
using BodhiCRM.DBUtility;
using BodhiCRM.Common;//Please add references
namespace BodhiCRM.DAL
{
	/// <summary>
	/// 数据访问类:MANAGER_LOG
	/// </summary>
	public partial class MANAGER_LOG
	{
		public MANAGER_LOG()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			int rowsAffected;
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			int result= DbHelperOra.RunProcedure("TB_MANAGER_LOG_Exists",parameters,out rowsAffected);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.MANAGER_LOG model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_MANAGER_LOG(");
            strSql.Append("ID,HOSPITAL_CODE,USER_ID,USER_NAME,ACTION_TYPE,REMARK,USER_IP,ADD_TIME,BEFORE_PARAM,AFTER_PARAM)");
            strSql.Append(" values (");
            strSql.Append("SEQ_TB_MANAGER_LOG.nextval,:HOSPITAL_CODE,:USER_ID,:USER_NAME,:ACTION_TYPE,:REMARK,:USER_IP,:ADD_TIME,:BEFORE_PARAM,:AFTER_PARAM)");
            OracleParameter[] parameters = {
                    new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":USER_ID", OracleType.Number,4),
					new OracleParameter(":USER_NAME", OracleType.VarChar,100),
					new OracleParameter(":ACTION_TYPE", OracleType.VarChar,100),
					new OracleParameter(":REMARK", OracleType.VarChar,255),
					new OracleParameter(":USER_IP", OracleType.VarChar,30),
					new OracleParameter(":ADD_TIME", OracleType.DateTime),
					new OracleParameter(":BEFORE_PARAM", OracleType.VarChar,1000),
					new OracleParameter(":AFTER_PARAM", OracleType.VarChar,1000)};
            parameters[0].Value = model.HOSPITAL_CODE;
            parameters[1].Value = model.USER_ID;
            parameters[2].Value = model.USER_NAME;
            parameters[3].Value = model.ACTION_TYPE;
            parameters[4].Value = model.REMARK;
            parameters[5].Value = model.USER_IP;
            parameters[6].Value = model.ADD_TIME;
            parameters[7].Value = model.BEFORE_PARAM;
            parameters[8].Value = model.AFTER_PARAM;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(BodhiCRM.Model.MANAGER_LOG model)
		{
			int rowsAffected=0;
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4),
                    new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":USER_ID", OracleType.Number,4),
					new OracleParameter(":USER_NAME", OracleType.VarChar,100),
					new OracleParameter(":ACTION_TYPE", OracleType.VarChar,100),
					new OracleParameter(":REMARK", OracleType.VarChar,255),
					new OracleParameter(":USER_IP", OracleType.VarChar,30),
					new OracleParameter(":ADD_TIME", OracleType.DateTime)};
			parameters[0].Value = model.ID;
            parameters[1].Value = model.HOSPITAL_CODE;
			parameters[2].Value = model.USER_ID;
			parameters[3].Value = model.USER_NAME;
			parameters[4].Value = model.ACTION_TYPE;
			parameters[5].Value = model.REMARK;
			parameters[6].Value = model.USER_IP;
			parameters[7].Value = model.ADD_TIME;

			DbHelperOra.RunProcedure("TB_MANAGER_LOG_Update",parameters,out rowsAffected);
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			int rowsAffected=0;
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			DbHelperOra.RunProcedure("TB_MANAGER_LOG_Delete",parameters,out rowsAffected);
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TB_MANAGER_LOG ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperOra.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BodhiCRM.Model.MANAGER_LOG GetModel(int ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,HOSPITAL_CODE,USER_ID,USER_NAME,ACTION_TYPE,REMARK,USER_IP,ADD_TIME,BEFORE_PARAM,AFTER_PARAM from TB_MANAGER_LOG ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;

            BodhiCRM.Model.MANAGER_LOG model = new BodhiCRM.Model.MANAGER_LOG();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BodhiCRM.Model.MANAGER_LOG DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.MANAGER_LOG model=new BodhiCRM.Model.MANAGER_LOG();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
                if (row["HOSPITAL_CODE"] != null && row["HOSPITAL_CODE"].ToString() != "")
                {
                    model.HOSPITAL_CODE = row["HOSPITAL_CODE"].ToString();
                }
				if(row["USER_ID"]!=null && row["USER_ID"].ToString()!="")
				{
					model.USER_ID=decimal.Parse(row["USER_ID"].ToString());
				}
				if(row["USER_NAME"]!=null)
				{
					model.USER_NAME=row["USER_NAME"].ToString();
				}
				if(row["ACTION_TYPE"]!=null)
				{
					model.ACTION_TYPE=row["ACTION_TYPE"].ToString();
				}
				if(row["REMARK"]!=null)
				{
					model.REMARK=row["REMARK"].ToString();
				}
				if(row["USER_IP"]!=null)
				{
					model.USER_IP=row["USER_IP"].ToString();
				}
				if(row["ADD_TIME"]!=null && row["ADD_TIME"].ToString()!="")
				{
					model.ADD_TIME=DateTime.Parse(row["ADD_TIME"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ID,HOSPITAL_CODE,USER_ID,USER_NAME,ACTION_TYPE,REMARK,USER_IP,ADD_TIME ");
			strSql.Append(" FROM TB_MANAGER_LOG ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TB_MANAGER_LOG ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            object obj = DbHelperOra.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT ID,HOSPITAL_CODE,USER_ID,USER_NAME,ACTION_TYPE,REMARK,USER_IP,ADD_TIME FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from TB_MANAGER_LOG T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOra.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":tblName", OracleType.VarChar, 255),
					new OracleParameter(":fldName", OracleType.VarChar, 255),
					new OracleParameter(":PageSize", OracleType.Number),
					new OracleParameter(":PageIndex", OracleType.Number),
					new OracleParameter(":IsReCount", OracleType.Clob),
					new OracleParameter(":OrderType", OracleType.Clob),
					new OracleParameter(":strWhere", OracleType.VarChar,1000),
					};
			parameters[0].Value = "TB_MANAGER_LOG";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,HOSPITAL_CODE,USER_ID,USER_NAME,ACTION_TYPE,REMARK,USER_IP,ADD_TIME FROM TB_MANAGER_LOG");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        ///// <summary>
        ///// 删除7天前的日志数据
        ///// </summary>
        public int Delete_Before(int dayCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_MANAGER_LOG ");
            strSql.Append(" where DATEDIFF('D', to_char(add_time,'yyyy-mm-dd hh24:mi:ss'), to_char(sysdate,'yyyy-mm-dd hh24:mi:ss')) > " + dayCount);

            return DbHelperOra.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据用户名返回上一次登录记录
        /// </summary>
        public Model.MANAGER_LOG GetModel(string user_name, int top_num, string action_type)
        {
            int rows = GetCount("user_name='" + user_name + "'");
            if (top_num == 1)
            {
                rows = 2;
            }
            if (rows > 1)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select id from (select id from TB_MANAGER_LOG");
                strSql.Append(" where rownum<" + (top_num+1) + " and user_name=:user_name and action_type=:action_type order by id desc) T ");
                strSql.Append(" where rownum<2 ");
                strSql.Append(" order by id asc");
                OracleParameter[] parameters = {
					new OracleParameter(":user_name", OracleType.VarChar,100),
                    new OracleParameter(":action_type", OracleType.VarChar,100)};
                parameters[0].Value = user_name;
                parameters[1].Value = action_type;

                object obj = DbHelperOra.GetSingle(strSql.ToString(), parameters);
                if (obj != null)
                {
                    return GetModel(Convert.ToInt32(obj));
                }
            }
            return null;
        }
        /// <summary>
        /// 返回数据数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from TB_MANAGER_LOG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperOra.GetSingle(strSql.ToString()));
        }
		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

