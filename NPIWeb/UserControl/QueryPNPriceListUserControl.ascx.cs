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

using AsusLibrary.WebPage.UserControl;
using AsusLibrary.Entity;
using System.Collections.Generic;
using AsusLibrary.Logic;

using AsusWeb.Page;

namespace AsusWeb.UserControl
{
    public partial class QueryPNPriceListUserControl : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// ��ܤ��e
        /// </summary>
        public void Show()
        {

        }

        
        private bool ValidPNIsValid()
        {
            bool isFlag = false;

            SourcerLogic logic = new SourcerLogic();

            if (tbPN.Text == "")
            {
                lbMessage.Text = "PN �ŭȡA�ж�gPN����A���d��";
            }
            else
            {
                string group = tbPN.Text.Substring(0, 2);

                isFlag = logic.IsValidSourcerPNGroup(LoginUserInfo.UserId, group);

                if (!isFlag)
                {
                    lbMessage.Text ="�A�|�L�v���d�ߦ�PN�Ƹ����";
                }
            }

            return isFlag;
        }


        private void GenerateColumn()
        {
            this.GenerateDynamicGridViewColumn<PNPriceEntity>(GridView1);
        }

        /// <summary>
        /// �d�߸��
        /// </summary>
        private void QueryData()
        {
            SourcerLogic logic = new SourcerLogic();

            List<PNPriceEntity> list = logic.GetPNPriceList(tbPN.Text);

            if (list.Count == 0)
            {
                lbMessage.Text = "�d�L���";
            }
            else
            {
                GridView1.DataSource = list;
                GridView1.DataBind();    
            }
     
            


        }

        /// <summary>
        /// �d�߮Ƹ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            lbMessage.Text = ""; //��l��

            //�p�G�O���\���� �N�����M����
            if (ValidPNIsValid())
            {
                GenerateColumn();

                QueryData();    
            }
            
        }
    }
}