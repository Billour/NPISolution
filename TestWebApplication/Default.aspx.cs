using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using AsusLibrary.Utility;
using System.IO;
using Asus.Helper;
using System.Net.Mail;
using System.Reflection;
using Asus.Bussiness.Attribute;
using Asus.Data;


namespace TestWebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

       

        /// <summary>
        /// 標準做法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            // 設定 TextBox1 的文字

            TextBox1.Text = "這是標準的做法";

            Label1.Text = TextBox1.Text;

            Flower f = new Flower();

            Label2.Text = f.QueryNumbers("你好嗎?");

        }

        /// <summary>
        /// 設定資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            object objvalue = "這是Reflection的做法";

            // 設定 TextBox 的資料
            TextBox1.GetType().GetProperty("Text").SetValue(TextBox1, objvalue, null);

            //  先取得 TextBox 的Text 文字
            object strValue = TextBox1.GetType().GetProperty("Text").GetValue(TextBox1, null);

            // Set 資料使用
            Label1.GetType().GetProperty("Text").SetValue(Label1, strValue, null);


            // 
            //如果Global Property 的值來自一個Method
            Object flower = Activator.CreateInstance<Flower>();
            
            MethodInfo method =flower.GetType().GetMethod("QueryNumbers");

            if (method != null)
            {
                
                object[] o = new object[] { "歡迎光臨-Reflection" };

                object val = method.Invoke(flower, o);

                Label2.GetType().GetProperty("Text").SetValue(Label2, val, null);
            }
            else
            {
                throw new Exception("無法取得");
            }
            
        }

        /// <summary>
        ///  取得 Flower Name 的資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            Flower f = new Flower();

            PropertyInfo pi= f.GetType().GetProperty("Name");

            object[] attrs = pi.GetCustomAttributes(typeof(DataColumnAttribute), false);

            string s = ((DataColumnAttribute)attrs[0]).ColumnName;

            Label3.Text = s;
        }

        public int QueryFlowerCount<T>(T obj)
        {
            PropertyInfo pi=obj.GetType().GetProperty("Count");
            
            object val=pi.GetValue(obj, null);

            return Convert.ToInt16(Convert.ChangeType(val, pi.PropertyType));
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Flower f1 = new Flower();
            f1.Count = 100;

            Flower2 f2 = new Flower2();
            f2.Count = 200;

            int count1 = QueryFlowerCount<Flower>(f1);

            int count2 = QueryFlowerCount<Flower2>(f2);

            Label4.Text = count1.ToString()+":"+count2.ToString();
        }

        
    }

    public class Flower
    {
        private string _ID;
        private string _Name;
        private int _Count;

        [DataColumn("Flower_ID")]
        public string ID
        {
            set { _ID = value; }
            get { return _ID; }
        }

        [DataColumn("Flower_Name")]
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        public int Count
        {
            set { _Count = value; }
            get { return _Count; }
        }

        public string QueryNumbers(string input)
        {

            return input;
        }
    }

    public class Flower2
    {
        private string _ID;
        private string _Name;
        private int _Count;

        [DataColumn("Flower_ID")]
        public string ID
        {
            set { _ID = value; }
            get { return _ID; }
        }

        [DataColumn("Flower_Name")]
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        public int Count
        {
            set { _Count = value; }
            get { return _Count; }
        }

        public string QueryNumbers(string input)
        {

            return input;
        }
    }
}
