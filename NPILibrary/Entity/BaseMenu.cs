using System;
using System.Collections.Generic;
using System.Text;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// Menu ���h
    /// </summary>
    public class BaseMenu:BaseEntity
    {
        private int _MenuID;
        private string _MenuName;
        private string _NaviUrl;

        /// <summary>
        /// Menu ID �H�Ʀr��ܡA�ѼƦr�p�}�l�Ƨ�
        /// </summary>
        public int MenuID
        {
            set { _MenuID = value; }
            get { return _MenuID; }
        }

        /// <summary>
        /// Menu �W��
        /// </summary>
        public string MenuName
        {
            set { _MenuName = value; }
            get { return _MenuName; }
        }

        /// <summary>
        ///  URL Link
        /// </summary>
        public string NaviUrl
        {
            set { _NaviUrl = value; }
            get { return _NaviUrl; }
        }
    }
}
