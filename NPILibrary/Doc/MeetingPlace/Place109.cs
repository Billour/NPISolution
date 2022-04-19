using System;
using System.Collections.Generic;
using System.Text;

using Asus.Analysis.Attribute;
using Asus.Analysis.Interface;

namespace AsusLibrary.Doc.MeetingPlace
{
    /// <summary>
    /// 109 會議室
    /// </summary>
    [Place()]
    public class Place109:IPlace
    {

        #region IPlace Members

        /// <summary>
        /// 會議室代號
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
        /// 會議室名稱
        /// </summary>
        public string Name
        {
            get
            {
                return "會議室";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
