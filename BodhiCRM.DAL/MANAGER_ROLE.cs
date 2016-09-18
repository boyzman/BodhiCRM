/**  
* MANAGER_ROLE.cs
*
* 功 能： N/A
* 类 名： MANAGER_ROLE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/24 18:02:50   N/A    初版
*
* Copyright (c) 2012 Lussen Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：卢森科技（青岛）科技服务有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using BodhiCRM.DBUtility;//Please add references
namespace BodhiCRM.DAL
{
	/// <summary>
	/// 数据访问类:MANAGER_ROLE
	/// </summary>
	public partial class MANAGER_ROLE
	{
		public MANAGER_ROLE()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_MANAGER_ROLE");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public int Add(BodhiCRM.Model.MANAGER_ROLE model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_MANAGER_ROLE(");
            strSql.Append("ID,HOSPITAL_CODE,ROLE_NAME,ROLE_TYPE,IS_SYS)");
            strSql.Append(" values (");
            strSql.Append("SEQ_TB_MANAGER_ROLE.nextval,:HOSPITAL_CODE,:ROLE_NAME,:ROLE_TYPE,:IS_SYS)");
            strSql.Append(" returning id into :ReturnValue");
            OracleParameter[] parameters = {
                    new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":ROLE_NAME", OracleType.VarChar,100),
					new OracleParameter(":ROLE_TYPE", OracleType.Number,4),
					new OracleParameter(":IS_SYS", OracleType.Number,4),
                    new OracleParameter(":ReturnValue",OracleType.Number,4)};
            parameters[0].Value = model.HOSPITAL_CODE;
            parameters[1].Value = model.ROLE_NAME;
            parameters[2].Value = model.ROLE_TYPE;
            parameters[3].Value = model.IS_SYS;
            parameters[4].Direction = ParameterDirection.Output;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            StringBuilder strSql2;
            if (model.manager_role_values != null)
            {
                foreach (Model.MANAGER_ROLE_VALUE modelt in model.manager_role_values)
                {
                    strSql2 = new StringBuilder();
                    strSql2.Append("insert into TB_MANAGER_ROLE_VALUE(");
                    strSql2.Append("ID,ROLE_ID,NAV_NAME,ACTION_TYPE)");
                    strSql2.Append(" values (");
                    strSql2.Append("SEQ_TB_MANAGER_ROLE_VALUE.nextval,:ROLE_ID,:NAV_NAME,:ACTION_TYPE)");
                    OracleParameter[] parameters2 = {
						    new OracleParameter(":ROLE_ID", OracleType.Int32,4),
					        new OracleParameter(":NAV_NAME", OracleType.VarChar,100),
					        new OracleParameter(":ACTION_TYPE", OracleType.VarChar,50)};
                    parameters2[0].Direction = ParameterDirection.InputOutput;
                    parameters2[1].Value = modelt.NAV_NAME;
                    parameters2[2].Value = modelt.ACTION_TYPE;
                    cmd = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd);
                }
            }
            DbHelperOra.ExecuteSqlTranWithIndentity(sqllist);
            //int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return Convert.ToInt32(parameters[4].Value);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(BodhiCRM.Model.MANAGER_ROLE model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_MANAGER_ROLE set ");
            strSql.Append("HOSPITAL_CODE=:HOSPITAL_CODE,");
            strSql.Append("ROLE_NAME=:ROLE_NAME,");
            strSql.Append("ROLE_TYPE=:ROLE_TYPE,");
            strSql.Append("IS_SYS=:IS_SYS");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":ROLE_NAME", OracleType.VarChar,100),
					new OracleParameter(":ROLE_TYPE", OracleType.Number,4),
					new OracleParameter(":IS_SYS", OracleType.Number,4),
					new OracleParameter(":ID", OracleType.Number,4)};
            parameters[0].Value = model.HOSPITAL_CODE;
            parameters[1].Value = model.ROLE_NAME;
            parameters[2].Value = model.ROLE_TYPE;
            parameters[3].Value = model.IS_SYS;
            parameters[4].Value = model.ID;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //先删除该角色所有权限
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from TB_MANAGER_ROLE_VALUE where ROLE_ID=:ROLE_ID ");
            OracleParameter[] parameters2 = {
					new OracleParameter(":ROLE_ID", OracleType.Number,4)};
            parameters2[0].Value = model.ID;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            //添加权限
            if (model.manager_role_values != null)
            {
                StringBuilder strSql3;
                foreach (Model.MANAGER_ROLE_VALUE modelt in model.manager_role_values)
                {
                    strSql3 = new StringBuilder();
                    strSql3.Append("insert into TB_MANAGER_ROLE_VALUE(");
                    strSql3.Append("ID,ROLE_ID,NAV_NAME,ACTION_TYPE)");
                    strSql3.Append(" values (");
                    strSql3.Append("SEQ_TB_MANAGER_ROLE_VALUE.nextval,:ROLE_ID,:NAV_NAME,:ACTION_TYPE)");
                    OracleParameter[] parameters3 = {
						    new OracleParameter(":ROLE_ID", OracleType.Int32,4),
					        new OracleParameter(":NAV_NAME", OracleType.VarChar,100),
					        new OracleParameter(":ACTION_TYPE", OracleType.VarChar,50)};
                    parameters3[0].Value = model.ID;
                    parameters3[1].Value = modelt.NAV_NAME;
                    parameters3[2].Value = modelt.ACTION_TYPE;
                    cmd = new CommandInfo(strSql3.ToString(), parameters3);
                    sqllist.Add(cmd);
                }
            }

            int rowsAffected = DbHelperOra.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
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

            List<CommandInfo> sqllist = new List<CommandInfo>();
            //删除管理角色权限
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_manager_role_value ");
            strSql.Append(" where role_id=:role_id");
            OracleParameter[] parameters = {
					new OracleParameter(":role_id", OracleType.Int32,4)};
            parameters[0].Value = ID;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            //删除管理角色
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from TB_manager_role ");
            strSql2.Append(" where id=:id");
            OracleParameter[] parameters2 = {
					new OracleParameter(":id", OracleType.Int32,4)};
            parameters2[0].Value = ID;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperOra.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
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
			strSql.Append("delete from TB_MANAGER_ROLE ");
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
		public BodhiCRM.Model.MANAGER_ROLE GetModel(decimal ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,HOSPITAL_CODE,ROLE_NAME,ROLE_TYPE,IS_SYS from TB_MANAGER_ROLE ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4)			};
            parameters[0].Value = ID;

            BodhiCRM.Model.MANAGER_ROLE model = new BodhiCRM.Model.MANAGER_ROLE();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region 父表信息
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HOSPITAL_CODE"].ToString() != "")
                {
                    model.HOSPITAL_CODE = ds.Tables[0].Rows[0]["HOSPITAL_CODE"].ToString();
                }
                model.ROLE_NAME = ds.Tables[0].Rows[0]["ROLE_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["ROLE_TYPE"].ToString() != "")
                {
                    model.ROLE_TYPE = int.Parse(ds.Tables[0].Rows[0]["ROLE_TYPE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IS_SYS"].ToString() != "")
                {
                    model.IS_SYS = int.Parse(ds.Tables[0].Rows[0]["IS_SYS"].ToString());
                }
                #endregion

                #region 子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,role_id,nav_name,action_type from TB_MANAGER_ROLE_VALUE ");
                strSql2.Append(" where role_id=:role_id");
                OracleParameter[] parameters2 = {
					new OracleParameter(":role_id", OracleType.Int32,4)};
                parameters2[0].Value = ID;
                DataSet ds2 = DbHelperOra.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    List<Model.MANAGER_ROLE_VALUE> models = new List<Model.MANAGER_ROLE_VALUE>();
                    Model.MANAGER_ROLE_VALUE modelt;
                    foreach (DataRow dr in ds2.Tables[0].Rows)
                    {
                        modelt = new Model.MANAGER_ROLE_VALUE();
                        if (dr["ID"].ToString() != "")
                        {
                            modelt.ID = int.Parse(dr["id"].ToString());
                        }
                        if (dr["ROLE_ID"].ToString() != "")
                        {
                            modelt.ROLE_ID = int.Parse(dr["ROLE_ID"].ToString());
                        }
                        modelt.NAV_NAME = dr["NAV_NAME"].ToString();
                        modelt.ACTION_TYPE = dr["ACTION_TYPE"].ToString();
                        models.Add(modelt);
                    }
                    model.manager_role_values = models;
                }
                #endregion

                return model;
            }
            else
            {
                return null;
            }
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BodhiCRM.Model.MANAGER_ROLE DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.MANAGER_ROLE model=new BodhiCRM.Model.MANAGER_ROLE();
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
				if(row["ROLE_NAME"]!=null)
				{
					model.ROLE_NAME=row["ROLE_NAME"].ToString();
				}
				if(row["ROLE_TYPE"]!=null && row["ROLE_TYPE"].ToString()!="")
				{
					model.ROLE_TYPE=decimal.Parse(row["ROLE_TYPE"].ToString());
				}
				if(row["IS_SYS"]!=null && row["IS_SYS"].ToString()!="")
				{
					model.IS_SYS=decimal.Parse(row["IS_SYS"].ToString());
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
            strSql.Append("select ID,HOSPITAL_CODE,ROLE_NAME,ROLE_TYPE,IS_SYS ");
			strSql.Append(" FROM TB_MANAGER_ROLE ");
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
			strSql.Append("select count(1) FROM TB_MANAGER_ROLE ");
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
			strSql.Append(")AS Row, T.*  from TB_MANAGER_ROLE T ");
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
			parameters[0].Value = "TB_MANAGER_ROLE";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
        /// <summary>
        /// 返回角色名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ROLE_NAME from TB_MANAGER_ROLE");
            strSql.Append(" where rownum<2 and id=" + id);
            string title = Convert.ToString(DbHelperOra.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }
		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

