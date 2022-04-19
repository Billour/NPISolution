using System;
using System.Collections.Generic;
using System.Text;

using AsusLibrary.Entity;

namespace AsusLibrary.WebPage
{
    public class BaseMaster : System.Web.UI.MasterPage
    {
        /// <summary>
        /// �n�J�t�ΤH�����
        /// �u����o�A����]�w
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
        /// ���o�Ҧ���Menu�C��
        /// </summary>
        protected List<MenuEntity> GetMenuList()
        {
            List<MenuEntity> list = new List<MenuEntity>();

            list.Add(new MenuEntity(1, "Home", "~/Index.aspx"));
            list.Add(new MenuEntity(5, "���@", "~/Maintain.aspx"));
            list.Add(new MenuEntity(10, "PM�H���v���޲z", "~/Config.aspx"));
            list.Add(new MenuEntity(20, "���ʤH���]�w", "~/SourcerGroup.aspx"));
            list.Add(new MenuEntity(30, "BOM��ƺ��@", "~/BomBooking.aspx"));
            list.Add(new MenuEntity(40, "�^�гB�z", "~/BomResponse.aspx"));
            // �d�߳�������-���ϥ�
            //list.Add(new MenuEntity(45, "�d�߳���", "~/QueryPN.aspx"));
            list.Add(new MenuEntity(50, "PM �U��Excel", "~/BomProc.aspx"));
            list.Add(new MenuEntity(60, "�޲z�̵���", "~/NPIClosePage.aspx"));

            //list.Add(new MenuEntity(9999, "����", "~/OnLineHelp.aspx"));

            return list;
        }

        /// <summary>
        /// ���oMenu����ƻP�v�������Y
        /// �Ҧ����W��
        /// </summary>
        /// <returns></returns>
        protected List<KeyValuePair<int,EnumRole>> GetRoleMenuList()
        {
            List<KeyValuePair<int,EnumRole>> list = new List<KeyValuePair<int,EnumRole>>();

            //�t�έ���
            list.Add(new KeyValuePair<int, EnumRole>(1, EnumRole.Admin));
            list.Add(new KeyValuePair<int, EnumRole>(1, EnumRole.Management));
            list.Add(new KeyValuePair<int, EnumRole>(1, EnumRole.PM));
            list.Add(new KeyValuePair<int, EnumRole>(1, EnumRole.Sourcer));
            
            //���@
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
