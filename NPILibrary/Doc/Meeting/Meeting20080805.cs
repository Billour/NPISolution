using System;
using System.Collections.Generic;
using System.Text;

using Asus.Analysis.Attribute;
using Asus.Analysis.Interface;
using AsusLibrary.Doc.MeetingPlace;
using AsusLibrary.Doc.TeamDeveloper;


namespace AsusLibrary.Doc.Meeting
{
    /// <summary>
    /// 會議記錄 2008/08/05
    /// 
    /// </summary>
    [MeetingAttribute()]
    public class Meeting20080805:IMeeting
    {


        #region IMeeting Members

        /// <summary>
        /// 會議主題
        /// </summary>
        public string Title
        {
            get
            {
                return "NPI 規格確認會議";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// 會議說明
        /// </summary>
        public string Description
        {
            get
            {
                return "針對之前NPI 所提需求及新增需求部份 再進行開發前確認";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// 會議時間 2008/08/05 15:00
        /// </summary>
        public DateTime MeetingStartDate
        {
            get
            {
                return new DateTime(2008,8,5,15,0,0) ;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// 會議結束時間
        /// </summary>
        public DateTime MeetingEndDate
        {
            get
            {
                return new DateTime(2008, 8, 5, 16, 30, 0);
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// 會議地點 編號109
        /// </summary>
        public IPlace Place
        {
            get
            {
                return new Place109();
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// 主要開發人員，目前先列三人，之後陸續新增
        /// </summary>
        public List<ITeamMember> Participants
        {
            get
            {
                List<ITeamMember> list = new List<ITeamMember>();

                list.Add(new James());
                list.Add(new Macross());
                list.Add(new WenBin());

                return list;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public List<IContext> ProjectContext
        {
            get
            {
                return new List<IContext>();
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// 會議所提之需求，必須要將此內容轉換成系統需求
        /// 此部份為最簡略的內容
        /// </summary>
        public List<KeyValuePair<string, string>> RequireMents
        {
            get
            {
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

                list.Add(new KeyValuePair<string,string>("20080805_01","增加權限設定頁面，用來確認RDPM的登入原則"));
                list.Add(new KeyValuePair<string, string>("20080805_02", "增加BookingBond資料時，加入[數量][生產地][Bond料號][負責RD]"));
                list.Add(new KeyValuePair<string, string>("20080805_03", "RDPM可設定Bone Deadline時間，等待採購回覆狀況，時間一到即可Download成Excel"));
                list.Add(new KeyValuePair<string, string>("20080805_04", "採購回覆自已所負責之事項，其畫面能以三維之方式顯示於Web上，預設回覆內容為空白，方便回覆"));

                return new List<KeyValuePair<string, string>>();
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// 預計要做事項
        /// </summary>
        public List<KeyValuePair<string, string>> ToDoList
        {
            get
            {
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

                list.Add(new KeyValuePair<string, string>("1", "[文斌]將架構及功能設計出來頁面討論"));

                return list;


            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// 下次會議時間
        /// </summary>
        public DateTime NextMeeting
        {
            get
            {
                return new DateTime();
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

      
    }
}
