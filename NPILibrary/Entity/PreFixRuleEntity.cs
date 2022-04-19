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
    /// 加入前置字元
    /// </summary>
    public class PreFixRuleEntity:BaseEntity
    {
        
        private string _FixRule="70-M23";
        private string _IsEnable="Y";
        private string _CreateTime=DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");


        [QueryColumn("", "BOM前置字元", "Y", ViewRowType.LinkButton, "N", 10)]
        [Create("Y", "", "BOM前置字元", new EnumUIControl[] { EnumUIControl.TextBox }, 10)]
        [Visible(EnumUIControl.TextBox, PageMode.CreateMode + PageMode.ModifyMode)]
        public string FixRule
        {
            set { _FixRule = value; }
            get { return _FixRule; }
        }

        [QueryColumn("", "是否啟用", "Y", ViewRowType.BoundField, "N", 20)]
        [Create("Y", "", "是否啟用", new EnumUIControl[] { EnumUIControl.RadioButtonList }, 20)]
        [Visible(EnumUIControl.RadioButtonList, PageMode.CreateMode + PageMode.ModifyMode, "", true)]
        [SubListClass(typeof(UserLogic), "GetYesOrNoList", null, "Key", "Value")]
        [ControlProperty(EnumUIControl.RadioButtonList, "RepeatDirection", RepeatDirection.Horizontal)]
        public string IsEnable
        {
            set { _IsEnable = value; }
            get { return _IsEnable; }
        }

        [QueryColumn("", "建立時間", "Y", ViewRowType.BoundField, "N", 30)]
        [Create("Y", "", "建立時間", new EnumUIControl[] { EnumUIControl.Label }, 30)]
        [Visible(EnumUIControl.Label, PageMode.ModifyMode)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

    }
}
