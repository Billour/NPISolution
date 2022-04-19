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
    /// PN 料號價格Entity
    /// </summary>
    public class PNPriceEntity:PNPriceBaseEntity
    {
        [Tables("NPI_PNPRICE", PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        [Tables("NPI_PNPRICE", PageCommandType.UpdateColumnMode, DBCommandType.UpdateMode, " where pn='{0}' and yearq='{1}' and location_site='{2}'", new string[] { "PN", "YearQ", "Site" })]
        public PNPriceEntity()
        { }

    }
}
