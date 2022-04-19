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
    public class GroupBOMEntity:BaseBOM
    {
        private string _GroupId = "";

        /// <summary>
        /// BOM ����
        /// </summary>
        [DataColumn("GROUP_ID")]
        [QueryColumn3("", "�s��(�����O)", "Y", ViewRowType.BoundField, "N", 11)]
        public string GroupId
        {
            set { _GroupId = value; }
            get { return _GroupId; }
        }
    }
}
