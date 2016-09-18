/**  
* MANAGER_ROLE_VALUE.cs
*
* 功 能： N/A
* 类 名： MANAGER_ROLE_VALUE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/24 18:02:53   N/A    初版
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
	/// 数据访问类:MANAGER_ROLE_VALUE
	/// </summary>
	public partial class MANAGER_ROLE_VALUE
	{
		public MANAGER_ROLE_VALUE()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			int rowsAffected;
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			int result= DbHelperOra.RunProcedure("TB_MANAGER_ROLE_VALUE_Exists",parameters,out rowsAffected);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.MANAGER_ROLE_VALUE model)
		{
			int rowsAffected;
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4),
					new OracleParameter(":ROLE_ID", OracleType.Number,4),
					new OracleParameter(":NAV_NAME", OracleType.VarChar,100),
					new OracleParameter(":ACTION_TYPE", OracleType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ROLE_ID;
			parameters[2].Value = model.NAV_NAME;
			parameters[3].Value = model.ACTION_TYPE;

			DbHelperOra.RunProcedure("TB_MANAGER_ROLE_VALUE_ADD",parameters,out rowsAffected);
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
		///  更新一条数据
		/// </summary>
		public bool Update(BodhiCRM.Model.MANAGER_ROLE_VALUE model)
		{
			int rowsAffected=0;
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,4),
					new OracleParameter(":ROLE_ID", OracleType.Number,4),
					new OracleParameter(":NAV_NAME", OracleType.VarChar,100),
					new OracleParameter(":ACTION_TYPE", OracleType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ROLE_ID;
			parameters[2].Value = model.NAV_NAME;
			parameters[3].Value = model.ACTION_TYPE;

			DbHelperOra.RunProcedure("TB_MANAGER_ROLE_VALUE_Update",parameters,out rowsAffected);
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
			int rowsAffected=0;
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			DbHelperOra.RunProcedure("TB_MANAGER_ROLE_VALUE_Delete",parameters,out rowsAffected);
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
			strSql.Append("delete from TB_MANAGER_ROLE_VALUE ");
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
		public BodhiCRM.Model.MANAGER_ROLE_VALUE GetModel(decimal ID)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.MANAGER_ROLE_VALUE model=new BodhiCRM.Model.MANAGER_ROLE_VALUE();
			DataSet ds= DbHelperOra.RunProcedure("TB_MANAGER_ROLE_VALUE_GetModel",parameters,"ds");
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
		public BodhiCRM.Model.MANAGER_ROLE_VALUE DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.MANAGER_ROLE_VALUE model=new BodhiCRM.Model.MANAGER_ROLE_VALUE();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["ROLE_ID"]!=null && row["ROLE_ID"].ToString()!="")
				{
					model.ROLE_ID=decimal.Parse(row["ROLE_ID"].ToString());
				}
				if(row["NAV_NAME"]!=null)
				{
					model.NAV_NAME=row["NAV_NAME"].ToString();
				}
				if(row["ACTION_TYPE"]!=null)
				{
					model.ACTION_TYPE=row["ACTION_TYPE"].ToString();
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
			strSql.Append("select ID,ROLE_ID,NAV_NAME,ACTION_TYPE ");
			strSql.Append(" FROM TB_MANAGER_ROLE_VALUE ");
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
			strSql.Append("select count(1) FROM TB_MANAGER_ROLE_VALUE ");
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
			strSql.Append(")AS Row, T.*  from TB_MANAGER_ROLE_VALUE T ");
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
			parameters[0].Value = "TB_MANAGER_ROLE_VALUE";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

