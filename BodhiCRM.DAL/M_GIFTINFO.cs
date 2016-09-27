/**  
* M_GIFTINFO.cs
*
* 功 能： N/A
* 类 名： M_GIFTINFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/26 16:44:56   N/A    初版
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
	/// 数据访问类:M_GIFTINFO
	/// </summary>
	public partial class M_GIFTINFO
	{
		public M_GIFTINFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_M_GIFTINFO");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.M_GIFTINFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_M_GIFTINFO(");
			strSql.Append("ID,HOSPITAL_CODE,INFO_TITLE,GIFT_NAME,CUR_TIME,GET_TIME,END_TIME,STATUS,REMARK)");
			strSql.Append(" values (");
			strSql.Append("SEQ_TB_M_GIFTINFO.nextval,:HOSPITAL_CODE,:INFO_TITLE,:GIFT_NAME,:CUR_TIME,:GET_TIME,:END_TIME,:STATUS,:REMARK)");
			OracleParameter[] parameters = {
					//new OracleParameter(":ID", OracleType.Number,4),
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":INFO_TITLE", OracleType.VarChar,200),
					new OracleParameter(":GIFT_NAME", OracleType.VarChar,200),
					new OracleParameter(":CUR_TIME", OracleType.VarChar,20),
					new OracleParameter(":GET_TIME", OracleType.VarChar,20),
					new OracleParameter(":END_TIME", OracleType.VarChar,20),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,500)};
			//parameters[0].Value = model.ID;
			parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.INFO_TITLE;
			parameters[2].Value = model.GIFT_NAME;
			parameters[3].Value = model.CUR_TIME;
			parameters[4].Value = model.GET_TIME;
			parameters[5].Value = model.END_TIME;
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
		public bool Update(BodhiCRM.Model.M_GIFTINFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_M_GIFTINFO set ");
			strSql.Append("HOSPITAL_CODE=:HOSPITAL_CODE,");
			strSql.Append("INFO_TITLE=:INFO_TITLE,");
			strSql.Append("GIFT_NAME=:GIFT_NAME,");
			strSql.Append("CUR_TIME=:CUR_TIME,");
			strSql.Append("GET_TIME=:GET_TIME,");
			strSql.Append("END_TIME=:END_TIME,");
			strSql.Append("STATUS=:STATUS,");
			strSql.Append("REMARK=:REMARK");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":INFO_TITLE", OracleType.VarChar,200),
					new OracleParameter(":GIFT_NAME", OracleType.VarChar,200),
					new OracleParameter(":CUR_TIME", OracleType.VarChar,20),
					new OracleParameter(":GET_TIME", OracleType.VarChar,20),
					new OracleParameter(":END_TIME", OracleType.VarChar,20),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,500),
					new OracleParameter(":ID", OracleType.Number,4)};
			parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.INFO_TITLE;
			parameters[2].Value = model.GIFT_NAME;
			parameters[3].Value = model.CUR_TIME;
			parameters[4].Value = model.GET_TIME;
			parameters[5].Value = model.END_TIME;
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
			strSql.Append("delete from TB_M_GIFTINFO ");
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
			strSql.Append("delete from TB_M_GIFTINFO ");
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
		public BodhiCRM.Model.M_GIFTINFO GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,HOSPITAL_CODE,INFO_TITLE,GIFT_NAME,CUR_TIME,GET_TIME,END_TIME,STATUS,REMARK from TB_M_GIFTINFO ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.M_GIFTINFO model=new BodhiCRM.Model.M_GIFTINFO();
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
		public BodhiCRM.Model.M_GIFTINFO DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.M_GIFTINFO model=new BodhiCRM.Model.M_GIFTINFO();
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
				if(row["INFO_TITLE"]!=null)
				{
					model.INFO_TITLE=row["INFO_TITLE"].ToString();
				}
				if(row["GIFT_NAME"]!=null)
				{
					model.GIFT_NAME=row["GIFT_NAME"].ToString();
				}
				if(row["CUR_TIME"]!=null)
				{
					model.CUR_TIME=row["CUR_TIME"].ToString();
				}
				if(row["GET_TIME"]!=null)
				{
					model.GET_TIME=row["GET_TIME"].ToString();
				}
				if(row["END_TIME"]!=null)
				{
					model.END_TIME=row["END_TIME"].ToString();
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
			strSql.Append("select ID,HOSPITAL_CODE,INFO_TITLE,GIFT_NAME,CUR_TIME,GET_TIME,END_TIME,STATUS,REMARK ");
			strSql.Append(" FROM TB_M_GIFTINFO ");
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
			strSql.Append("select count(1) FROM TB_M_GIFTINFO ");
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
			strSql.Append(")AS Row, T.*  from TB_M_GIFTINFO T ");
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
			parameters[0].Value = "TB_M_GIFTINFO";
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

