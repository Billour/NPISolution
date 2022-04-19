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
    /// <summary>
    /// �s��Price Entity �[�WUserId
    /// </summary>
    public class PNPrice2Entity:PNPriceBaseEntity
    {
        private string _SourcerId;

        /// <summary>
        /// Sourcer ID
        /// </summary>
        [DataColumn("User_ID")]
        public string SourcerId
        {
            set { _SourcerId = value; }
            get { return _SourcerId; }
        }

        

    }
}
