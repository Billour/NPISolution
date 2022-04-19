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
    public class FormPMEntity
    {

        private string _FormId;
        private string _PMUserId;

        [DataColumn("form_id")]
        public string FormId
        {
            set { _FormId = value; }
            get { return _FormId; }
        }

        [DataColumn("pm_user_id")]
        public string PMUserId
        {
            set { _PMUserId = value; }
            get { return _PMUserId; }
        }
    }
}
