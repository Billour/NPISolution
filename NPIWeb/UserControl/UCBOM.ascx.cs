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

            //���o�ثe�����A
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
                    throw new Exception("�L�k���o�u�����");
                }
                return ViewState["BomNo"].ToString();
            }

        }

        /// <summary>
        /// PM ���u�b��
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
                    throw new Exception("�L�k���o�u�����");
                }
                return ViewState["PMAccountNo"].ToString();
            }

        }

        /// <summary>
        /// ��ܸ��
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
                    throw new Exception("BOMNo="+BomNo+"�L�k���o��ơA�Ьd��");
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
        /// ���ҬO�_���T
        /// </summary>
        /// <returns></returns>
        public bool Valid()
        { 
          bool isFlag=true;

          TextBox tbPVTQty=ph1.FindControl("A"+"tb"+"PVTQty") as TextBox;

          if (tbPVTQty == null)
          {
              throw new Exception("�L�k���o�Ͳ��ƶq�����");
          }

          string pvQtN = tbPVTQty.Text;

          if (!ValidHelper.IsNumberic(pvQtN))
          {
              ShowAjaxAlertMessage(tbPVTQty, "�Ͳ��ƶq�������Ʀr");

              tbPVTQty.Focus();

              isFlag = false;
          }

          ////�ĤG�q MPQty1
          //if (isFlag)
          //{
          //    TextBox tbMPQ1Qty = ph1.FindControl("A" + "tb" + "MPQ1Qty") as TextBox;

          //    if (tbMPQ1Qty == null)
          //    {
          //        throw new Exception("�L�k���oQ1 �ƶq�����");
          //    }

          //    string MPQ1Qty = tbMPQ1Qty.Text;

          //    if (!ValidHelper.IsNumberic(MPQ1Qty))
          //    {
          //        ShowAjaxAlertMessage(tbMPQ1Qty, "Q1 �ƶq�������Ʀr");

          //        tbMPQ1Qty.Focus();

          //        isFlag = false;
          //    }
          //}

          ////�ĤT�q MPQty2
          //if (isFlag)
          //{
          //    TextBox tbMPQ2Qty = ph1.FindControl("A" + "tb" + "MPQ2Qty") as TextBox;

          //    if (tbMPQ2Qty == null)
          //    {
          //        throw new Exception("�L�k���oQ2 �ƶq�����");
          //    }

          //    string MPQ2Qty = tbMPQ2Qty.Text;

          //    if (!ValidHelper.IsNumberic(MPQ2Qty))
          //    {
          //        ShowAjaxAlertMessage(tbMPQ2Qty, "Q2 �ƶq�������Ʀr");

          //        tbMPQ2Qty.Focus();

          //        isFlag = false;
          //    }
          //}


          //�ĥ|�q PVTTime
          if (isFlag)
          {
              MonthCalendar tbPVTTime = ph1.FindControl("A" + "cal" + "PVTTime") as MonthCalendar;

              if (tbPVTTime == null)
              {
                  throw new Exception("�L�k���o�Ͳ��ɶ������");
              }

              string PVTTime = tbPVTTime.Text;

              if (!ValidHelper.IsDate(PVTTime))
              {
                  ShowAjaxAlertMessage(tbPVTTime, "PVT �ɶ����������T���ɶ��榡");

                  tbPVTTime.Focus();

                  isFlag = false;
              }
          }

          ////�Ĥ��q MPTime
          //if (isFlag)
          //{
          //    MonthCalendar tbMPTime = ph1.FindControl("A" + "cal" + "MPTime") as MonthCalendar;

          //    if (tbMPTime == null)
          //    {
          //        throw new Exception("�L�k���o�j�q�Ͳ��ɶ������");
          //    }

          //    string MPTime = tbMPTime.Text;

          //    if (!ValidHelper.IsDate(MPTime))
          //    {
          //        ShowAjaxAlertMessage(tbMPTime, "MP �ɶ����������T���ɶ��榡");

          //        tbMPTime.Focus();

          //        isFlag = false;
          //    }
          //}

          //�Ĥ��q �T�{���a PVTLocation
          if (PageState == EnumState.Create)
          {
              if (isFlag)
              {
                  RadioButtonList rblPVTLocation = ph1.FindControl("A" + "rbl" + "PVTLocation") as RadioButtonList;

                  if (rblPVTLocation == null)
                  {
                      throw new Exception("�L�k���o���a�����");
                  }

                  string PVTLocation = rblPVTLocation.SelectedValue;

                  if (PVTLocation == "")
                  {
                      ShowAjaxAlertMessage(rblPVTLocation, "�T�{�Ͳ��a�I�������");

                      rblPVTLocation.Focus();

                      isFlag = false;
                  }

                                  
              }
          }

            return isFlag;
        }

        

        /// <summary>
        /// �s��
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
                //���T�w���Ƹ���Ƭ��P���T

                string bomName=CheckBOM(obj.BOMId);

                if (bomName!=null)
                {
                    //���T�w�O�_��RD ���H�s�b,���^�򥻸��
                    //EmployeeEntity user = userLogic.GetUserInfo("23");

                    //if (user == null)
                    //{
                    //    ShowAlertMessage("��RD�b���L�k���o");
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

                    obj.WorkStatus = Convert.ToString((int)EnumWorkStatus.Wait); //���ݮi�}
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

                    ShowAjaxAlertMessage(lbPageState, "BOM��ƵL�k���o�A�Э��s��J");
                    //ShowAlertMessage("BOM��ƵL�k���o�A�Э��s��J");
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
        /// Check BOM ��ƥ��T
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
            log.Info("�U��Excel");

            string path = Server.MapPath(Request.ApplicationPath);

            if (path.Substring(path.Length - 1, 1) == "\\")
            {
                path = path.Substring(0, path.Length - 1);
            }

            string templateFile = path + "\\Excel\\BOMUploadTemplate.xls";

            log.Info("�]�w�U���ɮ�");
            string saveFile = path + String.Format("\\TempDoc\\Bom{0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.UserEnglishName);


            ExcelLogic logic = new ExcelLogic(templateFile, saveFile);

            

            string workFile = "";

            if (logic.GenerateTemplateBomUploadFile())
            {
                workFile = saveFile;
            }
            else
            {
                throw new Exception("�L�k�إ�Excel�ɮסA�Ьd����]");
            }

            return workFile;

            
        }


    }
}