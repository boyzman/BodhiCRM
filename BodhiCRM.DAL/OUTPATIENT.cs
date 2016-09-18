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
	public partial class OUTPATIENT
	{
        private readonly DbHelperOraP DB;
        public OUTPATIENT()
		{}
        public OUTPATIENT(string conStr)
        {
            DB = new DbHelperOraP(conStr);
        }
		#region  BasicMethod

		
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT max(t.cname) cname,MAX(patient_sn) patient_sn,MAX(ID_CARD_CODE) id_card_code,MAX(GENDER_ID) gender_id,MAX(BIRTH_DATE) birth_date,MAX(MOBILE_TEL) mobile_tel,MAX(visit_date) visit_date,t.register_no,replace(wm_concat(distinct soap_text),',',chr(13)) soap_text,  max(DISTINCT ch_disease_name) ch_disease_name,replace(wm_concat(distinct ch_trade_name),',',chr(13)) ch_trade_name  FROM\n" +
            "(SELECT p.*,r.register_no,s.soap_text,d.ch_disease_name,ho.ch_trade_name,r.visit_date FROM his2.opd_register r LEFT JOIN bhp.patient p ON p.patient_sn=r.patient_sn\n" +
            "LEFT JOIN his2.opd_soap s ON r.register_no=s.register_no AND s.CANCEL = 'N'\n" +
            "LEFT JOIN his2.opd_diagnosis d ON r.register_no=d.register_no AND d.CANCEL = 'N'\n" +
            "LEFT OUTER JOIN his2.opd_made_order o ON r.register_no=o.register_no\n" +
            "LEFT OUTER JOIN his2.hospital_order ho ON o.order_code=ho.order_code\n" 
            );
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(") t GROUP BY t.register_no");
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSqlByGroup(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));

            //string sqlString = "SELECT max(t.cname) cname,MAX(patient_sn) patient_sn,MAX(MOBILE_TEL) mobile_tel,MAX(visit_date) visit_date,t.register_no,replace(wm_concat(soap_text),',',chr(13)) soap_text, max(ch_disease_name) ch_disease_name,replace(wm_concat(ch_trade_name),',',chr(13)) ch_trade_name  FROM\n" +
            //"(SELECT p.*,r.register_no,s.soap_text,d.ch_disease_name,ho.ch_trade_name,r.visit_date FROM his2.opd_register r LEFT JOIN bhp.patient p ON p.patient_sn=r.patient_sn\n" +
            //"LEFT JOIN his2.opd_soap s ON r.register_no=s.register_no AND s.CANCEL = 'N'\n" +
            //"LEFT JOIN his2.opd_diagnosis d ON r.register_no=d.register_no AND d.CANCEL = 'N'\n" +
            //"LEFT OUTER JOIN his2.opd_made_order o ON r.register_no=o.register_no\n" +
            //"LEFT OUTER JOIN his2.hospital_order ho ON o.order_code=ho.order_code\n" +
            //"WHERE r.patient_sn='800001774') t GROUP BY t.register_no";

        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT max(t.cname) cname,MAX(patient_sn) patient_sn,MAX(ID_CARD_CODE) id_card_code,MAX(GENDER_ID) gender_id,MAX(BIRTH_DATE) birth_date,MAX(MOBILE_TEL) mobile_tel,MAX(visit_date) visit_date,t.register_no,replace(wm_concat(distinct soap_text),',',chr(13)) soap_text,  max(DISTINCT ch_disease_name) ch_disease_name,replace(wm_concat(distinct ch_trade_name),',',chr(13)) ch_trade_name  FROM\n" +
            "(SELECT p.*,r.register_no,s.soap_text,d.ch_disease_name,ho.ch_trade_name,r.visit_date FROM his2.opd_register r LEFT JOIN tb_patient p ON p.patient_sn=r.patient_sn\n" +
            "LEFT JOIN his2.opd_soap s ON r.register_no=s.register_no AND s.CANCEL = 'N'\n" +
            "LEFT JOIN his2.opd_diagnosis d ON r.register_no=d.register_no AND d.CANCEL = 'N'\n" +
            "LEFT OUTER JOIN his2.opd_made_order o ON r.register_no=o.register_no\n" +
            "LEFT OUTER JOIN his2.hospital_order ho ON o.order_code=ho.order_code\n"
            );
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(") t GROUP BY t.register_no");
            return DbHelperOra.Query(strSql.ToString());
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

