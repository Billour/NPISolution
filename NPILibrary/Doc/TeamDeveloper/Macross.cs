using System;
using System.Collections.Generic;
using System.Text;

using Asus.Analysis.Attribute;
using Asus.Analysis.Interface;

namespace AsusLibrary.Doc.TeamDeveloper
{
    /// <summary>
    /// Macross �����
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
                return "Macross Tuan(�q�ε�)";
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
                return " �u�{�v �غӹq���ѥ��������q �q������-eSCM�� MIS-eSCM Sec";
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
