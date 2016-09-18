/**  
* SMS_MESSAGE.cs
*
* 功 能： N/A
* 类 名： SMS_MESSAGE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/18 14:26:00   N/A    初版
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
	/// 数据访问类:SMS_MESSAGE
	/// </summary>
	public partial class SMS_MESSAGE
	{
		public SMS_MESSAGE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_SMS_MESSAGE");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.SMS_MESSAGE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_SMS_MESSAGE(");
            strSql.Append("ID,TID,CALL_INDEX,TYPE,GET_USER_NAME,PATIENT_SN,PATIENT_MOBILE,IS_READ,CONTENT,POST_TIME,STATUS,DATAS,ERROR_MESSAGE)");
			strSql.Append(" values (");
            strSql.Append("SEQ_TB_SMS_MESSAGE.nextval,:TID,:CALL_INDEX,:TYPE,:GET_USER_NAME,:PATIENT_SN,:PATIENT_MOBILE,:IS_READ,:CONTENT,:POST_TIME,:STATUS,:DATAS,:ERROR_MESSAGE)");
			OracleParameter[] parameters = {
					
					new OracleParameter(":TID", OracleType.Number,4),
					new OracleParameter(":CALL_INDEX", OracleType.VarChar,50),
					new OracleParameter(":TYPE", OracleType.VarChar,10),
					//new OracleParameter(":POST_USER_NAME", OracleType.VarChar,10),
					new OracleParameter(":GET_USER_NAME", OracleType.VarChar,10),
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,20),
					new OracleParameter(":PATIENT_MOBILE", OracleType.VarChar,20),
					//new OracleParameter(":PARENT_ID", OracleType.Number,4),
					new OracleParameter(":IS_READ", OracleType.VarChar,1),
					//new OracleParameter(":TITLE", OracleType.VarChar,100),
					new OracleParameter(":CONTENT", OracleType.VarChar,500),
					new OracleParameter(":POST_TIME", OracleType.VarChar,20),
					//new OracleParameter(":READ_TIME", OracleType.VarChar,20),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":DATAS", OracleType.VarChar,200),
					new OracleParameter(":ERROR_MESSAGE", OracleType.VarChar,500)};
			
			parameters[0].Value = model.TID;
			parameters[1].Value = model.CALL_INDEX;
			parameters[2].Value = model.TYPE;
			//parameters[3].Value = model.POST_USER_NAME;
			parameters[3].Value = model.GET_USER_NAME;
			parameters[4].Value = model.PATIENT_SN;
			parameters[5].Value = model.PATIENT_MOBILE;
			//parameters[7].Value = model.PARENT_ID;
			parameters[6].Value = model.IS_READ;
			//parameters[9].Value = model.TITLE;
			parameters[7].Value = model.CONTENT;
			parameters[8].Value = model.POST_TIME;
			//parameters[12].Value = model.READ_TIME;
			parameters[9].Value = model.STATUS;
			parameters[10].Value = model.DATAS;
			parameters[11].Value = model.ERROR_MESSAGE;

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
		public bool Update(BodhiCRM.Model.SMS_MESSAGE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_SMS_MESSAGE set ");
			strSql.Append("TID=:TID,");
			strSql.Append("CALL_INDEX=:CALL_INDEX,");
			strSql.Append("TYPE=:TYPE,");
			strSql.Append("POST_USER_NAME=:POST_USER_NAME,");
			strSql.Append("GET_USER_NAME=:GET_USER_NAME,");
			strSql.Append("PATIENT_SN=:PATIENT_SN,");
			strSql.Append("PATIENT_MOBILE=:PATIENT_MOBILE,");
			strSql.Append("PARENT_ID=:PARENT_ID,");
			strSql.Append("IS_READ=:IS_READ,");
			strSql.Append("TITLE=:TITLE,");
			strSql.Append("CONTENT=:CONTENT,");
			strSql.Append("POST_TIME=:POST_TIME,");
			strSql.Append("READ_TIME=:READ_TIME,");
			strSql.Append("STATUS=:STATUS,");
			strSql.Append("DATAS=:DATAS,");
			strSql.Append("ERROR_MESSAGE=:ERROR_MESSAGE");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":TID", OracleType.Number,4),
					new OracleParameter(":CALL_INDEX", OracleType.VarChar,50),
					new OracleParameter(":TYPE", OracleType.VarChar,10),
					new OracleParameter(":POST_USER_NAME", OracleType.VarChar,10),
					new OracleParameter(":GET_USER_NAME", OracleType.VarChar,10),
					new OracleParameter(":PATIENT_SN", OracleType.VarChar,20),
					new OracleParameter(":PATIENT_MOBILE", OracleType.VarChar,20),
					new OracleParameter(":PARENT_ID", OracleType.Number,4),
					new OracleParameter(":IS_READ", OracleType.VarChar,1),
					new OracleParameter(":TITLE", OracleType.VarChar,100),
					new OracleParameter(":CONTENT", OracleType.VarChar,500),
					new OracleParameter(":POST_TIME", OracleType.VarChar,20),
					new OracleParameter(":READ_TIME", OracleType.VarChar,20),
					new OracleParameter(":STATUS", OracleType.VarChar,1),
					new OracleParameter(":DATAS", OracleType.VarChar,200),
					new OracleParameter(":ERROR_MESSAGE", OracleType.VarChar,500),
					new OracleParameter(":ID", OracleType.Number,4)};
			parameters[0].Value = model.TID;
			parameters[1].Value = model.CALL_INDEX;
			parameters[2].Value = model.TYPE;
			parameters[3].Value = model.POST_USER_NAME;
			parameters[4].Value = model.GET_USER_NAME;
			parameters[5].Value = model.PATIENT_SN;
			parameters[6].Value = model.PATIENT_MOBILE;
			parameters[7].Value = model.PARENT_ID;
			parameters[8].Value = model.IS_READ;
			parameters[9].Value = model.TITLE;
			parameters[10].Value = model.CONTENT;
			parameters[11].Value = model.POST_TIME;
			parameters[12].Value = model.READ_TIME;
			parameters[13].Value = model.STATUS;
			parameters[14].Value = model.DATAS;
			parameters[15].Value = model.ERROR_MESSAGE;
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
			strSql.Append("delete from TB_SMS_MESSAGE ");
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
			strSql.Append("delete from TB_SMS_MESSAGE ");
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
		public BodhiCRM.Model.SMS_MESSAGE GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,TID,CALL_INDEX,TYPE,POST_USER_NAME,GET_USER_NAME,PATIENT_SN,PATIENT_MOBILE,PARENT_ID,IS_READ,TITLE,CONTENT,POST_TIME,READ_TIME,STATUS,DATAS,ERROR_MESSAGE from TB_SMS_MESSAGE ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.SMS_MESSAGE model=new BodhiCRM.Model.SMS_MESSAGE();
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
		public BodhiCRM.Model.SMS_MESSAGE DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.SMS_MESSAGE model=new BodhiCRM.Model.SMS_MESSAGE();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=decimal.Parse(row["TID"].ToString());
				}
				if(row["CALL_INDEX"]!=null)
				{
					model.CALL_INDEX=row["CALL_INDEX"].ToString();
				}
				if(row["TYPE"]!=null)
				{
					model.TYPE=row["TYPE"].ToString();
				}
				if(row["POST_USER_NAME"]!=null)
				{
					model.POST_USER_NAME=row["POST_USER_NAME"].ToString();
				}
				if(row["GET_USER_NAME"]!=null)
				{
					model.GET_USER_NAME=row["GET_USER_NAME"].ToString();
				}
				if(row["PATIENT_SN"]!=null)
				{
					model.PATIENT_SN=row["PATIENT_SN"].ToString();
				}
				if(row["PATIENT_MOBILE"]!=null)
				{
					model.PATIENT_MOBILE=row["PATIENT_MOBILE"].ToString();
				}
				if(row["PARENT_ID"]!=null && row["PARENT_ID"].ToString()!="")
				{
					model.PARENT_ID=decimal.Parse(row["PARENT_ID"].ToString());
				}
				if(row["IS_READ"]!=null)
				{
					model.IS_READ=row["IS_READ"].ToString();
				}
				if(row["TITLE"]!=null)
				{
					model.TITLE=row["TITLE"].ToString();
				}
				if(row["CONTENT"]!=null)
				{
					model.CONTENT=row["CONTENT"].ToString();
				}
				if(row["POST_TIME"]!=null)
				{
					model.POST_TIME=row["POST_TIME"].ToString();
				}
				if(row["READ_TIME"]!=null)
				{
					model.READ_TIME=row["READ_TIME"].ToString();
				}
				if(row["STATUS"]!=null)
				{
					model.STATUS=row["STATUS"].ToString();
				}
				if(row["DATAS"]!=null)
				{
					model.DATAS=row["DATAS"].ToString();
				}
				if(row["ERROR_MESSAGE"]!=null)
				{
					model.ERROR_MESSAGE=row["ERROR_MESSAGE"].ToString();
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
			strSql.Append("select ID,TID,CALL_INDEX,TYPE,POST_USER_NAME,GET_USER_NAME,PATIENT_SN,PATIENT_MOBILE,PARENT_ID,IS_READ,TITLE,CONTENT,POST_TIME,READ_TIME,STATUS,DATAS,ERROR_MESSAGE ");
			strSql.Append(" FROM TB_SMS_MESSAGE ");
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
			strSql.Append("select count(1) FROM TB_SMS_MESSAGE ");
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
			strSql.Append(")AS Row, T.*  from TB_SMS_MESSAGE T ");
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
			parameters[0].Value = "TB_SMS_MESSAGE";
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
            strSql.Append("select ID,TID,CALL_INDEX,TYPE,POST_USER_NAME,GET_USER_NAME,PATIENT_SN,PATIENT_MOBILE,PARENT_ID,IS_READ,TITLE,CONTENT,POST_TIME,READ_TIME,STATUS,DATAS,ERROR_MESSAGE FROM TB_SMS_MESSAGE");
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

