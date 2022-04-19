using System;
using System.Collections.Generic;
using System.Text;

namespace AsusLibrary.Entity
{
    public class MenuEntity:BaseMenu
    {
        /// <summary>
        /// Menu Entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="url"></param>
        public MenuEntity(int id, string name, string url)
        { 
            this.MenuID=id;
            this.MenuName=name;
            this.NaviUrl=url;
        }


    }
}
