using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Collections.Specialized;
using System.Collections;

using Asus.Bussiness.Map;



namespace BatchLibrary.App
{
    public abstract class BaseApp
    {
        private ILog log; 
        
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BaseApp));
        
        //protected  IDataFarm m_Farm;

        public BaseApp()
        {
            log4net.Config.XmlConfigurator.Configure();

            log = LogManager.GetLogger(this.GetType());

            List<DbConnStringMap> list = LoginInfo.SystemDbList;
            
            foreach (DbConnStringMap map in list)
            {
                Asus.Data.Configuration.DataFarm.AddConnection(map.ConnectionName, map.ConnectionString, map.DataBaseType);
            }

        }

        protected enum EnumStatus
        {
            success=1,
            fail=0,
            manysuccess=2,
            none=3
        }

        public abstract int DoJob(string batchName);

        
         public  void WriteLog(string logMessage)
        {
            
            log.Info(logMessage);

        }

    }
}
