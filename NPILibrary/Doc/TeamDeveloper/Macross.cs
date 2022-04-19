using System;
using System.Collections.Generic;
using System.Text;

using Asus.Analysis.Attribute;
using Asus.Analysis.Interface;

namespace AsusLibrary.Doc.TeamDeveloper
{
    /// <summary>
    /// Macross 的資料
    /// </summary>
    [TeamMember()]
    public class Macross:ITeamMember
    {

        #region ITeamMember Members

        public string Id
        {
            get
            {
                return "Macross";
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
                return "Macross Tuan(段裕華)";
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
                return " 工程師 華碩電腦股份有限公司 電腦中心-eSCM課 MIS-eSCM Sec";
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
                return "Macross_Tuan@asus.com.tw";
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
                return "881-4653";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
