using System;
using System.Collections.Generic;
using System.Text;

using Asus;
using Asus.Bussiness.Attribute;
using Asus.Bussiness.Map;
using System.Web.UI.WebControls;
using AsusLibrary.Logic;
using AsusLibrary.Entity;

namespace AsusLibrary.Entity
{
    public class SourcerEntity:BaseUserEntity
    {

        [Tables("NPI_PRIVILEGE", PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        [Tables("NPI_PRIVILEGE", PageCommandType.UpdateColumnMode, DBCommandType.UpdateMode, " where user_id='{0}' and company_id='{1}' and role_id='{2}'", new string[] { "AccountNo", "CompanyId", "Role" })]
        public SourcerEntity()
        { }

        private string _Component;
        private List<ComponentRefEntity> _ComponentList;

      
        /// <summary>
        /// UI 畫面顯示
        /// </summary>
        [Create("Y", "", "元件料號：", new EnumUIControl[] { EnumUIControl.CheckBoxList }, 50)]
        [Visible(EnumUIControl.CheckBoxList, PageMode.CreateMode + PageMode.ModifyMode,"",true)]
        [SubListClass(typeof(ComponentLogic), "GetComponentGroupList", null, "ID", "Name")]
        [ControlProperty(EnumUIControl.CheckBoxList, "RepeatDirection", RepeatDirection.Horizontal)]
        [ControlProperty(EnumUIControl.CheckBoxList, "RepeatColumns", 4)]
        public string Component
        {
            set { _Component = value; }
            get { return _Component; }
        }

        /// <summary>
        /// 獨立資料面
        /// </summary>
        public  List<ComponentRefEntity> ComponentList
        {
            set { _ComponentList = value; }
            get { return _ComponentList; }
        }
    }
}
