using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;
using Excel;


namespace Asus.Office.ExcelCore
{

    public  class ExcelCore
    {
        public static Object missing = System.Reflection.Missing.Value;

        protected Application xlExcel;

        protected Workbooks xlBooks;

        protected Workbook xlBook;

        protected Sheets xlSheets;

        protected Worksheet stdSheet;

        protected string sFile;

        protected string sTemplate;

        protected Worksheet rescSheet;

        protected Range xlCells; 
        
        /// <summary>
        /// øÈ§JtemplateFile Path Ful Name Like c:\\temp\ee.xls 
        /// 
        /// </summary>
        /// <param name="tempalteFile">c:\\temp\ee.xls</param>
        /// <param name="saveFile">c:\\temp\ee.xls</param>
        public ExcelCore(string tempalteFile,string saveFile)
        {
            xlExcel = new Excel.Application();

            sFile = saveFile;
            
            sTemplate = tempalteFile;

            xlExcel.Visible = false;
            
            xlExcel.DisplayAlerts = false;

           
            
        }

        public ExcelCore(string openFile)
        {
            xlExcel = new Excel.Application();

            sFile = "";

            sTemplate = openFile;

            xlExcel.Visible = false;

            xlExcel.DisplayAlerts = false;



        }

       

        /// <summary>
        /// ∂}Excel¿…
        /// </summary>
        protected void Open()
        {
            xlBooks = xlExcel.Workbooks;

            xlBooks.Open(sTemplate, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);

            xlBook = xlBooks.get_Item(1);

            xlSheets = xlBook.Worksheets;
        }

       




        protected void Save()
        {
            xlBook.SaveAs(sFile, missing, missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlNoChange, missing, missing, missing, missing, missing);
        }

        protected void Close()
        {
            //' Make sure all objects are disposed

            if (sFile != "")
            {
                xlBook.Close(missing, sFile, missing); 
            }
            

            xlExcel.Quit();

            //Marshal.ReleaseComObject(xlCells);
            if (stdSheet != null)
            {
                Marshal.ReleaseComObject(stdSheet);
            }
            

            Marshal.ReleaseComObject(xlSheets);

            Marshal.ReleaseComObject(xlBook);

            Marshal.ReleaseComObject(xlBooks);

            Marshal.ReleaseComObject(xlExcel);

            if (rescSheet != null)
            {
                Marshal.ReleaseComObject(rescSheet);
            }
            

            xlExcel = null;

            xlBooks = null;

            xlBook = null;

            xlSheets = null;

            stdSheet = null;

            xlCells = null;

            rescSheet = null;

            //' Let GC know about it 

            GC.Collect();
        }

        
    }
}
