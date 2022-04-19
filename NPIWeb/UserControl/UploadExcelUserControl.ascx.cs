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
using AsusLibrary.Logic;
using System.IO;
using AsusWeb.Page;
using Asus.Bussiness.Attribute;
using System.Collections.Generic;
using AsusLibrary;

namespace AsusWeb.UserControl
{
    /// <summary>
    /// 上傳Excel
    /// </summary>
    public partial class UploadExcelUserControl :BaseControl
    {
        private int BomInt = 4;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show()
        {
            InitPage();
        }

        private void InitPage()
        { 
            
        }

         /// <summary>
        /// 表單代號
        /// </summary>
        public string FormId
        {
            set
            {
                ViewState["FormId"] = value;
                
               
            }
            get
            {
                if (ViewState["FormId"] == null)
                {
                    throw new Exception("無法取得FormId代號，請查明原因");
                }
                return ViewState["FormId"].ToString();
            }

        }

         /// <summary>
        /// 採購人員
        /// </summary>
        public string SourcerUserId
        {
            set
            {
                ViewState["SourcerUserId"] = value;
            }
            get
            {
                if (ViewState["SourcerUserId"] == null)
                {
                    throw new Exception("無法取得採購人員工號資料");
                }
                return ViewState["SourcerUserId"].ToString();
            }

        }

        public EnumUploadMode UpLoadMode
        {
            set
            {
                ViewState["UpLoadMode"] = value;
            }
            get
            {
                if (ViewState["UpLoadMode"] == null)
                {
                    ViewState["UpLoadMode"] = EnumUploadMode.PN;
                }
                return (EnumUploadMode)ViewState["UpLoadMode"];
            }

        }

        /// <summary>
        /// 上傳檔案
        /// </summary>
        private string UPloadFileName
        {
            set
            {
                ViewState["UPloadFileName"] = value;
            }
            get
            {
                if (ViewState["UPloadFileName"] == null)
                {
                    throw new Exception("無法取得上傳檔案");
                }
                return ViewState["UPloadFileName"].ToString();
            }

        }


        /// <summary>
        /// 上傳檔案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {

            DoUploadExcelFile();
            
        }

        /// <summary>
        /// Upload Excel File
        /// </summary>
        private void DoUploadExcelFile()
        {
            bool isFlag = UploadExcelFile();

            if (isFlag)
            {
                pnlSave.Visible = true;

                if (UpLoadMode == EnumUploadMode.PN)
                {
                    lbFormId.Text = FormId;
                }
                
                
                lbSourcerName.Text = String.Format("{0}({1})", LoginUserInfo.UserEnglishName, LoginUserInfo.UserChineseName);

                switch (UpLoadMode)
                { 
                    case EnumUploadMode.PN:
                        ShowUpExcelData();
                        break;
                    case EnumUploadMode.BOM:
                        ShowBOMxcelData();
                        break;
                    case EnumUploadMode.Main:
                        ShowUpExcelData();
                        break;
                }
                

            }
            else
            {
                pnlSave.Visible = false;
            }
        }

              

        private bool UploadExcelFile()
        {
            bool isFileUpload = false;

            if (fpExcelUppload.HasFile)
            {
                Boolean fileOK = false;

                String path = LoginInfo.ExcelFileUpload + DateTime.Now.ToString("yyyyMMdd") + "\\" + SourcerUserId+"\\";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                String fileExtension =
                System.IO.Path.GetExtension(fpExcelUppload.FileName).ToLower();
                String[] allowedExtensions ={ ".xls" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }

                //Upload File
                if (fileOK)
                {
                    try
                    {
                        fpExcelUppload.PostedFile.SaveAs(path + fpExcelUppload.FileName);
                        lbErrorMessage.Text = "檔案上傳成功";

                        isFileUpload = true;

                        //設定上傳檔案名稱
                        UPloadFileName = path + fpExcelUppload.FileName;

                    }
                    catch (Exception ex)
                    {
                        lbErrorMessage.Text = "檔案上傳失敗=" + ex.Message + ex.StackTrace;
                    }
                }
                else
                {

                    lbErrorMessage.Text = "上傳檔案必須是Excel格式";
                }
            }
            else
            {
                lbErrorMessage.Text = "無法取得上傳檔案，請重新確認";
            }

            return isFileUpload;
        }

        
        
        private void ShowUpExcelData()
        {
            ExcelLogic logic = new ExcelLogic(UPloadFileName);

            FormResponseEntity entity=logic.GetResponseData();

            //由於上傳的檔案的資料會被改變，所以要做一點轉換

            BOMLogic bomLogic = new BOMLogic();
            
            //Add Property Name
            List<KeyValuePair<string, string>> pList = bomLogic.GetComponentPropertyList();

            List<KeyValuePair<string, string>> aList = bomLogic.GetAddSourceList();
            
            //Add Source
            foreach (FormPNEntity t in entity.PNList)
            {
                t.PNPropertyName = FilterPNName(pList, t.PNProperty);

                t.AddSourceName = FilterPNName(aList, t.AddSource);
            }

            lbExcelFormId.Text = entity.FormId;

            GridView1.DataSource =entity.PNList;
            GridView1.DataBind();

            if (entity.PNList.Count > 0)
            {
                if (entity.FormId.Trim() != FormId.Trim())
                {
                    lbSaveErrMsg.Text = "上傳的Excel單號不對，請重新確認";

                    lnkSave.Visible = false;
                }
                else
                {
                    lnkSave.Visible = true;
                }
            }
            else
            {
                lbSaveErrMsg.Text = "無任何資料";
                lnkSave.Visible = false;

            }
         



        }

        /// <summary>
        /// PM 上傳 BOM Excel 檔案
        /// </summary>
        private void ShowBOMxcelData()
        {
            bool isFlag = false;

            lbErrMsg.Text = "";

            this.GenerateGridViewColumn<QueryColumn2Attribute>(GridView2, typeof(BOMBookingEntity));

            ExcelLogic logic = new ExcelLogic(UPloadFileName);

            List<BOMBookingEntity> list = logic.GetBOMResponseDataList();

            bool isErrFlag = false;

            string errMsgFormat = "<font color=red>{0}-->[資料:{1}]-->[錯誤訊息：{2}]</font><br>";

            string errMsg = "";

            BOMLogic bomLogic = new BOMLogic();

            AsusBomLogic asusLogic = new AsusBomLogic();

            SortedList<string, string> bomSList = new SortedList<string, string>();

            if (list.Count > 0)
            {


                foreach (BOMBookingEntity t in list)
                {
                    if (bomSList.ContainsKey(t.BOMId))
                    {
                        errMsg += String.Format(errMsgFormat, t.BOMId, t.BOMId, "有重複的料號");
                        isErrFlag = true;
                    }
                    else
                    {
                        bomSList.Add(t.BOMId, t.BOMId);
                    }

                    //檢查BOM Id是否正確
                    string bomName = bomLogic.GetTipTopBomName(t.BOMId);

                    if (bomName == null)
                    {
                        errMsg += String.Format(errMsgFormat, t.BOMId, t.BOMId, "無法取得BOM的詳細資料");
                        isErrFlag = true;
                    }

                    //判斷 PVT Time 是否符合時間格式
                    if (t.PVTTime2 == null)
                    {
                        errMsg += String.Format(errMsgFormat, t.BOMId, t.PVTTime, "時間格式有錯，正確格式為YYYY/MM/DD");
                        isErrFlag = true;
                    }

                    //判斷 PVT QTY數量是數字
                    int num;
                    if (!int.TryParse(t.PVTQty, out num))
                    {
                        errMsg += String.Format(errMsgFormat, t.BOMId, t.PVTQty, "PVT數量有錯，正確格式為數字");
                        isErrFlag = true;
                    }

                    //判斷PVT Location

                    if (asusLogic.GetEmsSite(t.PVTLocation) == null)
                    {
                        errMsg += String.Format(errMsgFormat, t.BOMId, t.PVTLocation, "PVT Location有錯，請參考對照表處理");
                        isErrFlag = true;
                    }


                }
            }
            else
            {
                errMsg += "<font color=red>上傳筆數是0，請確認[A欄位]上傳選項的一定都要勾Y才之上傳</font>";
                isErrFlag = true;
            }
          

            if (isErrFlag)
            {
                lbErrMsg.Text = errMsg;
            }

            isFlag = isErrFlag ;


            if (!isErrFlag && list.Count>0)
            {


                //資料要經過整理
                foreach (BOMBookingEntity t in list)
                {
                    t.EmpId = LoginUserInfo.UserId;

                    string bomName = bomLogic.GetTipTopBomName(t.BOMId);

                    if (bomName != null)
                    {
                        t.BOMName = bomName;
                    }
                    else
                    {
                        isFlag = false;
                        t.BOMName = "Error";
                    }

                }

                GridView2.DataSource = list;
                GridView2.DataBind();

                if (list.Count == 0)
                {
                    isFlag = false;
                }

            }


            if (!isErrFlag && list.Count > 0)
            {
                lnkSave.Visible = true;
            }
            else
            {
                lnkSave.Visible = false;
            }
                    
            
            
        }

        private string FilterPNName(List<KeyValuePair<string, string>> list, string id)
        {
            string strValue = "";

            foreach (KeyValuePair<string, string> t in list)
            {
                if (t.Key == id)
                {
                    strValue = t.Value;
                    break;
                }
            }

            return strValue;
        }

        protected void GridView1_Init(object sender, EventArgs e)
        {
            this.GenerateGridViewColumn<QueryColumn2Attribute>(GridView1, typeof(FormPNEntity));
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
                
                for (int i = 0; i < 20; i++)
                {
                    e.Row.Cells[BomInt + i].Visible=false;                    


                }


            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[0].CssClass = "locked";
            //e.Row.Cells[1].CssClass = "locked";
            //e.Row.Cells[2].CssClass = "locked";
            //e.Row.Cells[3].CssClass = "locked";
        }

        //更新資料
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            switch (UpLoadMode)
            { 
                case EnumUploadMode.PN:
                    SavePNData();
                    break;
                case EnumUploadMode.BOM:
                    SaveBOMData();
                    break;
                case EnumUploadMode.Main:
                    SaveMainData();
                    break;
            }
           
        }

        private void SavePNData()
        {
            ExcelLogic logic = new ExcelLogic(UPloadFileName);

            FormResponseEntity entity = logic.GetResponseData();

            FormLogic flogic = new FormLogic();

            SortedList<string, FormPNEntity> pnList = new SortedList<string, FormPNEntity>();

            foreach (FormPNEntity t in entity.PNList)
            {
                t.FormId = FormId;
                t.UpdateTime = DateTime.Now.ToString();
                t.UpdateUser = this.LoginUserInfo.LoginId;

                pnList.Add(FormId + t.PN, t);

            }

            if (pnList.Count > 0)
            {
                if (flogic.UpdateResponseForm(pnList))
                {
                    lbSaveErrMsg.Text = "上傳更新完畢";
                }
                else
                {
                    lbSaveErrMsg.Text = "上傳失敗";
                }
            }
            else
            {
                lbSaveErrMsg.Text = "無資料更新，請確認";
            }

           
        }

        private void SaveMainData()
        {
            ExcelLogic logic = new ExcelLogic(UPloadFileName);

            FormResponseEntity entity = logic.GetResponseData();

            FormLogic flogic = new FormLogic();

            SortedList<string, GenPNEntity> pnList = new SortedList<string, GenPNEntity>();

            foreach (FormPNEntity t in entity.PNList)
            {
                GenPNEntity obj = new GenPNEntity();

                obj.ActionDate = "";
                obj.AddSource = t.AddSource;
                obj.AddSourceComment = t.AddSourceComment;
                obj.Alert = t.Alert;
                obj.EOL = t.EOL;
                obj.LTWeeks = t.LTWeeks;
                obj.MainId = FormId;
                obj.PN = t.PN;
                obj.PNProperty = t.PNProperty;
                obj.RiskBuy = t.RiskBuy;
                obj.UpdateTime = DateTime.Now.ToString();
                obj.UpdateUser = LoginUserInfo.LoginId;

                pnList.Add(FormId + t.PN, obj);

            }

            if (pnList.Count > 0)
            {
                if (flogic.UpdateResponseMain(pnList))
                {
                    lbSaveErrMsg.Text = "上傳更新完畢";
                }
                else
                {
                    lbSaveErrMsg.Text = "上傳失敗";
                }
            }
            else
            {
                lbSaveErrMsg.Text = "無資料更新，請確認";
            }
        }

        private void SaveBOMData()
        {
            bool isFlag = true;

            string bomNameString = "";

            log.Info("Save BOM Data");

            ExcelLogic logic = new ExcelLogic(UPloadFileName);

            log.Info("Upload BOM Excel File");

            List<BOMBookingEntity> list = logic.GetBOMResponseDataList();

            log.Info("Get Bom Booking List="+list.Count);

            BOMLogic bomLogic = new BOMLogic();

            foreach (BOMBookingEntity obj in list)
            {
                log.Info("Get BOM Name=" + obj.BOMName);

                string bomName=bomLogic.GetTipTopBomName(obj.BOMId);

                if (bomName != null)
                {

                    obj.EmpId = LoginUserInfo.UserId;
                    obj.CompanyId = LoginInfo.Company;

                    obj.BOMName = bomName;

                    if (obj.BOMDesc.Length > 50)
                    {
                        obj.BOMDesc = obj.BOMDesc.Substring(0, 50);
                    }


                    obj.CreateUser = LoginUserInfo.LoginId;
                    obj.CreateTime = DateTime.Now.ToString();
                    obj.UpdateUser = LoginUserInfo.LoginId;
                    obj.UpdateTime = DateTime.Now.ToString();

                    obj.WorkStatus = Convert.ToString((int)EnumWorkStatus.Wait); //等待展開
                    obj.BookDate = DateTime.Now.ToString();

                    obj.BookingCreateUser = LoginUserInfo.LoginId;
                    obj.BookingCreateTime = DateTime.Now.ToString();
                    obj.BookingUpdateUser = LoginUserInfo.LoginId;
                    obj.BookingUpdateTime = DateTime.Now.ToString();

                    log.Info("Booking Data Finished");
                }
                else
                {
                    log.Info("BOM Name is Null");

                    bomNameString += obj.BOMId;

                    isFlag = false;

                }
                
            }

            if (isFlag)
            {
                if (bomLogic.InserBatchBomData(list))
                {
                    lbSaveErrMsg.Text = "上傳更新完畢";
                }
                else
                {
                    lbSaveErrMsg.Text = "上傳失敗";
                }
            }
            else
            {
                lbSaveErrMsg.Text = "上傳失敗：無法取得BOM Name名稱"+bomNameString;
            }

            
        }
    }
}