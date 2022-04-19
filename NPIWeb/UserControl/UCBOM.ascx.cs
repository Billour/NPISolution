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
using Asus;
using AsusLibrary.Utility;
using AsusLibrary.Logic;
using AsusLibrary;
using AsusLibrary.Config;
using Asus.Helper;
using Asus.UI;

using AsusWeb.Page;

using System.Collections.Generic;


namespace AsusWeb.UserControl
{
    public partial class UCBOM : BaseControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //取得目前的狀態
            EnumState state = EnumUtil.StringToEnum<EnumState>(lbPageState.Text);

            this.CreateTable<BOMBookingEntity>("A", "~/Layout/TableLayout.ascx", ph1,state, Asus.EnumTableColumn.OneColumn, "", "", "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

            
        }

        /// <summary>
        /// BOM N0
        /// </summary>
        public string BomNo
        {
            set
            {
                ViewState["BomNo"] = value;
            }
            get
            {
                if (ViewState["BomNo"] == null)
                {
                    throw new Exception("無法取得工號資料");
                }
                return ViewState["BomNo"].ToString();
            }

        }

        /// <summary>
        /// PM 員工帳號
        /// </summary>
        public string PMAccountNo
        {
            set
            {
                ViewState["PMAccountNo"] = value;
            }
            get
            {
                if (ViewState["PMAccountNo"] == null)
                {
                    throw new Exception("無法取得工號資料");
                }
                return ViewState["PMAccountNo"].ToString();
            }

        }

        /// <summary>
        /// 顯示資料
        /// </summary>
        public void Show()
        {

            if (PageState == EnumState.Modify || PageState == EnumState.Query)
            {
                BOMLogic logic = new BOMLogic();

                List<BOMBookingEntity> list = logic.QueryPMBom(PMAccountNo, BomNo, LoginInfo.Company);

                if (list.Count > 0)
                {
                    BOMBookingEntity obj = list[0];

                    this.SetClassValueToControl("A", obj, PageState);

                }
                else
                {
                    throw new Exception("BOMNo="+BomNo+"無法取得資料，請查明");
                }
                 

                
            }
            else if (PageState == EnumState.Create)
            {
               
                //BOMBookingEntity obj = new BOMBookingEntity();

                //this.SetClassValueToControl("A", obj, PageState);

                ((TextBox)ph1.FindControl("A" + "tb" + "MPQ1Qty")).Text = "-1";
                ((TextBox)ph1.FindControl("A" + "tb" + "MPQ2Qty")).Text = "-1";
                ((MonthCalendar)ph1.FindControl("A" + "cal" + "MPTime")).Text = DateTime.Now.AddYears(1).ToString("yyyy/MM/dd");


                ((RadioButtonList)this.FindControl("A" + "rbl" + "IsOpen")).SelectedValue = "Y";
            }

           
        }

        /// <summary>
        /// 驗證是否正確
        /// </summary>
        /// <returns></returns>
        public bool Valid()
        { 
          bool isFlag=true;

          TextBox tbPVTQty=ph1.FindControl("A"+"tb"+"PVTQty") as TextBox;

          if (tbPVTQty == null)
          {
              throw new Exception("無法取得生產數量的資料");
          }

          string pvQtN = tbPVTQty.Text;

          if (!ValidHelper.IsNumberic(pvQtN))
          {
              ShowAjaxAlertMessage(tbPVTQty, "生產數量必須為數字");

              tbPVTQty.Focus();

              isFlag = false;
          }

          ////第二段 MPQty1
          //if (isFlag)
          //{
          //    TextBox tbMPQ1Qty = ph1.FindControl("A" + "tb" + "MPQ1Qty") as TextBox;

          //    if (tbMPQ1Qty == null)
          //    {
          //        throw new Exception("無法取得Q1 數量的資料");
          //    }

          //    string MPQ1Qty = tbMPQ1Qty.Text;

          //    if (!ValidHelper.IsNumberic(MPQ1Qty))
          //    {
          //        ShowAjaxAlertMessage(tbMPQ1Qty, "Q1 數量必須為數字");

          //        tbMPQ1Qty.Focus();

          //        isFlag = false;
          //    }
          //}

          ////第三段 MPQty2
          //if (isFlag)
          //{
          //    TextBox tbMPQ2Qty = ph1.FindControl("A" + "tb" + "MPQ2Qty") as TextBox;

          //    if (tbMPQ2Qty == null)
          //    {
          //        throw new Exception("無法取得Q2 數量的資料");
          //    }

          //    string MPQ2Qty = tbMPQ2Qty.Text;

          //    if (!ValidHelper.IsNumberic(MPQ2Qty))
          //    {
          //        ShowAjaxAlertMessage(tbMPQ2Qty, "Q2 數量必須為數字");

          //        tbMPQ2Qty.Focus();

          //        isFlag = false;
          //    }
          //}


          //第四段 PVTTime
          if (isFlag)
          {
              MonthCalendar tbPVTTime = ph1.FindControl("A" + "cal" + "PVTTime") as MonthCalendar;

              if (tbPVTTime == null)
              {
                  throw new Exception("無法取得生產時間的資料");
              }

              string PVTTime = tbPVTTime.Text;

              if (!ValidHelper.IsDate(PVTTime))
              {
                  ShowAjaxAlertMessage(tbPVTTime, "PVT 時間必須為正確的時間格式");

                  tbPVTTime.Focus();

                  isFlag = false;
              }
          }

          ////第五段 MPTime
          //if (isFlag)
          //{
          //    MonthCalendar tbMPTime = ph1.FindControl("A" + "cal" + "MPTime") as MonthCalendar;

          //    if (tbMPTime == null)
          //    {
          //        throw new Exception("無法取得大量生產時間的資料");
          //    }

          //    string MPTime = tbMPTime.Text;

          //    if (!ValidHelper.IsDate(MPTime))
          //    {
          //        ShowAjaxAlertMessage(tbMPTime, "MP 時間必須為正確的時間格式");

          //        tbMPTime.Focus();

          //        isFlag = false;
          //    }
          //}

          //第六段 確認產地 PVTLocation
          if (PageState == EnumState.Create)
          {
              if (isFlag)
              {
                  RadioButtonList rblPVTLocation = ph1.FindControl("A" + "rbl" + "PVTLocation") as RadioButtonList;

                  if (rblPVTLocation == null)
                  {
                      throw new Exception("無法取得產地的資料");
                  }

                  string PVTLocation = rblPVTLocation.SelectedValue;

                  if (PVTLocation == "")
                  {
                      ShowAjaxAlertMessage(rblPVTLocation, "確認生產地點必須選取");

                      rblPVTLocation.Focus();

                      isFlag = false;
                  }

                                  
              }
          }

            return isFlag;
        }

        

        /// <summary>
        /// 存檔
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {

            BOMLogic logic = new BOMLogic();

            BOMBookingEntity obj = OnSave<BOMBookingEntity>("A");

            obj.BOMId = obj.BOMId.Trim();

            UserLogic userLogic = new UserLogic();

            if (PageState == EnumState.Create)
            {
                //先確定此料號資料為與正確

                string bomName=CheckBOM(obj.BOMId);

                if (bomName!=null)
                {
                    //先確定是否有RD 此人存在,取回基本資料
                    //EmployeeEntity user = userLogic.GetUserInfo("23");

                    //if (user == null)
                    //{
                    //    ShowAlertMessage("此RD帳號無法取得");
                    //    return false;

                    //}
                    //else
                    //{
                    obj.EmpId = PMAccountNo;
                    obj.CompanyId = LoginInfo.Company;

                    obj.BOMName = bomName;

                    //obj.RDAccount = user.EmpAccountId;
                    //obj.RDName = String.Format("{0}({1})", user.EmpEnglishName, user.EmpChineseName);
                    //obj.RDPhoneNo = user.PhoneNo;

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

                    

                    if (logic.QueryPMBom(PMAccountNo, obj.BOMId, LoginInfo.Company).Count==0)
                    {
                        return logic.Insert<BOMBookingEntity>(obj, DataBaseDB.NPIDB);
                    }
                    else
                    {
                        return logic.InsertDulplicateBookingData(obj);
                    }

                    
                    
                }
                else
                {

                    ShowAjaxAlertMessage(lbPageState, "BOM資料無法取得，請重新輸入");
                    //ShowAlertMessage("BOM資料無法取得，請重新輸入");
                    return false;
                }

              

                return true;


            }
            else if (PageState == EnumState.Modify)
            {
                obj.EmpId = PMAccountNo;
                obj.CompanyId = LoginInfo.Company;
                obj.UpdateUser = LoginUserInfo.LoginId;
                obj.UpdateTime = DateTime.Now.ToString();

                return logic.UpdateDB<BOMBookingEntity>(obj, DataBaseDB.NPIDB);

                
            }


            return false;
        }

        /// <summary>
        /// Check BOM 資料正確
        /// 
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private string CheckBOM(string bomId)
        {
            BOMLogic logic = new BOMLogic();

            return logic.GetTipTopBomName(bomId);
        }

        /// <summary>
        /// DownLoadExcel
        /// </summary>
        /// <returns></returns>
        public string DownLoadExcel()
        {
            log.Info("下載Excel");

            string path = Server.MapPath(Request.ApplicationPath);

            if (path.Substring(path.Length - 1, 1) == "\\")
            {
                path = path.Substring(0, path.Length - 1);
            }

            string templateFile = path + "\\Excel\\BOMUploadTemplate.xls";

            log.Info("設定下載檔案");
            string saveFile = path + String.Format("\\TempDoc\\Bom{0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.UserEnglishName);


            ExcelLogic logic = new ExcelLogic(templateFile, saveFile);

            

            string workFile = "";

            if (logic.GenerateTemplateBomUploadFile())
            {
                workFile = saveFile;
            }
            else
            {
                throw new Exception("無法建立Excel檔案，請查明原因");
            }

            return workFile;

            
        }


    }
}