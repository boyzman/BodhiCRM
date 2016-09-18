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
        public SMS_MESSAGE()
        { }

        /// <summary>
        /// 发送手机短信
        /// </summary>
        /// <param name="mobiles">手机号码，以英文“,”逗号分隔开</param>
        /// <param name="content">短信内容</param>
        /// <param name="arrData">短信关键字</param>
        /// <param name="call_index">短信模板别名</param>
        /// <param name="msg">返回提示信息</param>
        /// <returns>bool</returns>
        public bool Send(string mobiles, string content, string[] arrData,string call_index, out string msg)
        {
            SMSService.TemplateSMSServiceClient smsClient = new SMSService.TemplateSMSServiceClient();
            //检查手机号码，如果超过2000则分批发送
            int sucCount = 0; //成功提交数量
            int failCount = 0; //失败提交数量
            string errorMsg = string.Empty; //错误消息
            string[] oldMobileArr = mobiles.Split(',');
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
                        //string[] arrName = sName.Split(',');
                        int j = 0;
                        //int success = 0;
                        //int fail = 0;
                        foreach (string s in arrMobile)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                String key = call_index;
                                String toTel = s;
                                String[] toDate = arrData;
                                String outMsg = String.Empty;
                                bool state = smsClient.SendTemplateSMSS(key, toTel, toDate, out outMsg);
                                if (state)
                                {
                                    sucCount++;
                                }
                                else
                                {
                                    failCount++;
                                    errorMsg = "提交失败，错误提示：" + outMsg;
                                }

                            }
                            j++;
                        }
                        
                        //string result = Utils.HttpPost(siteConfig.smsapiurl,
                        //    "cmd=tx&pass=" + pass + "&uid=" + siteConfig.smsusername + "&pwd=" + siteConfig.smspassword + "&mobile=" + Utils.DelLastComma(sb.ToString()) + "&encode=utf8&content=" + Utils.UrlEncode(content));
                        //string[] strArr = result.Split(new string[] { "||" }, StringSplitOptions.None);
                        //if (strArr[0] != "100")
                        //{
                        //    errorMsg = "提交失败，错误提示：" + strArr[1];
                        //    continue;
                        //}
                        //sucCount += sendCount; //成功数量
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
