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
    public class ComponentGroupEntity:BaseEntity
    {
        private string _ID;
        private string _Name;

        /// <summary>
        /// 元件料件代號
        /// </summary>
        [DataColumn("GROUP_ID")]
        public string ID
        {
            set { _ID = value; }
            get { return _ID; }
        }

        /// <summary>
        /// 元件料號名稱
        /// </summary>
        [DataColumn("GROUP_NAME")]
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

    }
}
