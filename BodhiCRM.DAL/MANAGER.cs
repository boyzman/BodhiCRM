/**  
* MANAGER.cs
*
* 功 能： N/A
* 类 名： MANAGER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/24 18:02:49   N/A    初版
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
using BodhiCRM.Common;

namespace BodhiCRM.DAL
{
	/// <summary>
	/// 数据访问类:MANAGER
	/// </summary>
	public partial class MANAGER
	{
		public MANAGER()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_MANAGER");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
		}
        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_MANAGER");
            strSql.Append(" where user_name=:user_name ");
            OracleParameter[] parameters = {
					new OracleParameter(":user_name", OracleType.VarChar,100)};
            parameters[0].Value = user_name;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		///  增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.MANAGER model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_MANAGER(");
            strSql.Append("ID,HOSPITAL_CODE,ROLE_ID,ROLE_TYPE,USER_NAME,PASSWORD,SALT,REAL_NAME,TELEPHONE,EMAIL,IS_LOCK,ADD_TIME)");
            strSql.Append(" values (");
            strSql.Append("SEQ_TB_MANAGER.nextval,:HOSPITAL_CODE,:ROLE_ID,:ROLE_TYPE,:USER_NAME,:PASSWORD,:SALT,:REAL_NAME,:TELEPHONE,:EMAIL,:IS_LOCK,:ADD_TIME)");
            OracleParameter[] parameters = {
					
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":ROLE_ID", OracleType.Number,4),
					new OracleParameter(":ROLE_TYPE", OracleType.Number,4),
					new OracleParameter(":USER_NAME", OracleType.VarChar,20),
					new OracleParameter(":PASSWORD", OracleType.VarChar,100),
					new OracleParameter(":SALT", OracleType.VarChar,20),
					new OracleParameter(":REAL_NAME", OracleType.VarChar,50),
					new OracleParameter(":TELEPHONE", OracleType.VarChar,30),
					new OracleParameter(":EMAIL", OracleType.VarChar,30),
					new OracleParameter(":IS_LOCK", OracleType.Number,4),
					new OracleParameter(":ADD_TIME", OracleType.DateTime)};
           
            parameters[0].Value = model.HOSPITAL_CODE;
            parameters[1].Value = model.ROLE_ID;
            parameters[2].Value = model.ROLE_TYPE;
            parameters[3].Value = model.USER_NAME;
            parameters[4].Value = model.PASSWORD;
            parameters[5].Value = model.SALT;
            parameters[6].Value = model.REAL_NAME;
            parameters[7].Value = model.TELEPHONE;
            parameters[8].Value = model.EMAIL;
            parameters[9].Value = model.IS_LOCK;
            parameters[10].Value = model.ADD_TIME;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
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
		///  更新一条数据
		/// </summary>
		public bool Update(BodhiCRM.Model.MANAGER model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_MANAGER set ");
            strSql.Append("HOSPITAL_CODE=:HOSPITAL_CODE,");
            strSql.Append("ROLE_ID=:ROLE_ID,");
            strSql.Append("ROLE_TYPE=:ROLE_TYPE,");
            strSql.Append("USER_NAME=:USER_NAME,");
            strSql.Append("PASSWORD=:PASSWORD,");
            strSql.Append("SALT=:SALT,");
            strSql.Append("REAL_NAME=:REAL_NAME,");
            strSql.Append("TELEPHONE=:TELEPHONE,");
            strSql.Append("EMAIL=:EMAIL,");
            strSql.Append("IS_LOCK=:IS_LOCK,");
            strSql.Append("ADD_TIME=:ADD_TIME");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":ROLE_ID", OracleType.Number,4),
					new OracleParameter(":ROLE_TYPE", OracleType.Number,4),
					new OracleParameter(":USER_NAME", OracleType.VarChar,20),
					new OracleParameter(":PASSWORD", OracleType.VarChar,100),
					new OracleParameter(":SALT", OracleType.VarChar,20),
					new OracleParameter(":REAL_NAME", OracleType.VarChar,50),
					new OracleParameter(":TELEPHONE", OracleType.VarChar,30),
					new OracleParameter(":EMAIL", OracleType.VarChar,30),
					new OracleParameter(":IS_LOCK", OracleType.Number,4),
					new OracleParameter(":ADD_TIME", OracleType.DateTime),
					new OracleParameter(":ID", OracleType.Number,4)};
            parameters[0].Value = model.HOSPITAL_CODE;
            parameters[1].Value = model.ROLE_ID;
            parameters[2].Value = model.ROLE_TYPE;
            parameters[3].Value = model.USER_NAME;
            parameters[4].Value = model.PASSWORD;
            parameters[5].Value = model.SALT;
            parameters[6].Value = model.REAL_NAME;
            parameters[7].Value = model.TELEPHONE;
            parameters[8].Value = model.EMAIL;
            parameters[9].Value = model.IS_LOCK;
            parameters[10].Value = model.ADD_TIME;
            parameters[11].Value = model.ID;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_MANAGER ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
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
			strSql.Append("delete from TB_MANAGER ");
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
		public BodhiCRM.Model.MANAGER GetModel(decimal ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,HOSPITAL_CODE,ROLE_ID,ROLE_TYPE,USER_NAME,PASSWORD,SALT,REAL_NAME,TELEPHONE,EMAIL,IS_LOCK,ADD_TIME from TB_MANAGER ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;

            BodhiCRM.Model.MANAGER model = new BodhiCRM.Model.MANAGER();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
		}
        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.MANAGER GetModel(string user_name, string password,string hospital_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from TB_MANAGER ");
            strSql.Append(" where USER_NAME=:USER_NAME and PASSWORD=:PASSWORD and HOSPITAL_CODE=:HOSPITAL_CODE and is_lock=0");
            OracleParameter[] parameters = {
					new OracleParameter(":USER_NAME", OracleType.VarChar,20),
                     new OracleParameter(":PASSWORD", OracleType.VarChar,100),
                     new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3)                       
                                           };
            parameters[0].Value = user_name;
            parameters[1].Value = password;
            parameters[2].Value = hospital_code;
            BodhiCRM.Model.MANAGER model = new BodhiCRM.Model.MANAGER();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
		public BodhiCRM.Model.MANAGER DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.MANAGER model=new BodhiCRM.Model.MANAGER();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["HOSPITAL_CODE"]!=null && row["HOSPITAL_CODE"].ToString()!="")
				{
                    model.HOSPITAL_CODE = row["HOSPITAL_CODE"].ToString();
				}
				if(row["ROLE_ID"]!=null && row["ROLE_ID"].ToString()!="")
				{
					model.ROLE_ID=decimal.Parse(row["ROLE_ID"].ToString());
				}
				if(row["ROLE_TYPE"]!=null && row["ROLE_TYPE"].ToString()!="")
				{
					model.ROLE_TYPE=decimal.Parse(row["ROLE_TYPE"].ToString());
				}
				if(row["USER_NAME"]!=null)
				{
					model.USER_NAME=row["USER_NAME"].ToString();
				}
				if(row["PASSWORD"]!=null)
				{
					model.PASSWORD=row["PASSWORD"].ToString();
				}
				if(row["SALT"]!=null)
				{
					model.SALT=row["SALT"].ToString();
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
				if(row["IS_LOCK"]!=null && row["IS_LOCK"].ToString()!="")
				{
					model.IS_LOCK=decimal.Parse(row["IS_LOCK"].ToString());
				}
				if(row["ADD_TIME"]!=null && row["ADD_TIME"].ToString()!="")
				{
					model.ADD_TIME=DateTime.Parse(row["ADD_TIME"].ToString());
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
			strSql.Append("select ID,HOSPITAL_CODE,ROLE_ID,ROLE_TYPE,USER_NAME,PASSWORD,SALT,REAL_NAME,TELEPHONE,EMAIL,IS_LOCK,ADD_TIME ");
			strSql.Append(" FROM TB_MANAGER ");
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
			strSql.Append("select count(1) FROM TB_MANAGER ");
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
			strSql.Append(")AS Row, T.*  from TB_MANAGER T ");
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
			parameters[0].Value = "TB_MANAGER";
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
            strSql.Append("select ID,HOSPITAL_CODE,ROLE_ID,ROLE_TYPE,USER_NAME,PASSWORD,SALT,REAL_NAME,TELEPHONE,EMAIL,IS_LOCK,ADD_TIME FROM TB_MANAGER");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion  Method
		#region  MethodEx
        /// <summary>
        /// 根据用户名取得Salt
        /// </summary>
        public string GetSalt(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select salt from TB_MANAGER");
            strSql.Append(" where rownum<2 and user_name=:user_name");
            OracleParameter[] parameters = {
                    new OracleParameter(":user_name", OracleType.VarChar,100)};
            parameters[0].Value = user_name;
            string salt = Convert.ToString(DbHelperOra.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(salt))
            {
                return "";
            }
            return salt;
        }
		#endregion  MethodEx
	}
}

