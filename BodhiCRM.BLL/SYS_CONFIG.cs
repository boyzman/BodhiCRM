using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Caching;
using BodhiCRM.Common;

namespace BodhiCRM.BLL
{
    public partial class SYS_CONFIG
    {
        private readonly DAL.SYS_CONFIG dal = new DAL.SYS_CONFIG();

        /// <summary>
        ///  读取配置文件
        /// </summary>
        public Model.SYS_CONFIG loadConfig()
        {
            Model.SYS_CONFIG model = CacheHelper.Get<Model.SYS_CONFIG>(DTKeys.CACHE_SITE_CONFIG);
            if (model == null)
            {
                CacheHelper.Insert(DTKeys.CACHE_SITE_CONFIG, dal.loadConfig(Utils.GetXmlMapPath(DTKeys.FILE_SITE_XML_CONFING)),
                    Utils.GetXmlMapPath(DTKeys.FILE_SITE_XML_CONFING));
                model = CacheHelper.Get<Model.SYS_CONFIG>(DTKeys.CACHE_SITE_CONFIG);
            }
            return model;
        }

        /// <summary>
        ///  保存配置文件
        /// </summary>
        public Model.SYS_CONFIG saveConifg(Model.SYS_CONFIG model)
        {
            return dal.saveConifg(model, Utils.GetXmlMapPath(DTKeys.FILE_SITE_XML_CONFING));
        }

    }
}
