using System;
using System.Collections.Generic;
using System.Text;
using Asus.Analysis.Interface;

namespace AsusLibrary.Doc.VersionHistory
{
    /// <summary>
    /// Version 1.0 ��
    /// </summary>
    public class Version1:IVersionHistory
    {
        private string _Version = "V1.0";
        private string _VersionDate = "2008/08/29";

        #region IVersionHistory Members

        /// <summary>
        /// �����N��
        /// </summary>
        public string Version
        {
            set{_Version=value;}
            get{return _Version;}
        }

        /// <summary>
        /// �������
        /// </summary>
        public string VersionDate
        {
            set { _VersionDate = value; }
            get { return _VersionDate; }
        }

        #endregion
    }
}
