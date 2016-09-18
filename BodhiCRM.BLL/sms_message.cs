using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections.Generic;
using BodhiCRM.Common;

namespace BodhiCRM.BLL
{
    /// <summary>
    /// 手机短信
    /// </summary>
    public partial class SMS_MESSAGE
    {
        private readonly Model.SYS_CONFIG siteConfig = new BLL.SYS_CONFIG().loadConfig(); //获得站点配置信息
        private readonly BodhiCRM.DAL.SMS_MESSAGE dal = new BodhiCRM.DAL.SMS_MESSAGE();
        public SMS_MESSAGE()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BodhiCRM.Model.SMS_MESSAGE model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BodhiCRM.Model.SMS_MESSAGE model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(BodhiCRM.Common.PageValidate.SafeLongFilter(IDlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BodhiCRM.Model.SMS_MESSAGE GetModel(decimal ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public BodhiCRM.Model.SMS_MESSAGE GetModelByCache(decimal ID)
        {

            string CacheKey = "SMS_MESSAGEModel-" + ID;
            object objModel = BodhiCRM.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = BodhiCRM.Common.ConfigHelper.GetConfigInt("ModelCache");
                        BodhiCRM.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (BodhiCRM.Model.SMS_MESSAGE)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BodhiCRM.Model.SMS_MESSAGE> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BodhiCRM.Model.SMS_MESSAGE> DataTableToList(DataTable dt)
        {
            List<BodhiCRM.Model.SMS_MESSAGE> modelList = new List<BodhiCRM.Model.SMS_MESSAGE>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BodhiCRM.Model.SMS_MESSAGE model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion  BasicMethod


        /// <summary>
        /// 发送手机短信
        /// </summary>
        /// <param name="mobiles">手机号码，以英文“,”逗号分隔开</param>
        /// <param name="name">姓名，以英文“,”逗号分隔开</param>
        /// <param name="content">短信内容</param>
        /// <param name="arrData">短信关键字(固定内容)</param>
        /// <param name="call_index">短信模板别名</param>
        /// <param name="msg">返回提示信息</param>
        /// <returns>bool</returns>
        public bool Send(string mobiles, string names, string content, List<string> arrData,string call_index, out string msg)
        {
            SMSService.TemplateSMSServiceClient smsClient = new SMSService.TemplateSMSServiceClient();
            Model.SMS_MESSAGE model = new Model.SMS_MESSAGE();
            Model.SMS_TEMPLATE model_t = new Model.SMS_TEMPLATE();
            BLL.SMS_TEMPLATE bll_t=new BLL.SMS_TEMPLATE();
            BLL.PATIENT bll_p=new PATIENT();
            //检查手机号码，如果超过2000则分批发送
            int sucCount = 0; //成功提交数量
            int failCount = 0; //失败提交数量
            string errorMsg = string.Empty; //错误消息
            string[] oldMobileArr = mobiles.Split(',');
            string[] arrDa = arrData.ToArray();
            int batch = oldMobileArr.Length / 2000 + 1; //2000条为一批，求出分多少批

            for (int i = 0; i < batch; i++)
            {
                StringBuilder sb = new StringBuilder();
                int sendCount = 0; //发送数量
                int maxLenght = (i + 1) * 2000; //循环最大的数

                //检测号码，忽略不合格的，重新组合
                for (int j = 0; j < oldMobileArr.Length && j < maxLenght; j++)
                {
                    int arrNum = j + (i * 2000);
                    string pattern = @"^1\d{10}$";
                    string mobile = oldMobileArr[arrNum].Trim();
                    Regex r = new Regex(pattern, RegexOptions.IgnoreCase); //正则表达式实例，不区分大小写
                    Match m = r.Match(mobile); //搜索匹配项
                    if (m != null)
                    {
                        sendCount++;
                        sb.Append(mobile + ",");
                    }
                }

                //发送短信
                if (sb.ToString().Length > 0)
                {
                    try
                    {
                        string[] arrMobile = sb.ToString().Split(',');
                        List<string> arrName = new List<string>();
                        
                        if (!string.IsNullOrEmpty(names))
                        {
                            arrName = new List<string>(names.Split(','));   
                        }
                        
                        //string[] arrName = sName.Split(',');
                        int j = 0;
                        //int success = 0;
                        //int fail = 0;
                        foreach (string s in arrMobile)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                List<string> listData = new List<string>(arrDa);
                                String key = call_index;
                                String toTel = s;
                                //List<string> toDate = arrData;
                                if (!string.IsNullOrEmpty(arrName[j]))
                                {
                                    listData.Insert(0, arrName[j]);
                                }
                                string[] toDate = listData.ToArray();
                                String outMsg = String.Empty;
                                bool state = smsClient.SendTemplateSMSS(key, toTel, toDate, out outMsg);
                                model.CALL_INDEX = key;
                                model.CONTENT = bll_t.GetModelByCode(key).CONTENT;
                                model.DATAS = Utils.GetArrayStr(listData,",");
                                model.GET_USER_NAME = s;
                                model.IS_READ = "N";
                                model.PATIENT_MOBILE = s;
                                model.POST_TIME = DateTime.Now.ToString();
                                model.TID = bll_t.GetModelByCode(key).ID;
                                model.PATIENT_SN = bll_p.GetModelByMobile(s).PATIENT_SN;
                                if (state)
                                {
                                    sucCount++;
                                    model.STATUS = "Y";
                                    model.ERROR_MESSAGE = "";
                                }
                                else
                                {
                                    failCount++;
                                    errorMsg = "提交失败，错误提示：" + outMsg;
                                    model.STATUS = "N";
                                    model.ERROR_MESSAGE = errorMsg;
                                }
                                bool result = this.Add(model);
                               
                            }
                            j++;
                        }
                      
                    }
                    catch
                    {
                        //没有动作
                    }
                }
              
            }

            //返回状态
            if (sucCount > 0)
            {
                msg = "成功提交" + sucCount + "条，失败" + failCount + "条";
                return true;
            }
            msg = errorMsg;
            return false;
        }

      

    }
}
