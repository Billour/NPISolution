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
    /// 展BOM 資料
    /// </summary>
    public class ResponseEntity:BaseCompnentEntity
    {

       

        //private string _BOM1 = "1";
        //private string _BOM2="2";
        //private string _BOM3 = "3";
        //private string _BOM4 = "4";
        //private string _BOM5 = "5";
        //private string _BOM6 = "6";
        //private string _BOM7 = "7";
        //private string _BOM8 = "8";
        //private string _BOM9 = "9";
        //private string _BOM10 = "10";

        //private string _BOM11 = "11";
        //private string _BOM12 = "12";
        //private string _BOM13 = "13";
        //private string _BOM14 = "14";
        //private string _BOM15 = "15";
        //private string _BOM16 = "16";
        //private string _BOM17 = "17";
        //private string _BOM18 = "18";
        //private string _BOM19 = "19";
        //private string _BOM20 = "20";
        
        
        private string _LongTermWeeks="";
        private string _ComponentProperty = "0";
        private string _Add2Source = "0";
        private string _Add2SourceComment = "Add Comment";
        private string _EOL = "";
     

      

        //[QueryColumn("", "70-MIB5G00-M3A78PRO-GA", "Y", ViewRowType.BoundField, "N", 40)]
        //public string BOM1
        //{
        //    set { _BOM1 = value; }
        //    get { return _BOM1; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 50)]
        //public string BOM2
        //{
        //    set { _BOM2 = value; }
        //    get { return _BOM2; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 60)]
        //public string BOM3
        //{
        //    set { _BOM3 = value; }
        //    get { return _BOM3; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 70)]
        //public string BOM4
        //{
        //    set { _BOM4 = value; }
        //    get { return _BOM4; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 80)]
        //public string BOM5
        //{
        //    set { _BOM5 = value; }
        //    get { return _BOM5; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 90)]
        //public string BOM6
        //{
        //    set { _BOM6 = value; }
        //    get { return _BOM6; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 100)]
        //public string BOM7
        //{
        //    set { _BOM7 = value; }
        //    get { return _BOM7; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 110)]
        //public string BOM8
        //{
        //    set { _BOM8 = value; }
        //    get { return _BOM8; }
        //}


        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 120)]
        //public string BOM9
        //{
        //    set { _BOM9 = value; }
        //    get { return _BOM9; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 130)]
        //public string BOM10
        //{
        //    set { _BOM10 = value; }
        //    get { return _BOM10; }
        //}

        //[QueryColumn("", "70-MIB5G00-M3A78PRO-GA", "Y", ViewRowType.BoundField, "N", 140)]
        //public string BOM11
        //{
        //    set { _BOM11 = value; }
        //    get { return _BOM11; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 150)]
        //public string BOM12
        //{
        //    set { _BOM12 = value; }
        //    get { return _BOM12; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 160)]
        //public string BOM13
        //{
        //    set { _BOM13 = value; }
        //    get { return _BOM13; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 170)]
        //public string BOM14
        //{
        //    set { _BOM14 = value; }
        //    get { return _BOM14; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 180)]
        //public string BOM15
        //{
        //    set { _BOM15 = value; }
        //    get { return _BOM15; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 190)]
        //public string BOM16
        //{
        //    set { _BOM16 = value; }
        //    get { return _BOM16; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 200)]
        //public string BOM17
        //{
        //    set { _BOM17 = value; }
        //    get { return _BOM17; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 210)]
        //public string BOM18
        //{
        //    set { _BOM18 = value; }
        //    get { return _BOM18; }
        //}


        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 220)]
        //public string BOM19
        //{
        //    set { _BOM19 = value; }
        //    get { return _BOM19; }
        //}

        //[QueryColumn("", "70-2M8051 6A054 M3A78-TRD BOM", "Y", ViewRowType.BoundField, "N", 230)]
        //public string BOM20
        //{
        //    set { _BOM20 = value; }
        //    get { return _BOM20; }
        //}
        
        ///// <summary>
        ///// 暫停使用
        ///// </summary>
        //[QueryColumn("", "CCL", "Y", ViewRowType.BoundField, "N", 240)]
        //public string CCL
        //{
        //    set { _CCL = value; }
        //    get { return _CCL; }
        //}

        ///// <summary>
        ///// 由sourcer 勾選 (PM 須回覆意見)
        ///// 這個有問題
        ///// </summary>
        //[QueryColumn("", "Risky Buy", "Y", ViewRowType.TextBox, "N", 250)]
        //public string RiskyBuy
        //{
        //    set { _RiskyBuy = value; }
        //    get { return _RiskyBuy; }
        //}



        /// <summary>
        /// 是否可連結Tip Top
        /// </summary>
        [QueryColumn("", "long L/T(weeks)", "Y", ViewRowType.BoundField, "N", 260)]
        public string LongTermWeeks
        {
            set { _LongTermWeeks = value; }
            get { return _LongTermWeeks; }
        }

        /// <summary>
        /// 料號屬性
        /// 1. 無意見
        /// 2.Custom parts
        /// 3. Unique parts
        /// 4. Single source
        /// </summary>
        [QueryColumn("", "料號屬性", "Y", ViewRowType.DropDownList, "N", 270)]
        [TemplateSubList(typeof(BOMLogic),"GetComponentPropertyList",null,"Key","Value")]
        public string ComponentProperty
        {
            set { _ComponentProperty = value; }
            get { return _ComponentProperty; }
        }

        [QueryColumn("", "加入第二來源", "Y", ViewRowType.DropDownList, "N", 280)]
        [TemplateSubList(typeof(BOMLogic), "GetAddSourceList", null, "Key", "Value")]
        public string Add2Source
        {
            set { _Add2Source = value; }
            get { return _Add2Source; }
        }

        [QueryColumn("", "加入第二來源備註", "Y", ViewRowType.TextBox, "N", 285)]
        public string Add2SourceComment
        {
            set { _Add2SourceComment = value; }
            get { return _Add2SourceComment; }
        }

        [QueryColumn("", "EOL備註", "Y", ViewRowType.TextBox, "N", 290)]
        public string EOL
        {
            set { _EOL = value; }
            get { return _EOL; }
        }


       

        
        



    }
}
