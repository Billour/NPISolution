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

using System.Runtime.InteropServices;

namespace AsusDoc
{
    public partial class Default : System.Web.UI.Page
    {
        public static Object missing = System.Reflection.Missing.Value;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Request["tag"] != null)
                {
                    string tag = Request["tag"].ToString();

                    lb.Text = tag;
                }

            }
        }

        /// <summary>
        /// ²£¥ÍMulti Sheet Excel
        /// </summary>
        /// 
        private void GenerateMultiExcel()
        { 
            

            Excel.Application xlExcel=new Excel.Application(); 

            Excel.Workbooks xlBooks;  

            Excel.Workbook xlBook; 

            Excel.Sheets xlSheets; 

            Excel.Worksheet stdSheet; 

            //Excel.Range xlCells; 

            string sFile;

            string sTemplate;

            Excel.Worksheet rescSheet;
 
            sFile = Server.MapPath(Request.ApplicationPath) + "Excel.xls";

            // Formatted template the way you want. 

            // If you want to change the format, change this template

            sTemplate = Server.MapPath(Request.ApplicationPath) + "XLTemplate.xls";

            xlExcel.Visible = false;
            xlExcel.DisplayAlerts = false;

            //' Get all workbooks and open first workbook

            xlBooks = xlExcel.Workbooks;

            xlBooks.Open(Server.MapPath(Request.ApplicationPath) + "\\XLTemplate.xls",missing,missing,missing,missing,missing,missing,missing,missing,missing,missing,missing,missing,missing,missing);

            xlBook = xlBooks.get_Item(1);

            //' Get all sheets available in first book 

            xlSheets = xlBook.Worksheets;

            //' Get first sheet, change its name and get all cells

            stdSheet =(Excel.Worksheet)xlSheets.get_Item(1);

            stdSheet.Name = "First Sheet";

            //' Get second sheet, change its name and get all cells

            rescSheet = (Excel.Worksheet)xlSheets.get_Item(2);

            rescSheet.Name = "Second Sheet ";
     
            //' Save created sheets as a file 

            xlBook.SaveAs(sFile,missing,missing,missing,missing,missing, Excel.XlSaveAsAccessMode.xlNoChange,missing,missing,missing,missing,missing);

            //' Make sure all objects are disposed

            xlBook.Close(missing, sFile, missing);

            xlExcel.Quit();
            
            //Marshal.ReleaseComObject(xlCells);

            Marshal.ReleaseComObject(stdSheet);

            Marshal.ReleaseComObject(xlSheets);

            Marshal.ReleaseComObject(xlBook);

            Marshal.ReleaseComObject(xlBooks);

            Marshal.ReleaseComObject(xlExcel);

            xlExcel = null;

            xlBooks = null;

            xlBook = null;

            xlSheets = null;

            stdSheet = null;

            //xlCells = null;

            rescSheet = null;

            //' Let GC know about it 

            GC.Collect();

     

            //' Export Excel for download

            Response.Redirect(sFile);




        }
    }
}
