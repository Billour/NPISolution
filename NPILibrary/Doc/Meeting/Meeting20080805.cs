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
    /// �|ĳ�O�� 2008/08/05
    /// 
    /// </summary>
    [MeetingAttribute()]
    public class Meeting20080805:IMeeting
    {


        #region IMeeting Members

        /// <summary>
        /// �|ĳ�D�D
        /// </summary>
        public string Title
        {
            get
            {
                return "NPI �W��T�{�|ĳ";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// �|ĳ����
        /// </summary>
        public string Description
        {
            get
            {
                return "�w�蠟�eNPI �Ҵ��ݨD�ηs�W�ݨD���� �A�i��}�o�e�T�{";
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// �|ĳ�ɶ� 2008/08/05 15:00
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
        /// �|ĳ�����ɶ�
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
        /// �|ĳ�a�I �s��109
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
        /// �D�n�}�o�H���A�ثe���C�T�H�A���ᳰ��s�W
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
        /// �|ĳ�Ҵ����ݨD�A�����n�N�����e�ഫ���t�λݨD
        /// ����������²�������e
        /// </summary>
        public List<KeyValuePair<string, string>> RequireMents
        {
            get
            {
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

                list.Add(new KeyValuePair<string,string>("20080805_01","�W�[�v���]�w�����A�ΨӽT�{RDPM���n�J��h"));
                list.Add(new KeyValuePair<string, string>("20080805_02", "�W�[BookingBond��ƮɡA�[�J[�ƶq][�Ͳ��a][Bond�Ƹ�][�t�dRD]"));
                list.Add(new KeyValuePair<string, string>("20080805_03", "RDPM�i�]�wBone Deadline�ɶ��A���ݱ��ʦ^�Ъ��p�A�ɶ��@��Y�iDownload��Excel"));
                list.Add(new KeyValuePair<string, string>("20080805_04", "���ʦ^�Цۤw�ҭt�d���ƶ��A��e����H�T�����覡��ܩ�Web�W�A�w�]�^�Ф��e���ťաA��K�^��"));

                return new List<KeyValuePair<string, string>>();
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// �w�p�n���ƶ�
        /// </summary>
        public List<KeyValuePair<string, string>> ToDoList
        {
            get
            {
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

                list.Add(new KeyValuePair<string, string>("1", "[���y]�N�[�c�Υ\��]�p�X�ӭ����Q��"));

                return list;


            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// �U���|ĳ�ɶ�
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
