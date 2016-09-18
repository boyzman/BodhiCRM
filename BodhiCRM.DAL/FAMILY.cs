/**  
* FAMILY.cs
*
* 功 能： N/A
* 类 名： FAMILY
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/31 19:17:42   N/A    初版
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
	/// 数据访问类:FAMILY
	/// </summary>
	public partial class FAMILY
	{
		public FAMILY()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_FAMILY");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.FAMILY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_FAMILY(");
			strSql.Append("ID,PATIENT_SN,PATIENT_RELATION,CNAME,GENDER_ID,BIRTH_DATE,HEIGHT,WEIGHT,MOBILE_TEL,ID_CARD_CODE,CREATE_USER_ID,CREATE_TIME,STATUS,REMARK)");
			strSql.Append(" values (");
            strSql.Append("SEQ_TB_FAMILY.nextval,:PATIENT_SN,:PATIENT_RELATION,:CNAME,:GENDER_ID,:BIRTH_DATE,:HEIGHT,:WEIGHT,:MOBILE_TEL,:ID_CARD_CODE,:CREATE_USER_ID,:CREATE_TIME,:STATUS,:REMARK)");
			OracleParameter[] parameters = {
					
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10),
					new OracleParameter(":PATIENT_RELATION", OracleType.VarChar,10),
					new OracleParameter(":CNAME", OracleType.VarChar,60),
					
					new OracleParameter(":GENDER_ID", OracleType.Number,4),
					new OracleParameter(":BIRTH_DATE", OracleType.VarChar),
					new OracleParameter(":HEIGHT", OracleType.Number,6),
					new OracleParameter(":WEIGHT", OracleType.Number,6),
					new OracleParameter(":MOBILE_TEL", OracleType.VarChar,30),
					new OracleParameter(":ID_CARD_CODE", OracleType.VarChar,60),
					new OracleParameter(":CREATE_USER_ID", OracleType.Number,4),
					new OracleParameter(":CREATE_TIME", OracleType.DateTime),
					
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,1000)};
			
			parameters[0].Value = model.PATIENT_SN;
			parameters[1].Value = model.PATIENT_RELATION;
			parameters[2].Value = model.CNAME;
			
			parameters[3].Value = model.GENDER_ID;
			parameters[4].Value = model.BIRTH_DATE;
			parameters[5].Value = model.HEIGHT;
			parameters[6].Value = model.WEIGHT;
			parameters[7].Value = model.MOBILE_TEL;
			parameters[8].Value = model.ID_CARD_CODE;
			parameters[9].Value = model.CREATE_USER_ID;
			parameters[10].Value = model.CREATE_TIME;
			
			parameters[11].Value = model.STATUS;
			parameters[12].Value = model.REMARK;

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
		public bool Update(BodhiCRM.Model.FAMILY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_FAMILY set ");
			strSql.Append("PATIENT_SN=:PATIENT_SN,");
			strSql.Append("PATIENT_RELATION=:PATIENT_RELATION,");
			strSql.Append("CNAME=:CNAME,");
			strSql.Append("ENAME=:ENAME,");
			strSql.Append("GENDER_ID=:GENDER_ID,");
			strSql.Append("BIRTH_DATE=:BIRTH_DATE,");
			strSql.Append("HEIGHT=:HEIGHT,");
			strSql.Append("WEIGHT=:WEIGHT,");
			strSql.Append("MOBILE_TEL=:MOBILE_TEL,");
			strSql.Append("ID_CARD_CODE=:ID_CARD_CODE,");
			strSql.Append("CREATE_USER_ID=:CREATE_USER_ID,");
			strSql.Append("CREATE_TIME=:CREATE_TIME,");
			strSql.Append("MODIFIED_USER=:MODIFIED_USER,");
			strSql.Append("MODIFIED_TIME=:MODIFIED_TIME,");
			strSql.Append("STATUS=:STATUS,");
			strSql.Append("REMARK=:REMARK");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10),
					new OracleParameter(":PATIENT_RELATION", OracleType.VarChar,10),
					new OracleParameter(":CNAME", OracleType.VarChar,60),
					new OracleParameter(":ENAME", OracleType.VarChar,40),
					new OracleParameter(":GENDER_ID", OracleType.Number,4),
					new OracleParameter(":BIRTH_DATE", OracleType.VarChar),
					new OracleParameter(":HEIGHT", OracleType.Number,6),
					new OracleParameter(":WEIGHT", OracleType.Number,6),
					new OracleParameter(":MOBILE_TEL", OracleType.VarChar,30),
					new OracleParameter(":ID_CARD_CODE", OracleType.VarChar,60),
					new OracleParameter(":CREATE_USER_ID", OracleType.Number,4),
					new OracleParameter(":CREATE_TIME", OracleType.DateTime),
					new OracleParameter(":MODIFIED_USER", OracleType.Number,4),
					new OracleParameter(":MODIFIED_TIME", OracleType.DateTime),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,1000),
					new OracleParameter(":ID", OracleType.Number,4)};
			parameters[0].Value = model.PATIENT_SN;
			parameters[1].Value = model.PATIENT_RELATION;
			parameters[2].Value = model.CNAME;
			parameters[3].Value = model.ENAME;
			parameters[4].Value = model.GENDER_ID;
			parameters[5].Value = model.BIRTH_DATE;
			parameters[6].Value = model.HEIGHT;
			parameters[7].Value = model.WEIGHT;
			parameters[8].Value = model.MOBILE_TEL;
			parameters[9].Value = model.ID_CARD_CODE;
			parameters[10].Value = model.CREATE_USER_ID;
			parameters[11].Value = model.CREATE_TIME;
			parameters[12].Value = model.MODIFIED_USER;
			parameters[13].Value = model.MODIFIED_TIME;
			parameters[14].Value = model.STATUS;
			parameters[15].Value = model.REMARK;
			parameters[16].Value = model.ID;

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
			strSql.Append("delete from TB_FAMILY ");
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
			strSql.Append("delete from TB_FAMILY ");
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
		public BodhiCRM.Model.FAMILY GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,PATIENT_SN,PATIENT_RELATION,CNAME,ENAME,GENDER_ID,BIRTH_DATE,HEIGHT,WEIGHT,MOBILE_TEL,ID_CARD_CODE,CREATE_USER_ID,CREATE_TIME,MODIFIED_USER,MODIFIED_TIME,STATUS,REMARK from TB_FAMILY ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.FAMILY model=new BodhiCRM.Model.FAMILY();
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
		public BodhiCRM.Model.FAMILY DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.FAMILY model=new BodhiCRM.Model.FAMILY();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["PATIENT_SN"]!=null)
				{
					model.PATIENT_SN=row["PATIENT_SN"].ToString();
				}
				if(row["PATIENT_RELATION"]!=null)
				{
					model.PATIENT_RELATION=row["PATIENT_RELATION"].ToString();
				}
				if(row["CNAME"]!=null)
				{
					model.CNAME=row["CNAME"].ToString();
				}
				if(row["ENAME"]!=null)
				{
					model.ENAME=row["ENAME"].ToString();
				}
				if(row["GENDER_ID"]!=null && row["GENDER_ID"].ToString()!="")
				{
					model.GENDER_ID=decimal.Parse(row["GENDER_ID"].ToString());
				}
				if(row["BIRTH_DATE"]!=null && row["BIRTH_DATE"].ToString()!="")
				{
                    model.BIRTH_DATE = row["BIRTH_DATE"].ToString();
				}
				if(row["HEIGHT"]!=null && row["HEIGHT"].ToString()!="")
				{
					model.HEIGHT=decimal.Parse(row["HEIGHT"].ToString());
				}
				if(row["WEIGHT"]!=null && row["WEIGHT"].ToString()!="")
				{
					model.WEIGHT=decimal.Parse(row["WEIGHT"].ToString());
				}
				if(row["MOBILE_TEL"]!=null)
				{
					model.MOBILE_TEL=row["MOBILE_TEL"].ToString();
				}
				if(row["ID_CARD_CODE"]!=null)
				{
					model.ID_CARD_CODE=row["ID_CARD_CODE"].ToString();
				}
				if(row["CREATE_USER_ID"]!=null && row["CREATE_USER_ID"].ToString()!="")
				{
					model.CREATE_USER_ID=decimal.Parse(row["CREATE_USER_ID"].ToString());
				}
				if(row["CREATE_TIME"]!=null && row["CREATE_TIME"].ToString()!="")
				{
					model.CREATE_TIME=DateTime.Parse(row["CREATE_TIME"].ToString());
				}
				if(row["MODIFIED_USER"]!=null && row["MODIFIED_USER"].ToString()!="")
				{
					model.MODIFIED_USER=decimal.Parse(row["MODIFIED_USER"].ToString());
				}
				if(row["MODIFIED_TIME"]!=null && row["MODIFIED_TIME"].ToString()!="")
				{
					model.MODIFIED_TIME=DateTime.Parse(row["MODIFIED_TIME"].ToString());
				}
				if(row["STATUS"]!=null)
				{
					model.STATUS=row["STATUS"].ToString();
				}
					//model.REMARK=row["REMARK"].ToString();
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,PATIENT_SN,PATIENT_RELATION,CNAME,ENAME,GENDER_ID,BIRTH_DATE,HEIGHT,WEIGHT,MOBILE_TEL,ID_CARD_CODE,CREATE_USER_ID,CREATE_TIME,MODIFIED_USER,MODIFIED_TIME,STATUS,REMARK ");
			strSql.Append(" FROM TB_FAMILY ");
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
			strSql.Append("select count(1) FROM TB_FAMILY ");
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
			strSql.Append(")AS Row, T.*  from TB_FAMILY T ");
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
			parameters[0].Value = "TB_FAMILY";
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
            strSql.Append("select ID,f.PATIENT_SN,f.PATIENT_RELATION,f.CNAME CNAME,f.ENAME,f.GENDER_ID,f.BIRTH_DATE,f.HEIGHT,f.WEIGHT,f.MOBILE_TEL,f.ID_CARD_CODE,f.CREATE_USER_ID,f.CREATE_TIME,f.MODIFIED_USER,f.MODIFIED_TIME,f.STATUS,f.REMARK,p.CNAME PNAME FROM TB_FAMILY f");
            strSql.Append(" left join TB_PATIENT p on f.PATIENT_SN=p.PATIENT_SN");
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

