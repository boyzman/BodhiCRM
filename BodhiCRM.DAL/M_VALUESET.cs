/**  
* M_VALUESET.cs
*
* 功 能： N/A
* 类 名： M_VALUESET
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/26 16:44:42   N/A    初版
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
using BodhiCRM.DBUtility;//Please add references
namespace BodhiCRM.DAL
{
	/// <summary>
	/// 数据访问类:M_VALUESET
	/// </summary>
	public partial class M_VALUESET
	{
		public M_VALUESET()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_M_VALUESET");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.M_VALUESET model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_M_VALUESET(");
			strSql.Append("ID,HOSPITAL_CODE,TITLE,V_TYPE,CUR_VALUE,MIN_VALUE,MAX_VALUE,STATUS,REMARK)");
			strSql.Append(" values (");
			strSql.Append("SEQ_TB_M_VALUESET.nextval,:HOSPITAL_CODE,:TITLE,:V_TYPE,:CUR_VALUE,:MIN_VALUE,:MAX_VALUE,:STATUS,:REMARK)");
			OracleParameter[] parameters = {
					
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":TITLE", OracleType.VarChar,200),
					new OracleParameter(":V_TYPE", OracleType.VarChar,10),
					new OracleParameter(":CUR_VALUE", OracleType.VarChar,20),
					new OracleParameter(":MIN_VALUE", OracleType.VarChar,20),
					new OracleParameter(":MAX_VALUE", OracleType.VarChar,20),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,500)};
			
			parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.TITLE;
			parameters[2].Value = model.V_TYPE;
			parameters[3].Value = model.CUR_VALUE;
			parameters[4].Value = model.MIN_VALUE;
			parameters[5].Value = model.MAX_VALUE;
			parameters[6].Value = model.STATUS;
			parameters[7].Value = model.REMARK;

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
		public bool Update(BodhiCRM.Model.M_VALUESET model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_M_VALUESET set ");
			strSql.Append("HOSPITAL_CODE=:HOSPITAL_CODE,");
			strSql.Append("TITLE=:TITLE,");
			strSql.Append("V_TYPE=:V_TYPE,");
			strSql.Append("CUR_VALUE=:CUR_VALUE,");
			strSql.Append("MIN_VALUE=:MIN_VALUE,");
			strSql.Append("MAX_VALUE=:MAX_VALUE,");
			strSql.Append("STATUS=:STATUS,");
			strSql.Append("REMARK=:REMARK");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":TITLE", OracleType.VarChar,200),
					new OracleParameter(":V_TYPE", OracleType.VarChar,10),
					new OracleParameter(":CUR_VALUE", OracleType.VarChar,20),
					new OracleParameter(":MIN_VALUE", OracleType.VarChar,20),
					new OracleParameter(":MAX_VALUE", OracleType.VarChar,20),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,500),
					new OracleParameter(":ID", OracleType.Number,4)};
			parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.TITLE;
			parameters[2].Value = model.V_TYPE;
			parameters[3].Value = model.CUR_VALUE;
			parameters[4].Value = model.MIN_VALUE;
			parameters[5].Value = model.MAX_VALUE;
			parameters[6].Value = model.STATUS;
			parameters[7].Value = model.REMARK;
			parameters[8].Value = model.ID;

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
			strSql.Append("delete from TB_M_VALUESET ");
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
			strSql.Append("delete from TB_M_VALUESET ");
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
		public BodhiCRM.Model.M_VALUESET GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,HOSPITAL_CODE,TITLE,V_TYPE,CUR_VALUE,MIN_VALUE,MAX_VALUE,STATUS,REMARK from TB_M_VALUESET ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.M_VALUESET model=new BodhiCRM.Model.M_VALUESET();
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
		public BodhiCRM.Model.M_VALUESET DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.M_VALUESET model=new BodhiCRM.Model.M_VALUESET();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["HOSPITAL_CODE"]!=null)
				{
					model.HOSPITAL_CODE=row["HOSPITAL_CODE"].ToString();
				}
				if(row["TITLE"]!=null)
				{
					model.TITLE=row["TITLE"].ToString();
				}
				if(row["V_TYPE"]!=null)
				{
					model.V_TYPE=row["V_TYPE"].ToString();
				}
				if(row["CUR_VALUE"]!=null)
				{
					model.CUR_VALUE=row["CUR_VALUE"].ToString();
				}
				if(row["MIN_VALUE"]!=null)
				{
					model.MIN_VALUE=row["MIN_VALUE"].ToString();
				}
				if(row["MAX_VALUE"]!=null)
				{
					model.MAX_VALUE=row["MAX_VALUE"].ToString();
				}
				if(row["STATUS"]!=null)
				{
					model.STATUS=row["STATUS"].ToString();
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
			strSql.Append("select ID,HOSPITAL_CODE,TITLE,V_TYPE,CUR_VALUE,MIN_VALUE,MAX_VALUE,STATUS,REMARK ");
			strSql.Append(" FROM TB_M_VALUESET ");
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
			strSql.Append("select count(1) FROM TB_M_VALUESET ");
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
			strSql.Append(")AS Row, T.*  from TB_M_VALUESET T ");
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
			parameters[0].Value = "TB_M_VALUESET";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

