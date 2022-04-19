using System;
using System.Collections.Generic;
using System.Text;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// Menu 底層
    /// </summary>
    public class BaseMenu:BaseEntity
    {
        private int _MenuID;
        private string _MenuName;
        private string _NaviUrl;

        /// <summary>
        /// Menu ID 以數字表示，由數字小開始排序
        /// </summary>
        public int MenuID
        {
            set { _MenuID = value; }
            get { return _MenuID; }
        }

        /// <summary>
        /// Menu 名稱
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
