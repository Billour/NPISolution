using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Asus;
using Asus.Bussiness.Attribute;
using Asus.Bussiness.Map;

namespace TestWebApplication.UserControl
{
    public class ModifyRequestEntity
    {
        private string _ClasType;

        private string _Title;

        private string _Content;

        private string _Suggest;

        [Create("Y", "", "類別：", new EnumUIControl[] { EnumUIControl.DropDownList}, 10)]
        [Visible(EnumUIControl.DropDownList, PageMode.CreateMode,"",true)]
        [SubListClass(typeof(ModifyLogic), "GetYesAndNoList", null, "Key", "Value")]
        public string ClasType
        {
            set { _ClasType = value; }
            get { return _ClasType; }
        }

        [Create("Y", "", "標題：", new EnumUIControl[] { EnumUIControl.Calendar }, 20)]
        [Visible(EnumUIControl.Calendar, PageMode.CreateMode)]
        [ControlProperty(EnumUIControl.Calendar, "ImageButtonSkinID", "ImageCalndarSkin")]
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        [Create("Y", "", "內容：", new EnumUIControl[] { EnumUIControl.TextBox }, 30)]
        [Visible(EnumUIControl.TextBox, PageMode.CreateMode)]
        public string Content
        {
            set { _Content = value; }
            get { return _Content; }
        }

        [Create("Y", "", "建議：", new EnumUIControl[] { EnumUIControl.TextBox }, 40)]
        [Visible(EnumUIControl.TextBox, PageMode.CreateMode)]
        [ControlProperty(EnumUIControl.TextBox, "TextMode", TextBoxMode.MultiLine)]
        [ControlProperty(EnumUIControl.TextBox, "Columns", 30)]
        [ControlProperty(EnumUIControl.TextBox, "Rows", 30)]
        public string Suggest
        {
            set { _Suggest = value; }
            get { return _Suggest; }
        }


    }
}
