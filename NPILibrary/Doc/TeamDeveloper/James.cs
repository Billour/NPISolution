using System;
using System.Collections.Generic;
using System.Text;

using Asus.Analysis.Attribute;
using Asus.Analysis.Interface;

namespace AsusLibrary.Doc.TeamDeveloper
{
    [TeamMember()]
    public class James:ITeamMember
    {

        #region ITeamMember Members

        public string Id
        {
            get
            {
                return "James";
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
                return "James1 Cheng(鄭耀國)";
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
                return "James1_Cheng@asus.com.tw";
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
                return "881-1954";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        public string Description
        {
            get
            {
                return @"管理師 華碩電腦股份有限公司 資材中心-策略採購部-專案課 Pro & MM Center-Strategic Pro Dept.-Projects Office";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        
    }
}
