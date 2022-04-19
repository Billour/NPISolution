using System;
using System.Collections.Generic;
using System.Text;

using AsusLibrary.Entity;

namespace AsusLibrary.WebPage
{
    public class BaseMaster : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 登入系統人員資料
        /// 只能取得，不能設定
        /// </summary>
        protected LoginUserEntity LoginUserInfo
        {

            get
            {
                if (Session["LoginUserInfo"] != null)
                {
                    return (LoginUserEntity)Session["LoginUserInfo"];
                }

                return null;
            }
        }

        /// <summary>
        /// 取得所有的Menu列表
        /// </summary>
        protected List<MenuEntity> GetMenuList()
        {
            List<MenuEntity> list = new List<MenuEntity>();

            list.Add(new MenuEntity(1, "Home", "~/Index.aspx"));
            list.Add(new MenuEntity(5, "維護", "~/Maintain.aspx"));
            list.Add(new MenuEntity(10, "PM人員權限管理", "~/Config.aspx"));
            list.Add(new MenuEntity(20, "採購人員設定", "~/SourcerGroup.aspx"));
            list.Add(new MenuEntity(30, "BOM資料維護", "~/BomBooking.aspx"));
            list.Add(new MenuEntity(40, "回覆處理", "~/BomResponse.aspx"));
            // 查詢報價取消-不使用
            //list.Add(new MenuEntity(45, "查詢報價", "~/QueryPN.aspx"));
            list.Add(new MenuEntity(50, "PM 下載Excel", "~/BomProc.aspx"));
            list.Add(new MenuEntity(60, "管理者結案", "~/NPIClosePage.aspx"));

            //list.Add(new MenuEntity(9999, "說明", "~/OnLineHelp.aspx"));

            return list;
        }

        /// <summary>
        /// 取得Menu的資料與權限的關係
        /// 所有的名單
        /// </summary>
        /// <returns></returns>
        protected List<KeyValuePair<int,EnumRole>> GetRoleMenuList()
        {
            List<KeyValuePair<int,EnumRole>> list = new List<KeyValuePair<int,EnumRole>>();

            //系統首頁
            list.Add(new KeyValuePair<int, EnumRole>(1, EnumRole.Admin));
            list.Add(new KeyValuePair<int, EnumRole>(1, EnumRole.Management));
            list.Add(new KeyValuePair<int, EnumRole>(1, EnumRole.PM));
            list.Add(new KeyValuePair<int, EnumRole>(1, EnumRole.Sourcer));
            
            //維護
            list.Add(new KeyValuePair<int, EnumRole>(5, EnumRole.Admin));
            list.Add(new KeyValuePair<int, EnumRole>(5, EnumRole.Management));

            //
            list.Add(new KeyValuePair<int, EnumRole>(10, EnumRole.Admin));
            list.Add(new KeyValuePair<int, EnumRole>(10, EnumRole.Management));
            list.Add(new KeyValuePair<int, EnumRole>(20, EnumRole.Admin));
            list.Add(new KeyValuePair<int, EnumRole>(20, EnumRole.Management));
            list.Add(new KeyValuePair<int, EnumRole>(30, EnumRole.Admin));
            list.Add(new KeyValuePair<int, EnumRole>(30, EnumRole.PM));
            
            list.Add(new KeyValuePair<int, EnumRole>(40, EnumRole.Admin));
            list.Add(new KeyValuePair<int, EnumRole>(40, EnumRole.Sourcer));

            //list.Add(new KeyValuePair<int, EnumRole>(45, EnumRole.Admin));
            //list.Add(new KeyValuePair<int, EnumRole>(45, EnumRole.Sourcer));

            list.Add(new KeyValuePair<int, EnumRole>(50, EnumRole.Admin));
            list.Add(new KeyValuePair<int, EnumRole>(50, EnumRole.PM));
            list.Add(new KeyValuePair<int, EnumRole>(60, EnumRole.Management));
            list.Add(new KeyValuePair<int, EnumRole>(60, EnumRole.Admin));

            list.Add(new KeyValuePair<int, EnumRole>(9999, EnumRole.Admin));
            list.Add(new KeyValuePair<int, EnumRole>(9999, EnumRole.Management));
            list.Add(new KeyValuePair<int, EnumRole>(9999, EnumRole.PM));
            list.Add(new KeyValuePair<int, EnumRole>(9999, EnumRole.Sourcer));

            return list;
        }

        protected List<KeyValuePair<int, EnumRole>> GetRoleMenuById(int id)
        {
            List<KeyValuePair<int, EnumRole>> newList = new List<KeyValuePair<int, EnumRole>>();

            List<KeyValuePair<int, EnumRole>> oldList = GetRoleMenuList();

            foreach (KeyValuePair<int, EnumRole> t in oldList)
            {
                if (id == t.Key)
                {
                    newList.Add(t);
                }
            }

            return newList;
        }
    }
}
