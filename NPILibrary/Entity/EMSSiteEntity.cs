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
    public class EMSSiteEntity
    {
        private string _EmsCode;
        private string _EmsName;
        private string _TipTopSite;

        [DataColumn("EMS_CODE")]
        public string EmsCode
        {
            set { _EmsCode = value; }
            get { return _EmsCode; }
        }

        [DataColumn("EMS_NAME")]
        public string EmsName
        {
            set { _EmsName = value; }
            get { return _EmsName; }
        }

        [DataColumn("TIPTOP_SITE")]
        public string TipTopSite
        {
            set { _TipTopSite = value; }
            get { return _TipTopSite; }
        }
    }
}
