using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using AsusLibrary.WebPage;
using  System.Collections.Generic;
using AsusLibrary.Entity;
using AsusLibrary;


namespace AsusWeb
{
    public partial class NPI : BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //InsertMenu


                SetMenuShow();

                lbLoginUser.Text = String.Format("{0}({1})", LoginUserInfo.UserEnglishName, LoginUserInfo.UserChineseName);

                this.lbLoginTime.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

                foreach (MenuItem t in Menu1.Items)
                { 
                    if(Page.AppRelativeVirtualPath==t.NavigateUrl)
                    {
                        t.Selected=true;
                        break;
                    }
                }
                
                
            }
        }

        private void SetMenuShow()
        { 
           //Get Login User Roles
            List<string> roles = LoginUserInfo.Roles;

            //Get All Menu List
            List<MenuEntity> menuList=GetMenuList();

            //Get SortedList Menu
            SortedList<int, MenuEntity> list=new SortedList<int,MenuEntity>();

            foreach(MenuEntity t in menuList)
            {
                int id=t.MenuID;

                bool isFlag=false;

                List<KeyValuePair<int, EnumRole>> tmpList=GetRoleMenuById(id);

                foreach (KeyValuePair<int, EnumRole> r  in tmpList)
                { 
                    foreach(string role in roles)
                    {
                        if (r.Value.ToString() == role)
                        {
                            isFlag = true;
                            break;
                        }
                    }

                    if (isFlag)
                    {
                        break;
                    }
                    
                }

                if (isFlag)
                {
                    if (!list.ContainsKey(t.MenuID))
                    {
                        list.Add(t.MenuID, t);
                    }
                }
            }


            foreach (MenuEntity en in list.Values)
            {
                MenuItem item = new MenuItem();
                item.Text = en.MenuName;
                item.NavigateUrl = en.NaviUrl;

                Menu1.Items.Add(item);
            }



        }

       
    }
}
