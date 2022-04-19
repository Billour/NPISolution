using System;
using System.Collections.Generic;
using System.Text;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// »PPVT ªºBOM 
    /// </summary>
    public class PVTBOMEntity:BaseEntity
    {
        private string _BOMId;

        private string _Location;

        /// <summary>
        /// BOM Id
        /// </summary>
        public string BOMId
        {
            set { _BOMId = value; }
            get { return _BOMId; }
        }

        /// <summary>
        /// Location
        /// </summary>
        public string Location
        {
            set { _Location = value; }
            get { return _Location; }
        }
    }
}
