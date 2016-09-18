/**  
* VISIT_DETAIL.cs
*
* 功 能： N/A
* 类 名： VISIT_DETAIL
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/6 10:53:42   N/A    初版
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
	/// 数据访问类:VISIT_DETAIL
	/// </summary>
	public partial class VISIT_DETAIL
	{
		public VISIT_DETAIL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_VISIT_DETAIL");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.VISIT_DETAIL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_VISIT_DETAIL(");
			strSql.Append("ID,VISIT_ID,VISIT_DT,VISIT_DETAIL_STATUS,VISIT_USER_ID,VISIT_NEXTDT,REMARK)");
			strSql.Append(" values (");
			strSql.Append("SEQ_TB_VISIT_DETAIL.nextval,:VISIT_ID,:VISIT_DT,:VISIT_DETAIL_STATUS,:VISIT_USER_ID,:VISIT_NEXTDT,:REMARK)");
			OracleParameter[] parameters = {
					new OracleParameter(":VISIT_ID", OracleType.Number,4),
					new OracleParameter(":VISIT_DT", OracleType.VarChar,20),
					new OracleParameter(":VISIT_DETAIL_STATUS", OracleType.VarChar,20),
					new OracleParameter(":VISIT_USER_ID", OracleType.Number,4),
					new OracleParameter(":VISIT_NEXTDT", OracleType.VarChar,20),
					new OracleParameter(":REMARK", OracleType.VarChar,500)};
			
			parameters[0].Value = model.VISIT_ID;
			parameters[1].Value = model.VISIT_DT;
			parameters[2].Value = model.VISIT_DETAIL_STATUS;
			parameters[3].Value = model.VISIT_USER_ID;
			parameters[4].Value = model.VISIT_NEXTDT;

			parameters[5].Value = model.REMARK;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(BodhiCRM.Model.VISIT_DETAIL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_VISIT_DETAIL set ");
			//strSql.Append("VISIT_ID=:VISIT_ID,");
			strSql.Append("VISIT_DT=:VISIT_DT,");
			strSql.Append("VISIT_DETAIL_STATUS=:VISIT_DETAIL_STATUS,");
			strSql.Append("VISIT_USER_ID=:VISIT_USER_ID,");
			strSql.Append("VISIT_NEXTDT=:VISIT_NEXTDT,");
			//strSql.Append("ADD_TIME=:ADD_TIME,");
			strSql.Append("REMARK=:REMARK");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					//new OracleParameter(":VISIT_ID", OracleType.Number,4),
					new OracleParameter(":VISIT_DT", OracleType.VarChar,20),
					new OracleParameter(":VISIT_DETAIL_STATUS", OracleType.VarChar,20),
					new OracleParameter(":VISIT_USER_ID", OracleType.Number,4),
					new OracleParameter(":VISIT_NEXTDT", OracleType.VarChar,20),
					//new OracleParameter(":ADD_TIME", OracleType.DateTime),
					new OracleParameter(":REMARK", OracleType.VarChar,500),
					new OracleParameter(":ID", OracleType.Number,4)};
			//parameters[0].Value = model.VISIT_ID;
			parameters[0].Value = model.VISIT_DT;
			parameters[1].Value = model.VISIT_DETAIL_STATUS;
			parameters[2].Value = model.VISIT_USER_ID;
			parameters[3].Value = model.VISIT_NEXTDT;
			//parameters[5].Value = model.ADD_TIME;
			parameters[4].Value = model.REMARK;
			parameters[5].Value = model.ID;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TB_VISIT_DETAIL ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TB_VISIT_DETAIL ");
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
		public BodhiCRM.Model.VISIT_DETAIL GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,VISIT_ID,VISIT_DT,VISIT_DETAIL_STATUS,VISIT_USER_ID,VISIT_NEXTDT,ADD_TIME,REMARK from TB_VISIT_DETAIL ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.VISIT_DETAIL model=new BodhiCRM.Model.VISIT_DETAIL();
			DataSet ds=DbHelperOra.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public BodhiCRM.Model.VISIT_DETAIL DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.VISIT_DETAIL model=new BodhiCRM.Model.VISIT_DETAIL();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["VISIT_ID"]!=null && row["VISIT_ID"].ToString()!="")
				{
					model.VISIT_ID=decimal.Parse(row["VISIT_ID"].ToString());
				}
				if(row["VISIT_DT"]!=null)
				{
					model.VISIT_DT=row["VISIT_DT"].ToString();
				}
				if(row["VISIT_DETAIL_STATUS"]!=null)
				{
					model.VISIT_DETAIL_STATUS=row["VISIT_DETAIL_STATUS"].ToString();
				}
				if(row["VISIT_USER_ID"]!=null && row["VISIT_USER_ID"].ToString()!="")
				{
					model.VISIT_USER_ID=decimal.Parse(row["VISIT_USER_ID"].ToString());
				}
				if(row["VISIT_NEXTDT"]!=null)
				{
					model.VISIT_NEXTDT=row["VISIT_NEXTDT"].ToString();
				}
				if(row["ADD_TIME"]!=null && row["ADD_TIME"].ToString()!="")
				{
					model.ADD_TIME=DateTime.Parse(row["ADD_TIME"].ToString());
				}
				if(row["REMARK"]!=null)
				{
					model.REMARK=row["REMARK"].ToString();
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
			strSql.Append("select ID,VISIT_ID,VISIT_DT,VISIT_DETAIL_STATUS,VISIT_USER_ID,VISIT_NEXTDT,ADD_TIME,REMARK ");
			strSql.Append(" FROM TB_VISIT_DETAIL ");
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
			strSql.Append("select count(1) FROM TB_VISIT_DETAIL ");
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
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from TB_VISIT_DETAIL T ");
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
			parameters[0].Value = "TB_VISIT_DETAIL";
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
            strSql.Append("select ID,VISIT_ID,VISIT_DT,VISIT_DETAIL_STATUS,VISIT_USER_ID,VISIT_NEXTDT,ADD_TIME,REMARK from TB_BIRTHCARE");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

