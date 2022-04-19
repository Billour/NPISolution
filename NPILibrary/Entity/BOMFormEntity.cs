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
    public class BOMFormEntity:BaseEntity
    {
        private string _PMName = "PM-A姓名";
        private string _DeadLine = "2008/8/20";
        private string _FormStatus = "回覆完畢";

        /// <summary>
        /// 
        /// </summary>
        [QueryColumn("", "PM", "Y", ViewRowType.LinkButton, "N", 10)]
        public string PMName
        {
            set { _PMName = value; }
            get { return _PMName; }
        }


        [QueryColumn("", "開始回覆時間", "Y", ViewRowType.BoundField, "N", 20)]
        public string DeadLine
        {
            set { _DeadLine = value; }
            get { return _DeadLine; }
        }

        [QueryColumn("", "狀態", "Y", ViewRowType.BoundField, "N", 30)]
        public string FormStatus
        {
            set { _FormStatus = value; }
            get { return _FormStatus; }
        }
    }
}
