/**  
* DEPARTMENT.cs
*
* 功 能： N/A
* 类 名： DEPARTMENT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/30 17:31:53   N/A    初版
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
	/// 数据访问类:DEPARTMENT
	/// </summary>
	public partial class DEPARTMENT
	{
		public DEPARTMENT()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_DEPARTMENT");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsLevel(string level)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_DEPARTMENT");
            strSql.Append(" where DEPT_LEVEL=:DEPT_LEVEL ");
            OracleParameter[] parameters = {
					new OracleParameter(":DEPT_LEVEL", OracleType.VarChar,22)			};
            parameters[0].Value = level;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.DEPARTMENT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_DEPARTMENT(");
			strSql.Append("ID,HOSPITAL_CODE,DEPT_LEVEL,DEPT_UPLEVEL,DEPT_NAME,DEPT_REMARK,ADD_TIME,ACTIVE,IS_SYS)");
			strSql.Append(" values (");
            strSql.Append("SEQ_TB_DEPARTMENT.nextval,:HOSPITAL_CODE,:DEPT_LEVEL,:DEPT_UPLEVEL,:DEPT_NAME,:DEPT_REMARK,:ADD_TIME,:ACTIVE,:IS_SYS)");
			OracleParameter[] parameters = {
					
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":DEPT_LEVEL", OracleType.VarChar,4),
					new OracleParameter(":DEPT_UPLEVEL", OracleType.VarChar,4),
					new OracleParameter(":DEPT_NAME", OracleType.VarChar,20),
					new OracleParameter(":DEPT_REMARK", OracleType.VarChar,200),
					new OracleParameter(":ADD_TIME", OracleType.DateTime),
					new OracleParameter(":ACTIVE", OracleType.VarChar,1),
					new OracleParameter(":IS_SYS", OracleType.VarChar,1)};
			
			parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.DEPT_LEVEL;
			parameters[2].Value = model.DEPT_UPLEVEL;
			parameters[3].Value = model.DEPT_NAME;
			parameters[4].Value = model.DEPT_REMARK;
			parameters[5].Value = model.ADD_TIME;
			parameters[6].Value = model.ACTIVE;
			parameters[7].Value = model.IS_SYS;

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
		public bool Update(BodhiCRM.Model.DEPARTMENT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_DEPARTMENT set ");
			strSql.Append("HOSPITAL_CODE=:HOSPITAL_CODE,");
			strSql.Append("DEPT_LEVEL=:DEPT_LEVEL,");
			strSql.Append("DEPT_UPLEVEL=:DEPT_UPLEVEL,");
			strSql.Append("DEPT_NAME=:DEPT_NAME,");
			strSql.Append("DEPT_REMARK=:DEPT_REMARK,");
			strSql.Append("ADD_TIME=:ADD_TIME,");
			strSql.Append("ACTIVE=:ACTIVE,");
			strSql.Append("IS_SYS=:IS_SYS");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":HOSPITAL_CODE", OracleType.VarChar,3),
					new OracleParameter(":DEPT_LEVEL", OracleType.VarChar,4),
					new OracleParameter(":DEPT_UPLEVEL", OracleType.VarChar,4),
					new OracleParameter(":DEPT_NAME", OracleType.VarChar,20),
					new OracleParameter(":DEPT_REMARK", OracleType.VarChar,200),
					new OracleParameter(":ADD_TIME", OracleType.DateTime),
					new OracleParameter(":ACTIVE", OracleType.VarChar,1),
					new OracleParameter(":IS_SYS", OracleType.VarChar,1),
					new OracleParameter(":ID", OracleType.Number,4)};
			parameters[0].Value = model.HOSPITAL_CODE;
			parameters[1].Value = model.DEPT_LEVEL;
			parameters[2].Value = model.DEPT_UPLEVEL;
			parameters[3].Value = model.DEPT_NAME;
			parameters[4].Value = model.DEPT_REMARK;
			parameters[5].Value = model.ADD_TIME;
			parameters[6].Value = model.ACTIVE;
			parameters[7].Value = model.IS_SYS;
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
			strSql.Append("delete from TB_DEPARTMENT ");
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
			strSql.Append("delete from TB_DEPARTMENT ");
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
		public BodhiCRM.Model.DEPARTMENT GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,HOSPITAL_CODE,DEPT_LEVEL,DEPT_UPLEVEL,DEPT_NAME,DEPT_REMARK,ADD_TIME,ACTIVE,IS_SYS from TB_DEPARTMENT ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,22)			};
			parameters[0].Value = ID;

			BodhiCRM.Model.DEPARTMENT model=new BodhiCRM.Model.DEPARTMENT();
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
		public BodhiCRM.Model.DEPARTMENT DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.DEPARTMENT model=new BodhiCRM.Model.DEPARTMENT();
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
				if(row["DEPT_LEVEL"]!=null)
				{
					model.DEPT_LEVEL=row["DEPT_LEVEL"].ToString();
				}
				if(row["DEPT_UPLEVEL"]!=null)
				{
					model.DEPT_UPLEVEL=row["DEPT_UPLEVEL"].ToString();
				}
				if(row["DEPT_NAME"]!=null)
				{
					model.DEPT_NAME=row["DEPT_NAME"].ToString();
				}
				if(row["DEPT_REMARK"]!=null)
				{
					model.DEPT_REMARK=row["DEPT_REMARK"].ToString();
				}
				if(row["ADD_TIME"]!=null && row["ADD_TIME"].ToString()!="")
				{
					model.ADD_TIME=DateTime.Parse(row["ADD_TIME"].ToString());
				}
				if(row["ACTIVE"]!=null)
				{
					model.ACTIVE=row["ACTIVE"].ToString();
				}
				if(row["IS_SYS"]!=null)
				{
					model.IS_SYS=row["IS_SYS"].ToString();
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
			strSql.Append("select ID,HOSPITAL_CODE,DEPT_LEVEL,DEPT_UPLEVEL,DEPT_NAME,DEPT_REMARK,ADD_TIME,ACTIVE,IS_SYS ");
			strSql.Append(" FROM TB_DEPARTMENT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}
        /// <summary>
        /// 获取类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="nav_type">导航类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetList_DataTable(string DEPT_UPLEVEL,string HOSPITAL_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,HOSPITAL_CODE,DEPT_LEVEL,DEPT_UPLEVEL,DEPT_NAME,DEPT_REMARK,ADD_TIME,ACTIVE,IS_SYS ");
            strSql.Append(" FROM TB_DEPARTMENT");
            strSql.Append(" where ACTIVE='Y' and HOSPITAL_CODE='"+HOSPITAL_CODE+"'");
            strSql.Append(" order by HOSPITAL_CODE asc,ID desc");
            DataSet ds = DbHelperOra.Query(strSql.ToString());
            //重组列表
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //创建一个新的DataTable增加一个深度字段
            DataTable newData = new DataTable();
            newData.Columns.Add("ID", typeof(int));
            newData.Columns.Add("HOSPITAL_CODE", typeof(string));
            newData.Columns.Add("DEPT_LEVEL", typeof(string));
            newData.Columns.Add("DEPT_UPLEVEL", typeof(string));
            newData.Columns.Add("DEPT_NAME", typeof(string));
            newData.Columns.Add("DEPT_REMARK", typeof(string));
            newData.Columns.Add("ADD_TIME", typeof(string));
            newData.Columns.Add("ACTIVE", typeof(string));
            newData.Columns.Add("IS_SYS", typeof(string));
            newData.Columns.Add("CLASS_LAYER", typeof(int));
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, DEPT_UPLEVEL, 0);
            return newData;
        }
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TB_DEPARTMENT ");
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
			strSql.Append(")AS Row, T.*  from TB_DEPARTMENT T ");
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
			parameters[0].Value = "TB_DEPARTMENT";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, string parent_id, int class_layer)
        {
            class_layer++;
            DataRow[] dr = oldData.Select("DEPT_UPLEVEL=" + parent_id);
            for (int i = 0; i < dr.Length; i++)
            {
               
                //添加一行数据
                DataRow row = newData.NewRow();
                row["ID"] = int.Parse(dr[i]["ID"].ToString());
                row["HOSPITAL_CODE"] = dr[i]["HOSPITAL_CODE"].ToString();
                row["DEPT_LEVEL"] = dr[i]["DEPT_LEVEL"].ToString();
                row["DEPT_UPLEVEL"] = dr[i]["DEPT_UPLEVEL"].ToString();
                row["DEPT_NAME"] = dr[i]["DEPT_NAME"].ToString();
                row["DEPT_REMARK"] = dr[i]["DEPT_REMARK"].ToString();
                row["ADD_TIME"] = dr[i]["ADD_TIME"].ToString();
                row["ACTIVE"] = dr[i]["ACTIVE"].ToString();
                row["IS_SYS"] = dr[i]["IS_SYS"].ToString();
                row["CLASS_LAYER"] = class_layer;
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, dr[i]["DEPT_LEVEL"].ToString(), class_layer);
            }
        }
        /// <summary>
        /// 获取最大level
        /// </summary>
        public string GetMaxLevel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(DEPT_LEVEL)+1 FROM TB_DEPARTMENT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0001";
            }
            else
            {
                return obj.ToString().PadLeft(4,'0');
            }
        }
       
		#endregion  ExtensionMethod
	}
}

