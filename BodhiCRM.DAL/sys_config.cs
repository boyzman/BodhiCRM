using System;
using System.Collections.Generic;
using System.Text;
using BodhiCRM.Common;

namespace BodhiCRM.DAL
{
    /// <summary>
    /// 数据访问类:站点配置
    /// </summary>
    public partial class SYS_CONFIG
    {
        private static object lockHelper = new object();

        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public Model.SYS_CONFIG loadConfig(string configFilePath)
        {
            return (Model.SYS_CONFIG)SerializationHelper.Load(typeof(Model.SYS_CONFIG), configFilePath);
        }

        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        public Model.SYS_CONFIG saveConifg(Model.SYS_CONFIG model, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(model, configFilePath);
            }
            return model;
        }

    }
}
