/**  
* SMS_TEMPLATE.cs
*
* 功 能： N/A
* 类 名： SMS_TEMPLATE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/12 9:53:20   N/A    初版
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
	/// 数据访问类:SMS_TEMPLATE
	/// </summary>
	public partial class SMS_TEMPLATE
	{
		public SMS_TEMPLATE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_SMS_TEMPLATE");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.SMS_TEMPLATE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_SMS_TEMPLATE(");
			strSql.Append("ID,TITLE,CALL_INDEX,CONTENT,IS_SYS,STATUS)");
			strSql.Append(" values (");
            strSql.Append("SEQ_TB_SMS_TEMPLATE.nextval,:TITLE,:CALL_INDEX,:CONTENT,:IS_SYS,:STATUS)");
			OracleParameter[] parameters = {
					
					new OracleParameter(":TITLE", OracleType.VarChar,100),
					new OracleParameter(":CALL_INDEX", OracleType.VarChar,50),
					new OracleParameter(":CONTENT", OracleType.VarChar,500),
					new OracleParameter(":IS_SYS", OracleType.VarChar,1),
					new OracleParameter(":STATUS", OracleType.VarChar,1)};
			
			parameters[0].Value = model.TITLE;
			parameters[1].Value = model.CALL_INDEX;
			parameters[2].Value = model.CONTENT;
			parameters[3].Value = model.IS_SYS;
			parameters[4].Value = model.STATUS;

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
		public bool Update(BodhiCRM.Model.SMS_TEMPLATE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_SMS_TEMPLATE set ");
			strSql.Append("TITLE=:TITLE,");
			strSql.Append("CALL_INDEX=:CALL_INDEX,");
			strSql.Append("CONTENT=:CONTENT,");
			strSql.Append("IS_SYS=:IS_SYS,");
			strSql.Append("STATUS=:STATUS");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":TITLE", OracleType.VarChar,100),
					new OracleParameter(":CALL_INDEX", OracleType.VarChar,50),
					new OracleParameter(":CONTENT", OracleType.VarChar,500),
					new OracleParameter(":IS_SYS", OracleType.VarChar,1),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":ID", OracleType.Number,4)};
			parameters[0].Value = model.TITLE;
			parameters[1].Value = model.CALL_INDEX;
			parameters[2].Value = model.CONTENT;
			parameters[3].Value = model.IS_SYS;
			parameters[4].Value = model.STATUS;
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
			strSql.Append("delete from TB_SMS_TEMPLATE ");
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
			strSql.Append("delete from TB_SMS_TEMPLATE ");
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
		public BodhiCRM.Model.SMS_TEMPLATE GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,TITLE,CALL_INDEX,CONTENT,IS_SYS,STATUS from TB_SMS_TEMPLATE ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.SMS_TEMPLATE model=new BodhiCRM.Model.SMS_TEMPLATE();
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
        public BodhiCRM.Model.SMS_TEMPLATE GetModelByCode(string call_index)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TITLE,CALL_INDEX,CONTENT,IS_SYS,STATUS from TB_SMS_TEMPLATE ");
            strSql.Append(" where CALL_INDEX=:CALL_INDEX ");
            OracleParameter[] parameters = {
					new OracleParameter(":CALL_INDEX", OracleType.VarChar,50)			};
            parameters[0].Value = call_index;

            BodhiCRM.Model.SMS_TEMPLATE model = new BodhiCRM.Model.SMS_TEMPLATE();
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
		public BodhiCRM.Model.SMS_TEMPLATE DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.SMS_TEMPLATE model=new BodhiCRM.Model.SMS_TEMPLATE();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["TITLE"]!=null)
				{
					model.TITLE=row["TITLE"].ToString();
				}
				if(row["CALL_INDEX"]!=null)
				{
					model.CALL_INDEX=row["CALL_INDEX"].ToString();
				}
				if(row["CONTENT"]!=null)
				{
					model.CONTENT=row["CONTENT"].ToString();
				}
				if(row["IS_SYS"]!=null)
				{
					model.IS_SYS=row["IS_SYS"].ToString();
				}
				if(row["STATUS"]!=null)
				{
					model.STATUS=row["STATUS"].ToString();
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
			strSql.Append("select ID,TITLE,CALL_INDEX,CONTENT,IS_SYS,STATUS ");
			strSql.Append(" FROM TB_SMS_TEMPLATE ");
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
			strSql.Append("select count(1) FROM TB_SMS_TEMPLATE ");
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
			strSql.Append(")AS Row, T.*  from TB_SMS_TEMPLATE T ");
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
			parameters[0].Value = "TB_SMS_TEMPLATE";
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
            strSql.Append("select ID,TITLE,CALL_INDEX,CONTENT,IS_SYS,STATUS from TB_SMS_TEMPLATE ");

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

