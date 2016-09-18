/**  
* BIRTHCARE.cs
*
* 功 能： N/A
* 类 名： BIRTHCARE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/6 10:53:43   N/A    初版
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
	/// 数据访问类:BIRTHCARE
	/// </summary>
	public partial class BIRTHCARE
	{
		public BIRTHCARE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_BIRTHCARE");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.BIRTHCARE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_BIRTHCARE(");
			strSql.Append("ID,HOSPITAL_CODE,PATIENT_SN,DEPT_ID,GIFT_NAME,GIFT_PAYMENT,GIFT_VALUE,GIFT_GETDT,CREATE_USER_ID,STATUS,REMARK)");
			strSql.Append(" values (");
            strSql.Append("SEQ_TB_BIRTHCARE.nextval,:HOSPITAL_CODE,:PATIENT_SN,:DEPT_ID,:GIFT_NAME,:GIFT_PAYMENT,:GIFT_VALUE,:GIFT_GETDT,:CREATE_USER_ID,:STATUS,:REMARK)");
			OracleParameter[] parameters = {
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,10),
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10),
					new OracleParameter(":DEPT_ID", OracleType.Number,4),
					new OracleParameter(":GIFT_NAME", OracleType.VarChar,200),
					new OracleParameter(":GIFT_PAYMENT", OracleType.VarChar,20),
					new OracleParameter(":GIFT_VALUE", OracleType.VarChar,20),
					new OracleParameter(":GIFT_GETDT", OracleType.VarChar,20),
					new OracleParameter(":CREATE_USER_ID", OracleType.Number,4),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,500)};
            parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.PATIENT_SN;
			parameters[2].Value = model.DEPT_ID;
			parameters[3].Value = model.GIFT_NAME;
			parameters[4].Value = model.GIFT_PAYMENT;
			parameters[5].Value = model.GIFT_VALUE;
			parameters[6].Value = model.GIFT_GETDT;
			parameters[7].Value = model.CREATE_USER_ID;
			parameters[8].Value = model.STATUS;
			parameters[9].Value = model.REMARK;

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
		public bool Update(BodhiCRM.Model.BIRTHCARE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_BIRTHCARE set ");
			strSql.Append("PATIENT_SN=:PATIENT_SN,");
			strSql.Append("DEPT_ID=:DEPT_ID,");
			strSql.Append("GIFT_NAME=:GIFT_NAME,");
			strSql.Append("GIFT_PAYMENT=:GIFT_PAYMENT,");
			strSql.Append("GIFT_VALUE=:GIFT_VALUE,");
			strSql.Append("GIFT_GETDT=:GIFT_GETDT,");
			strSql.Append("ADD_TIME=:ADD_TIME,");
			strSql.Append("CREATE_USER_ID=:CREATE_USER_ID,");
			strSql.Append("STATUS=:STATUS,");
			strSql.Append("REMARK=:REMARK");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10),
					new OracleParameter(":DEPT_ID", OracleType.Number,4),
					
					new OracleParameter(":GIFT_NAME", OracleType.VarChar,200),
					new OracleParameter(":GIFT_PAYMENT", OracleType.VarChar,20),
					new OracleParameter(":GIFT_VALUE", OracleType.VarChar,20),
					new OracleParameter(":GIFT_GETDT", OracleType.VarChar,20),
					new OracleParameter(":ADD_TIME", OracleType.DateTime),
					new OracleParameter(":CREATE_USER_ID", OracleType.Number,4),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,500),
					new OracleParameter(":ID", OracleType.Number,4)};
			parameters[0].Value = model.PATIENT_SN;
			parameters[1].Value = model.DEPT_ID;
			parameters[2].Value = model.GIFT_NAME;
			parameters[3].Value = model.GIFT_PAYMENT;
			parameters[4].Value = model.GIFT_VALUE;
			parameters[5].Value = model.GIFT_GETDT;
			parameters[6].Value = model.ADD_TIME;
			parameters[7].Value = model.CREATE_USER_ID;
			parameters[8].Value = model.STATUS;
			parameters[9].Value = model.REMARK;
			parameters[10].Value = model.ID;

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
			strSql.Append("delete from TB_BIRTHCARE ");
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
			strSql.Append("delete from TB_BIRTHCARE ");
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
		public BodhiCRM.Model.BIRTHCARE GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,HOSPITAL_CODE,PATIENT_SN,DEPT_ID,SMS_ID,GIFT_NAME,GIFT_PAYMENT,GIFT_VALUE,GIFT_GETDT,ADD_TIME,CREATE_USER_ID,STATUS,REMARK from TB_BIRTHCARE ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.BIRTHCARE model=new BodhiCRM.Model.BIRTHCARE();
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
		public BodhiCRM.Model.BIRTHCARE DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.BIRTHCARE model=new BodhiCRM.Model.BIRTHCARE();
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
				if(row["DEPT_ID"]!=null && row["DEPT_ID"].ToString()!="")
				{
					model.DEPT_ID=decimal.Parse(row["DEPT_ID"].ToString());
				}
	
                if (row["SMS_ID"] != null && row["SMS_ID"].ToString() != "")
				{
                    model.SMS_ID = decimal.Parse(row["SMS_ID"].ToString());
				}
				if(row["GIFT_NAME"]!=null)
				{
					model.GIFT_NAME=row["GIFT_NAME"].ToString();
				}
				if(row["GIFT_PAYMENT"]!=null)
				{
					model.GIFT_PAYMENT=row["GIFT_PAYMENT"].ToString();
				}
				if(row["GIFT_VALUE"]!=null)
				{
					model.GIFT_VALUE=row["GIFT_VALUE"].ToString();
				}
				if(row["GIFT_GETDT"]!=null)
				{
					model.GIFT_GETDT=row["GIFT_GETDT"].ToString();
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
            strSql.Append("select ID,HOSPITAL_CODE,PATIENT_SN,DEPT_ID,SMS_ID,GIFT_NAME,GIFT_PAYMENT,GIFT_VALUE,GIFT_GETDT,ADD_TIME,CREATE_USER_ID,STATUS,REMARK ");
			strSql.Append(" FROM TB_BIRTHCARE ");
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
			strSql.Append("select count(1) FROM TB_BIRTHCARE ");
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
			strSql.Append(") Row, T.*  from TB_BIRTHCARE T ");
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
			parameters[0].Value = "TB_BIRTHCARE";
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
            strSql.Append("select b.ID,b.HOSPITAL_CODE,b.PATIENT_SN,b.DEPT_ID,b.SMS_ID,b.GIFT_NAME,b.GIFT_PAYMENT,b.GIFT_VALUE,b.GIFT_GETDT,b.ADD_TIME,b.CREATE_USER_ID,b.STATUS,b.REMARK,p.CNAME PNAME,d.DEPT_NAME DNAME,p.MOBILE_TEL,p.BIRTH_DATE,floor(sysdate - to_date(to_char(sysdate,'yyyy')||substr(birth_date,5),'yyyy-mm-dd')) BDAYS from TB_BIRTHCARE b");
            strSql.Append(" left join TB_PATIENT p on b.PATIENT_SN=p.PATIENT_SN");
            strSql.Append(" left join TB_DEPARTMENT d on d.ID=b.DEPT_ID");
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

