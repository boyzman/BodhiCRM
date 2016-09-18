/**  
* PATIENT.cs
*
* 功 能： N/A
* 类 名： PATIENT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/29 19:58:43   N/A    初版
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
	/// 数据访问类:PATIENT
	/// </summary>
	public partial class PATIENT
	{
		public PATIENT()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录(根据病历号)
		/// </summary>
		public bool Exists(string PATIENT_SN)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_PATIENT");
			strSql.Append(" where PATIENT_SN=:PATIENT_SN ");
			OracleParameter[] parameters = {
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10)			};
			parameters[0].Value = PATIENT_SN;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录（根据身份证号）
        /// </summary>
        public bool Exists_idcard(string idcardno)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_PATIENT");
            strSql.Append(" where ID_CARD_CODE=:ID_CARD_CODE ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID_CARD_CODE", OracleType.VarChar,20)			};
            parameters[0].Value = idcardno;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录（根据手机号）
        /// </summary>
        public bool Exists_Mobile(string mobile)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_PATIENT");
            strSql.Append(" where MOBILE_TEL=:mobile ");
            OracleParameter[] parameters = {
					new OracleParameter(":mobile", OracleType.VarChar,20)			};
            parameters[0].Value = mobile;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.PATIENT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_PATIENT(");
			strSql.Append("PATIENT_SN,CNAME,GENDER_ID,BIRTH_DATE,HEIGHT,WEIGHT,MOBILE_TEL,E_MAIL,HOME_PROVINCE_ID,HOME_CITY_ID,HOME_SECTION_ID,ADDRESS,ID_CARD_CODE,CREATE_USER_ID,CREATE_TIME,MODIFIED_USER,MODIFIED_TIME,STATUS,REMARK)");
			strSql.Append(" values (");
			strSql.Append(":PATIENT_SN,:CNAME,:GENDER_ID,:BIRTH_DATE,:HEIGHT,:WEIGHT,:MOBILE_TEL,:E_MAIL,:HOME_PROVINCE_ID,:HOME_CITY_ID,:HOME_SECTION_ID,:ADDRESS,:ID_CARD_CODE,:CREATE_USER_ID,:CREATE_TIME,:MODIFIED_USER,:MODIFIED_TIME,:STATUS,:REMARK)");
			OracleParameter[] parameters = {
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10),
					new OracleParameter(":CNAME", OracleType.VarChar,60),
					
					new OracleParameter(":GENDER_ID", OracleType.Number,4),
					new OracleParameter(":BIRTH_DATE", OracleType.VarChar),
					new OracleParameter(":HEIGHT", OracleType.Number,6),
					new OracleParameter(":WEIGHT", OracleType.Number,6),
					
					new OracleParameter(":MOBILE_TEL", OracleType.VarChar,30),
					new OracleParameter(":E_MAIL", OracleType.VarChar,80),
					new OracleParameter(":HOME_PROVINCE_ID", OracleType.VarChar,20),
					new OracleParameter(":HOME_CITY_ID", OracleType.VarChar,20),
					new OracleParameter(":HOME_SECTION_ID", OracleType.VarChar,20),
					new OracleParameter(":ADDRESS", OracleType.VarChar,300),
					
					new OracleParameter(":ID_CARD_CODE", OracleType.VarChar,60),
					new OracleParameter(":CREATE_USER_ID", OracleType.Number,4),
					new OracleParameter(":CREATE_TIME", OracleType.DateTime),
					new OracleParameter(":MODIFIED_USER", OracleType.Number,4),
					new OracleParameter(":MODIFIED_TIME", OracleType.DateTime),
                    new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":REMARK", OracleType.VarChar,1000)};
			parameters[0].Value = model.PATIENT_SN;
			parameters[1].Value = model.CNAME;
			
			parameters[2].Value = model.GENDER_ID;
			parameters[3].Value = model.BIRTH_DATE;
			parameters[4].Value = model.HEIGHT;
			parameters[5].Value = model.WEIGHT;
			
			parameters[6].Value = model.MOBILE_TEL;
			parameters[7].Value = model.E_MAIL;
			parameters[8].Value = model.HOME_PROVINCE_ID;
			parameters[9].Value = model.HOME_CITY_ID;
			parameters[10].Value = model.HOME_SECTION_ID;
			parameters[11].Value = model.ADDRESS;
			
			parameters[12].Value = model.ID_CARD_CODE;
			parameters[13].Value = model.CREATE_USER_ID;
			parameters[14].Value = model.CREATE_TIME;
            parameters[15].Value = model.CREATE_USER_ID;
            parameters[16].Value = model.CREATE_TIME;
            parameters[17].Value = model.STATUS;
			parameters[18].Value = model.REMARK;

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
		public bool Update(BodhiCRM.Model.PATIENT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_PATIENT set ");
			strSql.Append("CNAME=:CNAME,");
			strSql.Append("ENAME=:ENAME,");
			strSql.Append("GENDER_ID=:GENDER_ID,");
			strSql.Append("BIRTH_DATE=:BIRTH_DATE,");
			strSql.Append("HEIGHT=:HEIGHT,");
			strSql.Append("WEIGHT=:WEIGHT,");
			strSql.Append("HOME_TEL=:HOME_TEL,");
			strSql.Append("MOBILE_TEL=:MOBILE_TEL,");
			strSql.Append("E_MAIL=:E_MAIL,");
			strSql.Append("HOME_PROVINCE_ID=:HOME_PROVINCE_ID,");
			strSql.Append("HOME_CITY_ID=:HOME_CITY_ID,");
			strSql.Append("HOME_SECTION_ID=:HOME_SECTION_ID,");
			strSql.Append("ADDRESS=:ADDRESS,");
			strSql.Append("POST_CODE=:POST_CODE,");
			strSql.Append("ID_CARD_CODE=:ID_CARD_CODE,");
			strSql.Append("CREATE_USER_ID=:CREATE_USER_ID,");
			strSql.Append("CREATE_TIME=:CREATE_TIME,");
			strSql.Append("MODIFIED_USER=:MODIFIED_USER,");
			strSql.Append("MODIFIED_TIME=:MODIFIED_TIME,");
			strSql.Append("REMARK=:REMARK");
			strSql.Append(" where PATIENT_SN=:PATIENT_SN ");
			OracleParameter[] parameters = {
					new OracleParameter(":CNAME", OracleType.VarChar,60),
					new OracleParameter(":ENAME", OracleType.VarChar,40),
					new OracleParameter(":GENDER_ID", OracleType.Number,4),
					new OracleParameter(":BIRTH_DATE", OracleType.VarChar),
					new OracleParameter(":HEIGHT", OracleType.Number,6),
					new OracleParameter(":WEIGHT", OracleType.Number,6),
					new OracleParameter(":HOME_TEL", OracleType.VarChar,30),
					new OracleParameter(":MOBILE_TEL", OracleType.VarChar,30),
					new OracleParameter(":E_MAIL", OracleType.VarChar,80),
					new OracleParameter(":HOME_PROVINCE_ID", OracleType.VarChar,20),
					new OracleParameter(":HOME_CITY_ID", OracleType.VarChar,20),
					new OracleParameter(":HOME_SECTION_ID", OracleType.VarChar,20),
					new OracleParameter(":ADDRESS", OracleType.VarChar,300),
					new OracleParameter(":POST_CODE", OracleType.VarChar,40),
					new OracleParameter(":ID_CARD_CODE", OracleType.VarChar,60),
					new OracleParameter(":CREATE_USER_ID", OracleType.Number,4),
					new OracleParameter(":CREATE_TIME", OracleType.DateTime),
					new OracleParameter(":MODIFIED_USER", OracleType.Number,4),
					new OracleParameter(":MODIFIED_TIME", OracleType.DateTime),
					new OracleParameter(":REMARK", OracleType.VarChar,1000),
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10)};
			parameters[0].Value = model.CNAME;
			parameters[1].Value = model.ENAME;
			parameters[2].Value = model.GENDER_ID;
			parameters[3].Value = model.BIRTH_DATE;
			parameters[4].Value = model.HEIGHT;
			parameters[5].Value = model.WEIGHT;
			parameters[6].Value = model.HOME_TEL;
			parameters[7].Value = model.MOBILE_TEL;
			parameters[8].Value = model.E_MAIL;
			parameters[9].Value = model.HOME_PROVINCE_ID;
			parameters[10].Value = model.HOME_CITY_ID;
			parameters[11].Value = model.HOME_SECTION_ID;
			parameters[12].Value = model.ADDRESS;
			parameters[13].Value = model.POST_CODE;
			parameters[14].Value = model.ID_CARD_CODE;
			parameters[15].Value = model.CREATE_USER_ID;
			parameters[16].Value = model.CREATE_TIME;
			parameters[17].Value = model.MODIFIED_USER;
			parameters[18].Value = model.MODIFIED_TIME;
			parameters[19].Value = model.REMARK;
			parameters[20].Value = model.PATIENT_SN;

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
		public bool Delete(string PATIENT_SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TB_PATIENT ");
			strSql.Append(" where PATIENT_SN=:PATIENT_SN ");
			OracleParameter[] parameters = {
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10)			};
			parameters[0].Value = PATIENT_SN;

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
		public bool DeleteList(string PATIENT_SNlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TB_PATIENT ");
			strSql.Append(" where PATIENT_SN in ("+PATIENT_SNlist + ")  ");
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
		public BodhiCRM.Model.PATIENT GetModel(string PATIENT_SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PATIENT_SN,CNAME,ENAME,GENDER_ID,BIRTH_DATE,HEIGHT,WEIGHT,HOME_TEL,MOBILE_TEL,E_MAIL,HOME_PROVINCE_ID,HOME_CITY_ID,HOME_SECTION_ID,ADDRESS,POST_CODE,ID_CARD_CODE,CREATE_USER_ID,CREATE_TIME,MODIFIED_USER,MODIFIED_TIME,REMARK,STATUS from TB_PATIENT ");
			strSql.Append(" where PATIENT_SN=:PATIENT_SN ");
			OracleParameter[] parameters = {
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,10)			};
			parameters[0].Value = PATIENT_SN;

			BodhiCRM.Model.PATIENT model=new BodhiCRM.Model.PATIENT();
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
		public BodhiCRM.Model.PATIENT DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.PATIENT model=new BodhiCRM.Model.PATIENT();
			if (row != null)
			{
				if(row["PATIENT_SN"]!=null)
				{
					model.PATIENT_SN=row["PATIENT_SN"].ToString();
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
				if(row["HOME_TEL"]!=null)
				{
					model.HOME_TEL=row["HOME_TEL"].ToString();
				}
				if(row["MOBILE_TEL"]!=null)
				{
					model.MOBILE_TEL=row["MOBILE_TEL"].ToString();
				}
				if(row["E_MAIL"]!=null)
				{
					model.E_MAIL=row["E_MAIL"].ToString();
				}
				if(row["HOME_PROVINCE_ID"]!=null && row["HOME_PROVINCE_ID"].ToString()!="")
				{
                    model.HOME_PROVINCE_ID = row["HOME_PROVINCE_ID"].ToString();
				}
				if(row["HOME_CITY_ID"]!=null && row["HOME_CITY_ID"].ToString()!="")
				{
                    model.HOME_CITY_ID = row["HOME_CITY_ID"].ToString();
				}
				if(row["HOME_SECTION_ID"]!=null && row["HOME_SECTION_ID"].ToString()!="")
				{
                    model.HOME_SECTION_ID = row["HOME_SECTION_ID"].ToString();
				}
				if(row["ADDRESS"]!=null)
				{
					model.ADDRESS=row["ADDRESS"].ToString();
				}
				if(row["POST_CODE"]!=null)
				{
					model.POST_CODE=row["POST_CODE"].ToString();
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
                if (row["STATUS"] != null)
                {
                    model.STATUS = row["STATUS"].ToString();
                }
			    model.REMARK=row["REMARK"].ToString();
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PATIENT_SN,CNAME,ENAME,GENDER_ID,BIRTH_DATE,HEIGHT,WEIGHT,HOME_TEL,MOBILE_TEL,E_MAIL,HOME_PROVINCE_ID,HOME_CITY_ID,HOME_SECTION_ID,ADDRESS,POST_CODE,ID_CARD_CODE,CREATE_USER_ID,CREATE_TIME,MODIFIED_USER,MODIFIED_TIME,REMARK ");
			strSql.Append(" FROM TB_PATIENT ");
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
			strSql.Append("select count(1) FROM TB_PATIENT ");
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
				strSql.Append("order by T.PATIENT_SN desc");
			}
			strSql.Append(") Row, T.*  from TB_PATIENT T ");
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
			parameters[0].Value = "TB_PATIENT";
			parameters[1].Value = "PATIENT_SN";
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
            strSql.Append("select PATIENT_SN,CNAME,ENAME,GENDER_ID,BIRTH_DATE,HEIGHT,WEIGHT,HOME_TEL,MOBILE_TEL,E_MAIL,HOME_PROVINCE_ID,HOME_CITY_ID,HOME_SECTION_ID,ADDRESS,POST_CODE,ID_CARD_CODE,CREATE_USER_ID,CREATE_TIME,MODIFIED_USER,MODIFIED_TIME,STATUS,REMARK FROM TB_PATIENT");
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

