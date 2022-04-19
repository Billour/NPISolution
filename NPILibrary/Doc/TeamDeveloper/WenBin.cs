using System;
using System.Collections.Generic;
using System.Text;

using Asus.Analysis.Attribute;
using Asus.Analysis.Interface;

namespace AsusLibrary.Doc.TeamDeveloper
{
    /// <summary>
    /// Wen Bin Tsai
    /// </summary>
    [TeamMember()]
    public class WenBin:ITeamMember
    {
        #region ITeamMember Members

        public string Id
        {
            get
            {
                return "WenBin";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string Name
        {
            get
            {
                return "Wen-Bin Tsai(蔡文斌)";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string Description
        {
            get
            {
                return "外包人員";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string Email
        {
            get
            {
                return "Wen-Bin_Tsai@asus.com.tw";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string PhoneNo
        {
            get
            {
                return "";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
