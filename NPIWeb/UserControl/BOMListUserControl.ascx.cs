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
using Asus.Bussiness.Attribute;
using AsusWeb.Page;


namespace AsusWeb.UserControl
{
    public partial class BOMListUserControl : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// �����
        /// </summary>
        public string FormNo
        {
            set
            {
                ViewState["FormNo"] = value;
            }
            get
            {
                if (ViewState["FormNo"] == null)
                {
                    throw new Exception("�L�k���������");
                }
                return ViewState["FormNo"].ToString();
            }

        }

        /// <summary>
        /// ��ܤ��e
        /// </summary>
        public void Show()
        {
            this.GenerateGridViewColumn<QueryColumn2Attribute>(GridView1, typeof(BOMEntity));

            QueryData();


        }

        /// <summary>
        /// �d�߸��
        /// </summary>
        private void QueryData()
        {
            BOMLogic logic = new BOMLogic();

            List<BOMBookingEntity> list = logic.QueryFromBookingBOM(FormNo);

            GridView1.DataSource = list;
            GridView1.DataBind();

        }

       

        
    }
}