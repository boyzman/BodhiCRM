/**  
* NAVIGATION.cs
*
* 功 能： N/A
* 类 名： NAVIGATION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/25 13:56:23   N/A    初版
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
	/// 数据访问类:NAVIGATION
	/// </summary>
	public partial class NAVIGATION
	{
		public NAVIGATION()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_NAVIGATION");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperOra.Exists(strSql.ToString());
		}
        /// <summary>
        /// 查询是否存在该记录
        /// </summary>
        public bool Exists(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_NAVIGATION");
            strSql.Append(" where name=:name ");
            OracleParameter[] parameters = {
					new OracleParameter(":name", OracleType.VarChar,50)};
            parameters[0].Value = name;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BodhiCRM.Model.NAVIGATION model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_NAVIGATION(");
            strSql.Append("ID,PARENT_ID,CHANNEL_ID,NAV_TYPE,NAME,TITLE,SUB_TITLE,ICON_URL,LINK_URL,SORT_ID,IS_LOCK,REMARK,ACTION_TYPE,IS_SYS,IS_ACCOUNT)");
            strSql.Append(" values (");
            strSql.Append("SEQ_TB_NAVIGATION.nextval,:PARENT_ID,:CHANNEL_ID,:NAV_TYPE,:NAME,:TITLE,:SUB_TITLE,:ICON_URL,:LINK_URL,:SORT_ID,:IS_LOCK,:REMARK,:ACTION_TYPE,:IS_SYS,:IS_ACCOUNT)");
            OracleParameter[] parameters = {
					
					new OracleParameter(":PARENT_ID", OracleType.Number,4),
					new OracleParameter(":CHANNEL_ID", OracleType.Number,4),
					new OracleParameter(":NAV_TYPE", OracleType.VarChar,50),
					new OracleParameter(":NAME", OracleType.VarChar,50),
					new OracleParameter(":TITLE", OracleType.VarChar,100),
					new OracleParameter(":SUB_TITLE", OracleType.VarChar,100),
					new OracleParameter(":ICON_URL", OracleType.VarChar,255),
					new OracleParameter(":LINK_URL", OracleType.VarChar,255),
					new OracleParameter(":SORT_ID", OracleType.Number,4),
					new OracleParameter(":IS_LOCK", OracleType.Number,4),
					new OracleParameter(":REMARK", OracleType.VarChar,500),
					new OracleParameter(":ACTION_TYPE", OracleType.VarChar,500),
					new OracleParameter(":IS_SYS", OracleType.Number,4),
					new OracleParameter(":IS_ACCOUNT", OracleType.Number,4)};
           
            parameters[0].Value = model.PARENT_ID;
            parameters[1].Value = model.CHANNEL_ID;
            parameters[2].Value = model.NAV_TYPE;
            parameters[3].Value = model.NAME;
            parameters[4].Value = model.TITLE;
            parameters[5].Value = model.SUB_TITLE;
            parameters[6].Value = model.ICON_URL;
            parameters[7].Value = model.LINK_URL;
            parameters[8].Value = model.SORT_ID;
            parameters[9].Value = model.IS_LOCK;
            parameters[10].Value = model.REMARK;
            parameters[11].Value = model.ACTION_TYPE;
            parameters[12].Value = model.IS_SYS;
            parameters[13].Value = model.IS_ACCOUNT;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(BodhiCRM.Model.NAVIGATION model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_NAVIGATION set ");
            strSql.Append("PARENT_ID=:PARENT_ID,");
            strSql.Append("CHANNEL_ID=:CHANNEL_ID,");
            strSql.Append("NAV_TYPE=:NAV_TYPE,");
            strSql.Append("NAME=:NAME,");
            strSql.Append("TITLE=:TITLE,");
            strSql.Append("SUB_TITLE=:SUB_TITLE,");
            strSql.Append("ICON_URL=:ICON_URL,");
            strSql.Append("LINK_URL=:LINK_URL,");
            strSql.Append("SORT_ID=:SORT_ID,");
            strSql.Append("IS_LOCK=:IS_LOCK,");
            strSql.Append("REMARK=:REMARK,");
            strSql.Append("ACTION_TYPE=:ACTION_TYPE,");
            strSql.Append("IS_SYS=:IS_SYS,");
            strSql.Append("IS_ACCOUNT=:IS_ACCOUNT");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
					new OracleParameter(":PARENT_ID", OracleType.Number,4),
					new OracleParameter(":CHANNEL_ID", OracleType.Number,4),
					new OracleParameter(":NAV_TYPE", OracleType.VarChar,50),
					new OracleParameter(":NAME", OracleType.VarChar,50),
					new OracleParameter(":TITLE", OracleType.VarChar,100),
					new OracleParameter(":SUB_TITLE", OracleType.VarChar,100),
					new OracleParameter(":ICON_URL", OracleType.VarChar,255),
					new OracleParameter(":LINK_URL", OracleType.VarChar,255),
					new OracleParameter(":SORT_ID", OracleType.Number,4),
					new OracleParameter(":IS_LOCK", OracleType.Number,4),
					new OracleParameter(":REMARK", OracleType.VarChar,500),
					new OracleParameter(":ACTION_TYPE", OracleType.VarChar,500),
					new OracleParameter(":IS_SYS", OracleType.Number,4),
					new OracleParameter(":IS_ACCOUNT", OracleType.Number,4),
					new OracleParameter(":ID", OracleType.Number,4)};
            parameters[0].Value = model.PARENT_ID;
            parameters[1].Value = model.CHANNEL_ID;
            parameters[2].Value = model.NAV_TYPE;
            parameters[3].Value = model.NAME;
            parameters[4].Value = model.TITLE;
            parameters[5].Value = model.SUB_TITLE;
            parameters[6].Value = model.ICON_URL;
            parameters[7].Value = model.LINK_URL;
            parameters[8].Value = model.SORT_ID;
            parameters[9].Value = model.IS_LOCK;
            parameters[10].Value = model.REMARK;
            parameters[11].Value = model.ACTION_TYPE;
            parameters[12].Value = model.IS_SYS;
            parameters[13].Value = model.IS_ACCOUNT;
            parameters[14].Value = model.ID;

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
		public bool Delete(int ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_navigation");
            strSql.Append(" where id in(" + GetIds(ID) + ")");

            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
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
			strSql.Append("delete from TB_NAVIGATION ");
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
		public BodhiCRM.Model.NAVIGATION GetModel(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,PARENT_ID,CHANNEL_ID,NAV_TYPE,NAME,TITLE,SUB_TITLE,ICON_URL,LINK_URL,SORT_ID,IS_LOCK,REMARK,ACTION_TYPE,IS_SYS,IS_ACCOUNT ");
			strSql.Append(" from TB_NAVIGATION ");
			strSql.Append(" where ID="+ID+" " );
			BodhiCRM.Model.NAVIGATION model=new BodhiCRM.Model.NAVIGATION();
			DataSet ds=DbHelperOra.Query(strSql.ToString());
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
		public BodhiCRM.Model.NAVIGATION DataRowToModel(DataRow row)
		{
			BodhiCRM.Model.NAVIGATION model=new BodhiCRM.Model.NAVIGATION();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["PARENT_ID"]!=null && row["PARENT_ID"].ToString()!="")
				{
					model.PARENT_ID=decimal.Parse(row["PARENT_ID"].ToString());
				}
				if(row["CHANNEL_ID"]!=null && row["CHANNEL_ID"].ToString()!="")
				{
					model.CHANNEL_ID=decimal.Parse(row["CHANNEL_ID"].ToString());
				}
				if(row["NAV_TYPE"]!=null)
				{
					model.NAV_TYPE=row["NAV_TYPE"].ToString();
				}
				if(row["NAME"]!=null)
				{
					model.NAME=row["NAME"].ToString();
				}
				if(row["TITLE"]!=null)
				{
					model.TITLE=row["TITLE"].ToString();
				}
				if(row["SUB_TITLE"]!=null)
				{
					model.SUB_TITLE=row["SUB_TITLE"].ToString();
				}
				if(row["ICON_URL"]!=null)
				{
					model.ICON_URL=row["ICON_URL"].ToString();
				}
				if(row["LINK_URL"]!=null)
				{
					model.LINK_URL=row["LINK_URL"].ToString();
				}
				if(row["SORT_ID"]!=null && row["SORT_ID"].ToString()!="")
				{
					model.SORT_ID=decimal.Parse(row["SORT_ID"].ToString());
				}
				if(row["IS_LOCK"]!=null && row["IS_LOCK"].ToString()!="")
				{
					model.IS_LOCK=decimal.Parse(row["IS_LOCK"].ToString());
				}
				if(row["REMARK"]!=null)
				{
					model.REMARK=row["REMARK"].ToString();
				}
				if(row["ACTION_TYPE"]!=null)
				{
					model.ACTION_TYPE=row["ACTION_TYPE"].ToString();
				}
				if(row["IS_SYS"]!=null && row["IS_SYS"].ToString()!="")
				{
					model.IS_SYS=decimal.Parse(row["IS_SYS"].ToString());
				}
				if(row["IS_ACCOUNT"]!=null && row["IS_ACCOUNT"].ToString()!="")
				{
					model.IS_ACCOUNT=decimal.Parse(row["IS_ACCOUNT"].ToString());
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
			strSql.Append("select ID,PARENT_ID,CHANNEL_ID,NAV_TYPE,NAME,TITLE,SUB_TITLE,ICON_URL,LINK_URL,SORT_ID,IS_LOCK,REMARK,ACTION_TYPE,IS_SYS,IS_ACCOUNT ");
			strSql.Append(" FROM TB_NAVIGATION ");
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
			strSql.Append("select count(1) FROM TB_NAVIGATION ");
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
			strSql.Append(")AS Row, T.*  from TB_NAVIGATION T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOra.Query(strSql.ToString());
		}

		/*
		*/
        /// <summary>
        /// 获取类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="nav_type">导航类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(int parent_id, string nav_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PARENT_ID,CHANNEL_ID,NAV_TYPE,NAME,TITLE,SUB_TITLE,ICON_URL,LINK_URL,SORT_ID,IS_LOCK,REMARK,ACTION_TYPE,IS_SYS ");
            strSql.Append(" FROM TB_NAVIGATION");
            strSql.Append(" where nav_type='" + nav_type + "'");
            strSql.Append(" order by sort_id asc,id desc");
            DataSet ds = DbHelperOra.Query(strSql.ToString());
            //重组列表
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //创建一个新的DataTable增加一个深度字段
            DataTable newData = new DataTable();
            newData.Columns.Add("id", typeof(int));
            newData.Columns.Add("parent_id", typeof(int));
            newData.Columns.Add("channel_id", typeof(int));
            newData.Columns.Add("class_layer", typeof(int));
            newData.Columns.Add("nav_type", typeof(string));
            newData.Columns.Add("name", typeof(string));
            newData.Columns.Add("title", typeof(string));
            newData.Columns.Add("sub_title", typeof(string));
            newData.Columns.Add("icon_url", typeof(string));
            newData.Columns.Add("link_url", typeof(string));
            newData.Columns.Add("sort_id", typeof(int));
            newData.Columns.Add("is_lock", typeof(int));
            newData.Columns.Add("remark", typeof(string));
            newData.Columns.Add("action_type", typeof(string));
            newData.Columns.Add("is_sys", typeof(int));
           
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, parent_id, 0);
            return newData;
        }
        /// <summary>
        /// 根据导航的名称查询其ID
        /// </summary>
        public int GetNavId(string nav_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from TB_NAVIGATION");
            strSql.Append(" where rownum<2 and name=:nav_name");
            OracleParameter[] parameters = {
					new OracleParameter(":nav_name", OracleType.VarChar,50)};
            parameters[0].Value = nav_name;
            string str = Convert.ToString(DbHelperOra.GetSingle(strSql.ToString(), parameters));
            return Utils.StrToInt(str, 0);
        }
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_NAVIGATION set " + strValue);
            strSql.Append(" where ID=" + id);
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
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
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(string name, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_NAVIGATION set " + strValue);
            strSql.Append(" where NAME='" + name + "'");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		#endregion  Method
        #region 私有方法===============================


        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, int parent_id, int class_layer)
        {
            class_layer++;
            DataRow[] dr = oldData.Select("parent_id=" + parent_id);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["id"] = int.Parse(dr[i]["id"].ToString());
                row["parent_id"] = int.Parse(dr[i]["parent_id"].ToString());
                row["channel_id"] = int.Parse(dr[i]["channel_id"].ToString());
                row["class_layer"] = class_layer;
                row["nav_type"] = dr[i]["nav_type"].ToString();
                row["name"] = dr[i]["name"].ToString();
                row["title"] = dr[i]["title"].ToString();
                row["sub_title"] = dr[i]["sub_title"].ToString();
                row["icon_url"] = dr[i]["icon_url"].ToString();
                row["link_url"] = dr[i]["link_url"].ToString();
                row["sort_id"] = int.Parse(dr[i]["sort_id"].ToString());
                row["is_lock"] = int.Parse(dr[i]["is_lock"].ToString());
                row["remark"] = dr[i]["remark"].ToString();
                row["action_type"] = dr[i]["action_type"].ToString();
                row["is_sys"] = int.Parse(dr[i]["is_sys"].ToString());
                
                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, int.Parse(dr[i]["id"].ToString()), class_layer);
            }
        }

        /// <summary>
        /// 获取父类下的所有子类ID
        /// </summary>
        private void GetChildIds(DataTable dt, int parent_id, ref string ids)
        {
            DataRow[] dr = dt.Select("parent_id=" + parent_id);
            for (int i = 0; i < dr.Length; i++)
            {
                ids += dr[i]["id"].ToString() + ",";
                //调用自身迭代
                this.GetChildIds(dt, int.Parse(dr[i]["id"].ToString()), ref ids);
            }
        }

        /// <summary>
        /// 获取父类下的所有子类ID(含自己本身)
        /// </summary>
        public string GetIds(int parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,parent_id");
            strSql.Append(" FROM tb_navigation");
            DataSet ds = DbHelperOra.Query(strSql.ToString());
            string ids = parent_id.ToString() + ",";
            GetChildIds(ds.Tables[0], parent_id, ref ids);
            return ids.TrimEnd(',');
        }
        #endregion
	}
}

