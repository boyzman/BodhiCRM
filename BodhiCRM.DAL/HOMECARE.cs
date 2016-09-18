/**  
* HOMECARE.cs
*
* 功 能： N/A
* 类 名： HOMECARE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/3 13:29:14   N/A    初版
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
	/// 数据访问类:HOMECARE
	/// </summary>
	public partial class HOMECARE
	{
		public HOMECARE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_HOMECARE");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.HOMECARE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_HOMECARE(");
			strSql.Append("ID,HOSPITAL_CODE,PATIENT_SN,EMPLOYEE_ID,VISIT_DT,VISIT_PLACE,ADD_TIME,CREATE_USER_ID,REMARK)");
			strSql.Append(" values (");
            strSql.Append("SEQ_TB_HOMECARE.nextval,:HOSPITAL_CODE,:PATIENT_SN,:EMPLOYEE_ID,:VISIT_DT,:VISIT_PLACE,:ADD_TIME,:CREATE_USER_ID,:REMARK)");
			OracleParameter[] parameters = {
					
                    new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10),
					new OracleParameter(":EMPLOYEE_ID", OracleType.Number,4),
					new OracleParameter(":VISIT_DT", OracleType.VarChar,20),
					new OracleParameter(":VISIT_PLACE", OracleType.VarChar,200),
					new OracleParameter(":ADD_TIME", OracleType.DateTime),
					new OracleParameter(":CREATE_USER_ID", OracleType.Number,4),
					new OracleParameter(":REMARK", OracleType.VarChar,500)};
			
            parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.PATIENT_SN;
			parameters[2].Value = model.EMPLOYEE_ID;
			parameters[3].Value = model.VISIT_DT;
			parameters[4].Value = model.VISIT_PLACE;
			parameters[5].Value = model.ADD_TIME;
			parameters[6].Value = model.CREATE_USER_ID;
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
		public bool Update(BodhiCRM.Model.HOMECARE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_HOMECARE set ");
            strSql.Append("HOSPITAL_CODE=:HOSPITAL_CODE,");
			strSql.Append("PATIENT_SN=:PATIENT_SN,");
			strSql.Append("EMPLOYEE_ID=:EMPLOYEE_ID,");
			strSql.Append("VISIT_DT=:VISIT_DT,");
			strSql.Append("VISIT_PLACE=:VISIT_PLACE,");
			strSql.Append("ADD_TIME=:ADD_TIME,");
			strSql.Append("CREATE_USER_ID=:CREATE_USER_ID,");
			strSql.Append("REMARK=:REMARK");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
                    new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10),
					new OracleParameter(":EMPLOYEE_ID", OracleType.Number,4),
					new OracleParameter(":VISIT_DT", OracleType.VarChar,20),
					new OracleParameter(":VISIT_PLACE", OracleType.VarChar,200),
					new OracleParameter(":ADD_TIME", OracleType.DateTime),
					new OracleParameter(":CREATE_USER_ID", OracleType.Number,4),
					new OracleParameter(":REMARK", OracleType.VarChar,500),
					new OracleParameter(":ID", OracleType.Number,4)};
            parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.PATIENT_SN;
			parameters[2].Value = model.EMPLOYEE_ID;
			parameters[3].Value = model.VISIT_DT;
			parameters[4].Value = model.VISIT_PLACE;
			parameters[5].Value = model.ADD_TIME;
			parameters[6].Value = model.CREATE_USER_ID;
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
			strSql.Append("delete from TB_HOMECARE ");
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
			strSql.Append("delete from TB_HOMECARE ");
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
		public BodhiCRM.Model.HOMECARE GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,HOSPITAL_CODE,PATIENT_SN,EMPLOYEE_ID,VISIT_DT,VISIT_PLACE,ADD_TIME,CREATE_USER_ID,REMARK from TB_HOMECARE ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.HOMECARE model=new BodhiCRM.Model.HOMECARE();
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
		public BodhiCRM.Model.HOMECARE DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.HOMECARE model=new BodhiCRM.Model.HOMECARE();
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
				if(row["EMPLOYEE_ID"]!=null && row["EMPLOYEE_ID"].ToString()!="")
				{
					model.EMPLOYEE_ID=decimal.Parse(row["EMPLOYEE_ID"].ToString());
				}
				if(row["VISIT_DT"]!=null)
				{
					model.VISIT_DT=row["VISIT_DT"].ToString();
				}
				if(row["VISIT_PLACE"]!=null)
				{
					model.VISIT_PLACE=row["VISIT_PLACE"].ToString();
				}
				if(row["ADD_TIME"]!=null && row["ADD_TIME"].ToString()!="")
				{
					model.ADD_TIME=DateTime.Parse(row["ADD_TIME"].ToString());
				}
				if(row["CREATE_USER_ID"]!=null && row["CREATE_USER_ID"].ToString()!="")
				{
					model.CREATE_USER_ID=decimal.Parse(row["CREATE_USER_ID"].ToString());
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
            strSql.Append("select ID,HOSPITAL_CODE,PATIENT_SN,EMPLOYEE_ID,VISIT_DT,VISIT_PLACE,ADD_TIME,CREATE_USER_ID,REMARK ");
			strSql.Append(" FROM TB_HOMECARE ");
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
			strSql.Append("select count(1) FROM TB_HOMECARE ");
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
			strSql.Append(") Row, T.*  from TB_HOMECARE T ");
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
			parameters[0].Value = "TB_HOMECARE";
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
            strSql.Append("select h.ID,h.HOSPITAL_CODE,h.PATIENT_SN,h.EMPLOYEE_ID,h.VISIT_DT,h.VISIT_PLACE,h.ADD_TIME,h.CREATE_USER_ID,h.REMARK,p.CNAME PNAME,e.REAL_NAME ENAME FROM TB_HOMECARE h");
            strSql.Append(" left join TB_PATIENT p on h.PATIENT_SN=p.PATIENT_SN");
            strSql.Append(" left join TB_EMPLOYEE e on e.ID=h.EMPLOYEE_ID");
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

