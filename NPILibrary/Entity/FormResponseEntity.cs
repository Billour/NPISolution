using System;
using System.Collections.Generic;
using System.Text;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// Form Entity�D��
    /// </summary>
    public class FormResponseEntity:BaseEntity
    {
        private string _FormId;
        private List<FormPNEntity> _PNList;

        private List<BOMBookingEntity> _BOMList;
        private Dictionary<string, string> _BOMPNQtyList;

        /// <summary>
        /// ���N��
        /// </summary>
        public string FormId
        {
            set { _FormId = value; }
            get { return _FormId; }
        }

        /// <summary>
        /// �Ƹ��C��
        /// </summary>
        public List<FormPNEntity> PNList
        {
            set { _PNList = value; }
            get { return _PNList; }
        }

     

        /// <summary>
        /// BOM�C��
        /// </summary>
        public List<BOMBookingEntity> BOMList
        {
            set { _BOMList = value; }
            get { return _BOMList; }
        }

        /// <summary>
        /// BOM PN Qty �C�����Y
        /// </summary>
        public Dictionary<string, string> BOMPNQtyList
        {
            set { _BOMPNQtyList = value; }
            get { return _BOMPNQtyList; }
        }
    }
}
