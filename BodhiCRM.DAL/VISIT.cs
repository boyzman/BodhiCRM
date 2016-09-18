/**  
* VISIT.cs
*
* 功 能： N/A
* 类 名： VISIT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/6 10:53:40   N/A    初版
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
	/// 数据访问类:VISIT
	/// </summary>
	public partial class VISIT
	{
		public VISIT()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_VISIT");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.VISIT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_VISIT(");
            strSql.Append("ID,HOSPITAL_CODE,PATIENT_SN,EMPL_ID,VISIT_TITLE,VISIT_TYPE,VISIT_STARTDT,VISIT_ENDDT,VISIT_FREQUENCY,VISIT_FREQUENCYNO,VISIT_STATUS,CREATE_USER_ID,STATUS,REMARK)");
			strSql.Append(" values (");
            strSql.Append("SEQ_TB_VISIT.nextval,:HOSPITAL_CODE,:PATIENT_SN,:EMPL_ID,:VISIT_TITLE,:VISIT_TYPE,:VISIT_STARTDT,:VISIT_ENDDT,:VISIT_FREQUENCY,:VISIT_FREQUENCYNO,:VISIT_STATUS,:CREATE_USER_ID,:STATUS,:REMARK)");
			OracleParameter[] parameters = {
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10),
					new OracleParameter(":EMPL_ID", OracleType.Number,4),
					new OracleParameter(":VISIT_TITLE", OracleType.VarChar,40),
					new OracleParameter(":VISIT_TYPE", OracleType.VarChar,20),
					new OracleParameter(":VISIT_STARTDT", OracleType.VarChar,20),
					new OracleParameter(":VISIT_ENDDT", OracleType.VarChar,20),
					new OracleParameter(":VISIT_FREQUENCY", OracleType.VarChar,10),
					new OracleParameter(":VISIT_FREQUENCYNO", OracleType.Number,4),
					new OracleParameter(":VISIT_STATUS", OracleType.VarChar,10),
					new OracleParameter(":CREATE_USER_ID", OracleType.Number,4),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,500)};
            parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.PATIENT_SN;
			parameters[2].Value = model.EMPL_ID;
			parameters[3].Value = model.VISIT_TITLE;
			parameters[4].Value = model.VISIT_TYPE;
			parameters[5].Value = model.VISIT_STARTDT;
			parameters[6].Value = model.VISIT_ENDDT;
			parameters[7].Value = model.VISIT_FREQUENCY;
			parameters[8].Value = model.VISIT_FREQUENCYNO;
			parameters[9].Value = model.VISIT_STATUS;
			parameters[10].Value = model.CREATE_USER_ID;
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
		public bool Update(BodhiCRM.Model.VISIT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_VISIT set ");
			strSql.Append("PATIENT_SN=:PATIENT_SN,");
			strSql.Append("EMPL_ID=:EMPL_ID,");
			strSql.Append("VISIT_TITLE=:VISIT_TITLE,");
			strSql.Append("VISIT_TYPE=:VISIT_TYPE,");
			strSql.Append("VISIT_STARTDT=:VISIT_STARTDT,");
			strSql.Append("VISIT_ENDDT=:VISIT_ENDDT,");
			strSql.Append("VISIT_FREQUENCY=:VISIT_FREQUENCY,");
			strSql.Append("VISIT_FREQUENCYNO=:VISIT_FREQUENCYNO,");
			strSql.Append("VISIT_STATUS=:VISIT_STATUS,");
			strSql.Append("ADD_TIME=:ADD_TIME,");
			strSql.Append("CREATE_USER_ID=:CREATE_USER_ID,");
			strSql.Append("STATUS=:STATUS,");
			strSql.Append("REMARK=:REMARK");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10),
					new OracleParameter(":EMPL_ID", OracleType.Number,4),
					new OracleParameter(":VISIT_TITLE", OracleType.VarChar,40),
					new OracleParameter(":VISIT_TYPE", OracleType.VarChar,20),
					new OracleParameter(":VISIT_STARTDT", OracleType.VarChar,20),
					new OracleParameter(":VISIT_ENDDT", OracleType.VarChar,20),
					new OracleParameter(":VISIT_FREQUENCY", OracleType.VarChar,10),
					new OracleParameter(":VISIT_FREQUENCYNO", OracleType.Number,4),
					new OracleParameter(":VISIT_STATUS", OracleType.VarChar,10),
					new OracleParameter(":ADD_TIME", OracleType.DateTime),
					new OracleParameter(":CREATE_USER_ID", OracleType.Number,4),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,500),
					new OracleParameter(":ID", OracleType.Number,4)};
			parameters[0].Value = model.PATIENT_SN;
			parameters[1].Value = model.EMPL_ID;
			parameters[2].Value = model.VISIT_TITLE;
			parameters[3].Value = model.VISIT_TYPE;
			parameters[4].Value = model.VISIT_STARTDT;
			parameters[5].Value = model.VISIT_ENDDT;
			parameters[6].Value = model.VISIT_FREQUENCY;
			parameters[7].Value = model.VISIT_FREQUENCYNO;
			parameters[8].Value = model.VISIT_STATUS;
			parameters[9].Value = model.ADD_TIME;
			parameters[10].Value = model.CREATE_USER_ID;
			parameters[11].Value = model.STATUS;
			parameters[12].Value = model.REMARK;
			parameters[13].Value = model.ID;

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
			strSql.Append("delete from TB_VISIT ");
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
			strSql.Append("delete from TB_VISIT ");
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
		public BodhiCRM.Model.VISIT GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,HOSPITAL_CODE,PATIENT_SN,EMPL_ID,VISIT_TITLE,VISIT_TYPE,VISIT_STARTDT,VISIT_ENDDT,VISIT_FREQUENCY,VISIT_FREQUENCYNO,VISIT_STATUS,ADD_TIME,CREATE_USER_ID,STATUS,REMARK from TB_VISIT ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.VISIT model=new BodhiCRM.Model.VISIT();
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
		public BodhiCRM.Model.VISIT DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.VISIT model=new BodhiCRM.Model.VISIT();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
                if (row["HOSPITAL_CODE"] != null)
                {
                    model.HOSPITAL_CODE = row["HOSPITAL_CODE"].ToString();
                }
				if(row["PATIENT_SN"]!=null)
				{
					model.PATIENT_SN=row["PATIENT_SN"].ToString();
				}
				if(row["EMPL_ID"]!=null && row["EMPL_ID"].ToString()!="")
				{
					model.EMPL_ID=decimal.Parse(row["EMPL_ID"].ToString());
				}
				if(row["VISIT_TITLE"]!=null)
				{
					model.VISIT_TITLE=row["VISIT_TITLE"].ToString();
				}
				if(row["VISIT_TYPE"]!=null)
				{
					model.VISIT_TYPE=row["VISIT_TYPE"].ToString();
				}
				if(row["VISIT_STARTDT"]!=null)
				{
					model.VISIT_STARTDT=row["VISIT_STARTDT"].ToString();
				}
				if(row["VISIT_ENDDT"]!=null)
				{
					model.VISIT_ENDDT=row["VISIT_ENDDT"].ToString();
				}
				if(row["VISIT_FREQUENCY"]!=null)
				{
					model.VISIT_FREQUENCY=row["VISIT_FREQUENCY"].ToString();
				}
				if(row["VISIT_FREQUENCYNO"]!=null && row["VISIT_FREQUENCYNO"].ToString()!="")
				{
					model.VISIT_FREQUENCYNO=decimal.Parse(row["VISIT_FREQUENCYNO"].ToString());
				}
				if(row["VISIT_STATUS"]!=null)
				{
					model.VISIT_STATUS=row["VISIT_STATUS"].ToString();
				}
				if(row["ADD_TIME"]!=null && row["ADD_TIME"].ToString()!="")
				{
					model.ADD_TIME=DateTime.Parse(row["ADD_TIME"].ToString());
				}
				if(row["CREATE_USER_ID"]!=null && row["CREATE_USER_ID"].ToString()!="")
				{
					model.CREATE_USER_ID=decimal.Parse(row["CREATE_USER_ID"].ToString());
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
            strSql.Append("select ID,HOSPITAL_CODE,PATIENT_SN,EMPL_ID,VISIT_TITLE,VISIT_TYPE,VISIT_STARTDT,VISIT_ENDDT,VISIT_FREQUENCY,VISIT_FREQUENCYNO,VISIT_STATUS,ADD_TIME,CREATE_USER_ID,STATUS,REMARK ");
			strSql.Append(" FROM TB_VISIT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_ByEmpl(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(v.ID) ID,max(v.HOSPITAL_CODE) HOSPITAL_CODE,v.EMPL_ID,max(e.REAL_NAME) ENAME,count(VISIT_TITLE) TIMES  from TB_VISIT v");
            //strSql.Append(" left join TB_PATIENT p on v.PATIENT_SN=p.PATIENT_SN");
            strSql.Append(" left join TB_EMPLOYEE e on e.ID=v.EMPL_ID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by v.EMPL_ID ");
            return DbHelperOra.Query(strSql.ToString());
        }
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TB_VISIT ");
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
			strSql.Append(")AS Row, T.*  from TB_VISIT T ");
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
			parameters[0].Value = "TB_VISIT";
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
            strSql.Append("select v.ID,v.HOSPITAL_CODE,v.PATIENT_SN,v.EMPL_ID,v.VISIT_TITLE,v.VISIT_TYPE,v.VISIT_STARTDT,v.VISIT_ENDDT,v.VISIT_FREQUENCY,v.VISIT_FREQUENCYNO,v.VISIT_STATUS,v.ADD_TIME,v.CREATE_USER_ID,v.STATUS,v.REMARK,p.CNAME PNAME,e.REAL_NAME ENAME,p.MOBILE_TEL from TB_VISIT v");
            strSql.Append(" left join TB_PATIENT p on v.PATIENT_SN=p.PATIENT_SN");
            strSql.Append(" left join TB_EMPLOYEE e on e.ID=v.EMPL_ID");
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

