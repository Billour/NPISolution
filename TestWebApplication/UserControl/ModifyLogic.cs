using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace TestWebApplication.UserControl
{
    public class ModifyLogic
    {

        public List<KeyValuePair<string, string>> GetYesAndNoList()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string, string>("Y", "Yes"));

            list.Add(new KeyValuePair<string, string>("N", "No"));

            return list;
        }
    }
}
