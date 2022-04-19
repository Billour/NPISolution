using System;
using System.Collections.Generic;
using System.Text;

namespace AsusLibrary.Entity
{
    public class DownLoadMainEntity:BaseEntity
    {
        private string _MainId;
        private string _GroupId;
        private string _PMUser;
        private List<string> _BomList;

        public string MainId
        {
            set { _MainId = value; }
            get { return _MainId; }
        }

        public string GroupId
        {
            set { _GroupId = value; }
            get { return _GroupId; }
        }

        public string PMUser
        {
            set { _PMUser = value; }
            get { return _PMUser; }
        }

        public List<string> BomList
        {
            set { _BomList = value; }
            get { return _BomList; }
        }
    }
}
