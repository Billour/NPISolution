using System;
using System.Collections.Generic;
using System.Text;

using Asus.Logic;

namespace AsusLibrary.Logic
{
    /// <summary>
    /// Logic 的最底層
    /// </summary>
    public class BaseLogic:DomainLogic
    {

        public BaseLogic()
            : base()
        { }

        //protected string m_ComapnyId = "";
        protected string m_Enable = "Y";

        /// <summary>
        /// 取得Yes Or No List
        /// </summary>
        /// <returns>是與否的矩陣</returns>
        public List<KeyValuePair<string, string>> GetYesOrNoList()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string, string>("Y", "是"));

            list.Add(new KeyValuePair<string, string>("N", "否"));

            return list;
        }
    }
}
