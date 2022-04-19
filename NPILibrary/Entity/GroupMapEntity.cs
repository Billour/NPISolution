using System;
using System.Collections.Generic;
using System.Text;

using Asus;
using Asus.Bussiness.Attribute;
using Asus.Bussiness.Map;
using System.Web.UI.WebControls;
using AsusLibrary.Logic;

namespace AsusLibrary.Entity
{
    public class GroupMapEntity
    {
        private string _GroupId;
        private string _GroupName;
        private string _MemberUserNames;

        [DataColumn("Group_Id")]
        public string GroupId
        {
            set { _GroupId = value; }
            get { return _GroupId; }
        }

        [DataColumn("System_Name")]
        [QueryColumn("", "¸s²Õ", "Y", ViewRowType.BoundField, "N", 10)]
        public string GroupName
        {
            set { _GroupName = value; }
            get { return _GroupName; }
        }

        [QueryColumn("", "¤H­û", "Y", ViewRowType.BoundField, "N", 20)]
        public string MemberUserNames
        {
            set { _MemberUserNames = value; }
            get { return _MemberUserNames; }
        }
    }
}
