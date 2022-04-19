using System;
using System.Collections.Generic;
using System.Text;

using Asus.Logic;

namespace AsusLibrary.Logic
{
    /// <summary>
    /// Logic ���̩��h
    /// </summary>
    public class BaseLogic:DomainLogic
    {

        public BaseLogic()
            : base()
        { }

        //protected string m_ComapnyId = "";
        protected string m_Enable = "Y";

        /// <summary>
        /// ���oYes Or No List
        /// </summary>
        /// <returns>�O�P�_���x�}</returns>
        public List<KeyValuePair<string, string>> GetYesOrNoList()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string, string>("Y", "�O"));

            list.Add(new KeyValuePair<string, string>("N", "�_"));

            return list;
        }
    }
}
