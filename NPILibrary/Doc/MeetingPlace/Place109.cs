using System;
using System.Collections.Generic;
using System.Text;

using Asus.Analysis.Attribute;
using Asus.Analysis.Interface;

namespace AsusLibrary.Doc.MeetingPlace
{
    /// <summary>
    /// 109 �|ĳ��
    /// </summary>
    [Place()]
    public class Place109:IPlace
    {

        #region IPlace Members

        /// <summary>
        /// �|ĳ�ǥN��
        /// </summary>
        public string ID
        {
            get
            {
                return "109";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// �|ĳ�ǦW��
        /// </summary>
        public string Name
        {
            get
            {
                return "�|ĳ��";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
