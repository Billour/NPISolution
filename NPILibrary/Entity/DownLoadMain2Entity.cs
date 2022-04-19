using System;
using System.Collections.Generic;
using System.Text;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// DownLoad Panel Entity
    /// </summary>
    public class DownLoadMain2Entity:BaseEntity
    {
        private string _MainId;
        private List<string> _GroupList;
        private List<string> _BomList;

        public string MainId
        {
            set { _MainId = value; }
            get { return _MainId; }
        }

        public List<string> GroupList
        {
            set { _GroupList = value; }
            get { return _GroupList; }
        }

        
        public List<string> BomList
        {
            set { _BomList = value; }
            get { return _BomList; }
        }
    }
}
