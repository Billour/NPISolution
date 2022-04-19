using System;
using System.Collections.Generic;
using System.Text;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// Form Entity主體
    /// </summary>
    public class FormResponseEntity:BaseEntity
    {
        private string _FormId;
        private List<FormPNEntity> _PNList;

        private List<BOMBookingEntity> _BOMList;
        private Dictionary<string, string> _BOMPNQtyList;

        /// <summary>
        /// 表單代號
        /// </summary>
        public string FormId
        {
            set { _FormId = value; }
            get { return _FormId; }
        }

        /// <summary>
        /// 料號列表
        /// </summary>
        public List<FormPNEntity> PNList
        {
            set { _PNList = value; }
            get { return _PNList; }
        }

     

        /// <summary>
        /// BOM列表
        /// </summary>
        public List<BOMBookingEntity> BOMList
        {
            set { _BOMList = value; }
            get { return _BOMList; }
        }

        /// <summary>
        /// BOM PN Qty 列表關係
        /// </summary>
        public Dictionary<string, string> BOMPNQtyList
        {
            set { _BOMPNQtyList = value; }
            get { return _BOMPNQtyList; }
        }
    }
}
