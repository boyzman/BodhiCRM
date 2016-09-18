/**  
* EMPLOYEE.cs
*
* 功 能： N/A
* 类 名： EMPLOYEE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/2 13:28:57   N/A    初版
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
	/// 数据访问类:EMPLOYEE
	/// </summary>
	public partial class EMPLOYEE
	{
		public EMPLOYEE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_EMPLOYEE");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.EMPLOYEE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_EMPLOYEE(");
			strSql.Append("ID,HOSPITAL_CODE,POST_NAME,DEPT_ID,GENDER_ID,REAL_NAME,TELEPHONE,EMAIL,ADD_TIME,IN_TIME,LEFT_TIME,ACTIVE,STATUS,REMARK)");
			strSql.Append(" values (");
            strSql.Append("SEQ_TB_EMPLOYEE.Nextval,:HOSPITAL_CODE,:POST_NAME,:DEPT_ID,:GENDER_ID,:REAL_NAME,:TELEPHONE,:EMAIL,:ADD_TIME,:IN_TIME,:LEFT_TIME,:ACTIVE,:STATUS,:REMARK)");
			OracleParameter[] parameters = {
					
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":POST_NAME", OracleType.VarChar,20),
					new OracleParameter(":DEPT_ID", OracleType.Number,4),
					new OracleParameter(":GENDER_ID", OracleType.Number,4),
					new OracleParameter(":REAL_NAME", OracleType.VarChar,50),
					new OracleParameter(":TELEPHONE", OracleType.VarChar,30),
					new OracleParameter(":EMAIL", OracleType.VarChar,30),
					new OracleParameter(":ADD_TIME", OracleType.DateTime),
					new OracleParameter(":IN_TIME", OracleType.VarChar),
					new OracleParameter(":LEFT_TIME", OracleType.VarChar),
					new OracleParameter(":ACTIVE", OracleType.VarChar,1),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,200)};
			
			parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.POST_NAME;
			parameters[2].Value = model.DEPT_ID;
			parameters[3].Value = model.GENDER_ID;
			parameters[4].Value = model.REAL_NAME;
			parameters[5].Value = model.TELEPHONE;
			parameters[6].Value = model.EMAIL;
			parameters[7].Value = model.ADD_TIME;
			parameters[8].Value = model.IN_TIME;
			parameters[9].Value = model.LEFT_TIME;
			parameters[10].Value = model.ACTIVE;
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
		public bool Update(BodhiCRM.Model.EMPLOYEE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_EMPLOYEE set ");
			//strSql.Append("HOSPITAL_CODE=:HOSPITAL_CODE,");
			strSql.Append("POST_NAME=:POST_NAME,");
			strSql.Append("DEPT_ID=:DEPT_ID,");
			strSql.Append("GENDER_ID=:GENDER_ID,");
			strSql.Append("REAL_NAME=:REAL_NAME,");
			strSql.Append("TELEPHONE=:TELEPHONE,");
			strSql.Append("EMAIL=:EMAIL,");
			//strSql.Append("ADD_TIME=:ADD_TIME,");
			strSql.Append("IN_TIME=:IN_TIME,");
			strSql.Append("LEFT_TIME=:LEFT_TIME,");
			strSql.Append("ACTIVE=:ACTIVE,");
			strSql.Append("STATUS=:STATUS,");
			strSql.Append("REMARK=:REMARK");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					//new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":POST_NAME", OracleType.VarChar,20),
					new OracleParameter(":DEPT_ID", OracleType.Number,4),
					new OracleParameter(":GENDER_ID", OracleType.Number,4),
					new OracleParameter(":REAL_NAME", OracleType.VarChar,50),
					new OracleParameter(":TELEPHONE", OracleType.VarChar,30),
					new OracleParameter(":EMAIL", OracleType.VarChar,30),
					//new OracleParameter(":ADD_TIME", OracleType.DateTime),
					new OracleParameter(":IN_TIME", OracleType.VarChar),
					new OracleParameter(":LEFT_TIME", OracleType.VarChar),
					new OracleParameter(":ACTIVE", OracleType.VarChar,1),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,200),
					new OracleParameter(":ID", OracleType.Number,4)};
			//parameters[0].Value = model.HOSPITAL_CODE;
			parameters[0].Value = model.POST_NAME;
			parameters[1].Value = model.DEPT_ID;
			parameters[2].Value = model.GENDER_ID;
			parameters[3].Value = model.REAL_NAME;
			parameters[4].Value = model.TELEPHONE;
			parameters[5].Value = model.EMAIL;
			//parameters[6].Value = model.ADD_TIME;
			parameters[6].Value = model.IN_TIME;
			parameters[7].Value = model.LEFT_TIME;
			parameters[8].Value = model.ACTIVE;
			parameters[9].Value = model.STATUS;
			parameters[10].Value = model.REMARK;
			parameters[11].Value = model.ID;

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
			strSql.Append("delete from TB_EMPLOYEE ");
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
			strSql.Append("delete from TB_EMPLOYEE ");
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
		public BodhiCRM.Model.EMPLOYEE GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,HOSPITAL_CODE,POST_NAME,DEPT_ID,GENDER_ID,REAL_NAME,TELEPHONE,EMAIL,ADD_TIME,IN_TIME,LEFT_TIME,ACTIVE,STATUS,REMARK from TB_EMPLOYEE ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.EMPLOYEE model=new BodhiCRM.Model.EMPLOYEE();
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
		public BodhiCRM.Model.EMPLOYEE DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.EMPLOYEE model=new BodhiCRM.Model.EMPLOYEE();
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
				if(row["POST_NAME"]!=null)
				{
					model.POST_NAME=row["POST_NAME"].ToString();
				}
				if(row["DEPT_ID"]!=null && row["DEPT_ID"].ToString()!="")
				{
					model.DEPT_ID=decimal.Parse(row["DEPT_ID"].ToString());
				}
				if(row["GENDER_ID"]!=null && row["GENDER_ID"].ToString()!="")
				{
					model.GENDER_ID=decimal.Parse(row["GENDER_ID"].ToString());
				}
				if(row["REAL_NAME"]!=null)
				{
					model.REAL_NAME=row["REAL_NAME"].ToString();
				}
				if(row["TELEPHONE"]!=null)
				{
					model.TELEPHONE=row["TELEPHONE"].ToString();
				}
				if(row["EMAIL"]!=null)
				{
					model.EMAIL=row["EMAIL"].ToString();
				}
				if(row["ADD_TIME"]!=null && row["ADD_TIME"].ToString()!="")
				{
					model.ADD_TIME=DateTime.Parse(row["ADD_TIME"].ToString());
				}
				if(row["IN_TIME"]!=null && row["IN_TIME"].ToString()!="")
				{
					model.IN_TIME=row["IN_TIME"].ToString();
				}
				if(row["LEFT_TIME"]!=null && row["LEFT_TIME"].ToString()!="")
				{
					model.LEFT_TIME=row["LEFT_TIME"].ToString();
				}
				if(row["ACTIVE"]!=null)
				{
					model.ACTIVE=row["ACTIVE"].ToString();
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
			strSql.Append("select ID,HOSPITAL_CODE,POST_NAME,DEPT_ID,GENDER_ID,REAL_NAME,TELEPHONE,EMAIL,ADD_TIME,IN_TIME,LEFT_TIME,ACTIVE,STATUS,REMARK ");
			strSql.Append(" FROM TB_EMPLOYEE ");
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
			strSql.Append("select count(1) FROM TB_EMPLOYEE ");
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
			strSql.Append(")AS Row, T.*  from TB_EMPLOYEE T ");
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
			parameters[0].Value = "TB_EMPLOYEE";
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
            strSql.Append("select ID,HOSPITAL_CODE,POST_NAME,DEPT_ID,GENDER_ID,REAL_NAME,TELEPHONE,EMAIL,ADD_TIME,IN_TIME,LEFT_TIME,ACTIVE,STATUS,REMARK FROM TB_EMPLOYEE ");
           
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

