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
                return "James1 Cheng(�Gģ��)";
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
                return @"�޲z�v �غӹq���ѥ��������q �������-�������ʳ�-�M�׽� Pro & MM Center-Strategic Pro Dept.-Projects Office";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        
    }
}
