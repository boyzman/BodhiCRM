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
using System.Text;
using System.Data.OracleClient;
using BodhiCRM.DBUtility;//Please add references
namespace BodhiCRM.DAL
{
	/// <summary>
	/// 数据访问类:HOSPITAL
	/// </summary>
	public partial class HOSPITAL
	{
		public HOSPITAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string HOSPITAL_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_HOSPITAL");
			strSql.Append(" where HOSPITAL_CODE=:HOSPITAL_CODE ");
			OracleParameter[] parameters = {
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3)			};
			parameters[0].Value = HOSPITAL_CODE;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.HOSPITAL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_HOSPITAL(");
			strSql.Append("HOSPITAL_CODE,HOSPITAL_NAME,ABBREVIATION,ADDRESS,HOSPITAL_PHONE,FEE_LICENSE,ACTIVE,HOSPITAL_NAME_EN)");
			strSql.Append(" values (");
			strSql.Append(":HOSPITAL_CODE,:HOSPITAL_NAME,:ABBREVIATION,:ADDRESS,:HOSPITAL_PHONE,:FEE_LICENSE,:ACTIVE,:HOSPITAL_NAME_EN)");
			OracleParameter[] parameters = {
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":HOSPITAL_NAME", OracleType.VarChar,60),
					new OracleParameter(":ABBREVIATION", OracleType.VarChar,30),
					new OracleParameter(":ADDRESS", OracleType.VarChar,300),
					new OracleParameter(":HOSPITAL_PHONE", OracleType.VarChar,20),
					new OracleParameter(":FEE_LICENSE", OracleType.VarChar,10),
					new OracleParameter(":ACTIVE", OracleType.VarChar,1),
					new OracleParameter(":HOSPITAL_NAME_EN", OracleType.VarChar,100)};
			parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.HOSPITAL_NAME;
			parameters[2].Value = model.ABBREVIATION;
			parameters[3].Value = model.ADDRESS;
			parameters[4].Value = model.HOSPITAL_PHONE;
			parameters[5].Value = model.FEE_LICENSE;
			parameters[6].Value = model.ACTIVE;
			parameters[7].Value = model.HOSPITAL_NAME_EN;

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
		public bool Update(BodhiCRM.Model.HOSPITAL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_HOSPITAL set ");
			strSql.Append("HOSPITAL_NAME=:HOSPITAL_NAME,");
			strSql.Append("ABBREVIATION=:ABBREVIATION,");
			strSql.Append("ADDRESS=:ADDRESS,");
			strSql.Append("HOSPITAL_PHONE=:HOSPITAL_PHONE,");
			strSql.Append("FEE_LICENSE=:FEE_LICENSE,");
			strSql.Append("ACTIVE=:ACTIVE,");
			strSql.Append("HOSPITAL_NAME_EN=:HOSPITAL_NAME_EN");
			strSql.Append(" where HOSPITAL_CODE=:HOSPITAL_CODE ");
			OracleParameter[] parameters = {
					new OracleParameter(":HOSPITAL_NAME", OracleType.VarChar,60),
					new OracleParameter(":ABBREVIATION", OracleType.VarChar,30),
					new OracleParameter(":ADDRESS", OracleType.VarChar,300),
					new OracleParameter(":HOSPITAL_PHONE", OracleType.VarChar,20),
					new OracleParameter(":FEE_LICENSE", OracleType.VarChar,10),
					new OracleParameter(":ACTIVE", OracleType.VarChar,1),
					new OracleParameter(":HOSPITAL_NAME_EN", OracleType.VarChar,100),
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3)};
			parameters[0].Value = model.HOSPITAL_NAME;
			parameters[1].Value = model.ABBREVIATION;
			parameters[2].Value = model.ADDRESS;
			parameters[3].Value = model.HOSPITAL_PHONE;
			parameters[4].Value = model.FEE_LICENSE;
			parameters[5].Value = model.ACTIVE;
			parameters[6].Value = model.HOSPITAL_NAME_EN;
			parameters[7].Value = model.HOSPITAL_CODE;

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
		public bool Delete(string HOSPITAL_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TB_HOSPITAL ");
			strSql.Append(" where HOSPITAL_CODE=:HOSPITAL_CODE ");
			OracleParameter[] parameters = {
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3)			};
			parameters[0].Value = HOSPITAL_CODE;

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
		public bool DeleteList(string HOSPITAL_CODElist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TB_HOSPITAL ");
			strSql.Append(" where HOSPITAL_CODE in ("+HOSPITAL_CODElist + ")  ");
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
		public BodhiCRM.Model.HOSPITAL GetModel(string HOSPITAL_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select HOSPITAL_CODE,HOSPITAL_NAME,ABBREVIATION,ADDRESS,HOSPITAL_PHONE,FEE_LICENSE,ACTIVE,HOSPITAL_NAME_EN from TB_HOSPITAL ");
			strSql.Append(" where HOSPITAL_CODE=:HOSPITAL_CODE ");
			OracleParameter[] parameters = {
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3)			};
			parameters[0].Value = HOSPITAL_CODE;

			BodhiCRM.Model.HOSPITAL model=new BodhiCRM.Model.HOSPITAL();
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
		public BodhiCRM.Model.HOSPITAL DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.HOSPITAL model=new BodhiCRM.Model.HOSPITAL();
			if (row != null)
			{
				if(row["HOSPITAL_CODE"]!=null)
				{
					model.HOSPITAL_CODE=row["HOSPITAL_CODE"].ToString();
				}
				if(row["HOSPITAL_NAME"]!=null)
				{
					model.HOSPITAL_NAME=row["HOSPITAL_NAME"].ToString();
				}
				if(row["ABBREVIATION"]!=null)
				{
					model.ABBREVIATION=row["ABBREVIATION"].ToString();
				}
				if(row["ADDRESS"]!=null)
				{
					model.ADDRESS=row["ADDRESS"].ToString();
				}
				if(row["HOSPITAL_PHONE"]!=null)
				{
					model.HOSPITAL_PHONE=row["HOSPITAL_PHONE"].ToString();
				}
				if(row["FEE_LICENSE"]!=null)
				{
					model.FEE_LICENSE=row["FEE_LICENSE"].ToString();
				}
				if(row["ACTIVE"]!=null)
				{
					model.ACTIVE=row["ACTIVE"].ToString();
				}
				if(row["HOSPITAL_NAME_EN"]!=null)
				{
					model.HOSPITAL_NAME_EN=row["HOSPITAL_NAME_EN"].ToString();
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
			strSql.Append("select HOSPITAL_CODE,HOSPITAL_NAME,ABBREVIATION,ADDRESS,HOSPITAL_PHONE,FEE_LICENSE,ACTIVE,HOSPITAL_NAME_EN ");
			strSql.Append(" FROM TB_HOSPITAL ");
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
			strSql.Append("select count(1) FROM TB_HOSPITAL ");
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
				strSql.Append("order by T.HOSPITAL_CODE desc");
			}
			strSql.Append(")AS Row, T.*  from TB_HOSPITAL T ");
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
			parameters[0].Value = "TB_HOSPITAL";
			parameters[1].Value = "HOSPITAL_CODE";
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

