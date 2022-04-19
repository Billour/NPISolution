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
        /// 顯示內容
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
                lbMessage.Text = "PN 空值，請填寫PN之後再按查詢";
            }
            else
            {
                string group = tbPN.Text.Substring(0, 2);

                isFlag = logic.IsValidSourcerPNGroup(LoginUserInfo.UserId, group);

                if (!isFlag)
                {
                    lbMessage.Text ="你尚無權限查詢此PN料號資料";
                }
            }

            return isFlag;
        }


        private void GenerateColumn()
        {
            this.GenerateDynamicGridViewColumn<PNPriceEntity>(GridView1);
        }

        /// <summary>
        /// 查詢資料
        /// </summary>
        private void QueryData()
        {
            SourcerLogic logic = new SourcerLogic();

            List<PNPriceEntity> list = logic.GetPNPriceList(tbPN.Text);

            if (list.Count == 0)
            {
                lbMessage.Text = "查無資料";
            }
            else
            {
                GridView1.DataSource = list;
                GridView1.DataBind();    
            }
     
            


        }

        /// <summary>
        /// 查詢料號
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            lbMessage.Text = ""; //初始值

            //如果是成功的話 就直接尋找資料
            if (ValidPNIsValid())
            {
                GenerateColumn();

                QueryData();    
            }
            
        }
    }
}