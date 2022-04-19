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
    /// 此BOM是針對ABOM ERP DL Table所設置
    /// </summary>
    public class AsusBomEntity
    {
        
        private string _WorkNo;
        private string _BomId;
        private string _PN;
        private string _PNName;
        private string _PNDesc;
        private string _Qty;

        private string _AssemblyNo;
        private string _IsSub;

        /// <summary>
        /// Work No
        /// </summary>
        [DataColumn("WORK_NO")]
        public string WorkNo
        {
            set { _WorkNo = value; }
            get { return _WorkNo; }
        }

        /// <summary>
        /// BomId
        /// </summary>
        [DataColumn("ASUS_BOM")]
        public string BomId
        {
            set { _BomId = value; }
            get { return _BomId; }
        }

        /// <summary>
        /// 元件料號
        /// </summary>
        [DataColumn("ASUS_PN")]
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// 品名
        /// </summary>
        [DataColumn("PART_DESC1")]
        public string PNName
        {
            set { _PNName = value; }
            get { return _PNName; }
        }

        /// <summary>
        /// 規格
        /// </summary>
        [DataColumn("PART_DESC2")]
        public string PNDesc
        {
            set { _PNDesc = value; }
            get { return _PNDesc; }
        }


        /// <summary>
        /// 組合用量
        /// </summary>
        [DataColumn("ASMBLY_QTY")]
        public string Qty
        {
            set { _Qty = value; }
            get { return _Qty; }
        }

        /// <summary>
        /// 組件號 
        /// </summary>
        [DataColumn("ASMBLY_NO")]
        public string AssemblyNo
        {
            set { _AssemblyNo = value; }
            get { return _AssemblyNo; }
        }

        [DataColumn("IS_SUB")]
        public string IsSub
        {
            set { _IsSub = value; }
            get { return _IsSub; }
        }

    }
}
