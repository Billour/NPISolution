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
using System.Collections.Generic;
using Asus;

using AsusLibrary;
using AsusLibrary.Utility;
using Asus.Bussiness.Attribute;
using Asus.Bussiness.Map;

using log4net;
using Asus.Analysis.Attribute;
using AsusLibrary.Doc.TeamDeveloper;



namespace AsusWeb.UserControl
{
    public partial class UCResponse : BaseControl
    {
        public event AsusEventHandler ResultClick;

        private int BomInt = 5;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
       
        /// <summary>
        /// ���N��
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
                    throw new Exception("�L�k���oFormId�N���A�Ьd����]");
                }
                return ViewState["FormId"].ToString();
            }

        }

        /// <summary>
        /// ���ʤH��
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
                    throw new Exception("�L�k���o�u�����");
                }
                return ViewState["SourcerUserId"].ToString();
            }

        }

        /// <summary>
        /// ���ʤH�����q
        /// </summary>
        public string SourcerUserCompanyId
        {
            set
            {
                ViewState["SourcerUserCompanyId"] = value;
            }
            get
            {
                if (ViewState["SourcerUserCompanyId"] == null)
                {
                    throw new Exception("�L�k���o���q���");
                }
                return ViewState["SourcerUserCompanyId"].ToString();
            }

        }

        /// <summary>
        /// �i�J��PM�ϥΪ̤u��
        /// </summary>
        public string PMUserId
        {
            set
            {
                ViewState["PMUserId"] = value;
            }
            get
            {
                if (ViewState["PMUserId"] == null)
                {
                    throw new Exception("�L�k���o�u�����");
                }
                return ViewState["PMUserId"].ToString();
            }

        }

        public string PMCompanyId
        {
            set
            {
                ViewState["PMCompanyId"] = value;
            }
            get
            {
                if (ViewState["PMCompanyId"] == null)
                {
                    throw new Exception("�L�k���oPM���q���");
                }
                return ViewState["PMCompanyId"].ToString();
            }

        }

        public string[] SourcerPNGroup
        {
            set
            {
                ViewState["SourcerPNGroup"] = value;
            }
            get
            {
                if (ViewState["SourcerPNGroup"] == null)
                {
                    throw new Exception("�L�k���oSourcer�^�иs�ո��");
                }
                return (string[])ViewState["SourcerPNGroup"];
            }

        }

        

        /// <summary>
        /// �p�����j�p
        /// </summary>
        public int BomCount
        {
            set
            {
                ViewState["BomCount"] = value;
            }
            get
            {
                if (ViewState["BomCount"] == null)
                {
                    ViewState["BomCount"] = 0;
                }
                return Convert.ToInt16(ViewState["BomCount"]);
            }

        }

        /// <summary>
        /// �ϥΦ�����A�����T��
        /// �Ĥ@��Sourcer
        /// �ĤG�ج�PM
        /// �ĤT�ج��޲z��
        /// </summary>
        public EnumRole UseRole
        {
            set
            {
                ViewState["UseRole"] = value;
            }
            get
            {
                if (ViewState["UseRole"] == null)
                {
                    throw new Exception("�L�k���o���⫬�A");
                }
                return (EnumRole)ViewState["UseRole"];
            }
        }



        /// <summary>
        /// User Control Entry
        /// </summary>
        public void Show()
        {
            this.Visible = true;

            BindBomCount(UseRole);

            BindPNGroup(UseRole);

            QueryFormDate();

            QueryData(UseRole);
           
        }

        /// <summary>
        /// �p��BOM���p��ƭ�
        /// </summary>
        private void BindBomCount(EnumRole role)
        {
            BomCount =GetBookingBomList(role).Count;

            if (BomCount > 20)
            {
                BomCount = 20;
            }
        }

        private void BindPNGroup(EnumRole role)
        {
            switch (role)
            { 
                case EnumRole.Management:
                    pnlPN.Visible = true;
                    SetPNData();
                    break;
                case EnumRole.PM:
                    pnlPN.Visible = true;
                    SetPNData();
                    break;
                case EnumRole.Sourcer:
                    if (PageState == EnumState.Modify)
                    {
                        pnlPN.Visible = true;
                        SetPNData();
                    }
                    else if (PageState == EnumState.Query)
                    {
                        pnlPN.Visible = false;
                        SetPNData();
                    }
                  
                    break;
                default:
                    throw new Exception("�L�k���o���������⪺�U�Կﶵ");
            }
                      
        }

        private void SetPNData()
        {
            switch (UseRole)
            { 
                case EnumRole.Sourcer:
                    SetSourcerPnData();
                    break;
                case EnumRole.Management:
                    SetAllPnData();
                    break;
                case EnumRole.PM:
                    SetAllPnData();
                    break;
                default:
                    throw new Exception("�L�k���o��������PNGroup��@�A�Ьd��");
            }

            
        }

        private void SetSourcerPnData()
        {
            SourcerLogic logic = new SourcerLogic();

            List<ComponentRefEntity> list = logic.GetSourcerComponentList(SourcerUserId, SourcerUserCompanyId);

            ddlPNGroup.DataSource = list;
            ddlPNGroup.DataTextField = "ComponentName";
            ddlPNGroup.DataValueField = "ComponentId";
            ddlPNGroup.DataBind();

            ListItem li = new ListItem("------", "A");

            ddlPNGroup.Items.Insert(0, li);

            //Set GroupPN
            string[] args = new string[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                args[i] = ((ComponentRefEntity)list[i]).ComponentId;
            }

            SourcerPNGroup = args;
        }

        private void SetAllPnData()
        {
            ComponentLogic logic = new ComponentLogic();

            List<ComponentGroupEntity> list = logic.GetComponentGroupList();

            ddlPNGroup.DataSource = list;
            ddlPNGroup.DataTextField = "Name";
            ddlPNGroup.DataValueField = "Id";
            ddlPNGroup.DataBind();

            
            //Set GroupPN
            string[] args = new string[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                args[i] = ((ComponentGroupEntity)list[i]).ID;
            }

            SourcerPNGroup = args;
        }

        private void QueryFormDate()
        {
            FormLogic logic = new FormLogic();

            FormEntity obj = logic.QueryForm(FormId);

            lbFormdate.Text = obj.FormDate;

            //���o��RD PM ���W�r

        }

        /// <summary>
        /// ����GridView���
        /// </summary>
        private void GenerateColumn()
        {
            EnumState state = EnumUtil.StringToEnum<EnumState>(lbPageState.Text);

            if (state == EnumState.Modify)
            {
                this.GenerateGridViewColumn(GridView1, typeof(FormPNEntity));
            }
            else if (state == EnumState.Query)
            {
                this.GenerateGridViewColumn<QueryColumn2Attribute>(GridView1, typeof(FormPNEntity));
            }

        }

        private void QueryData(EnumRole role)
        {
            log.Info("�}�l�i�}PN");

            FormResponseEntity fr = GetFormData(role);

            log.Info("�}�l�i�}PN-����");

            GridView1.DataSource =fr.PNList;
            GridView1.DataBind();

           
            lbPNCount.Text = fr.PNList.Count.ToString() + "��";

            log.Info("DataBind-����");

            for (int i = 0; i < 20; i++)
            {
                if (i < BomCount)
                {
                    BOMBookingEntity entity = (BOMBookingEntity)fr.BOMList[i];
                    BoundField b = (BoundField)GridView1.Columns[BomInt + i];
                                            
                    //b.DataField = entity.BOMId;  //2008.10.15 Bin BugFix:Marked  
                    //b.HeaderText = String.Format("{0}({1})", entity.BOMId, entity.BOMName.Trim());
                    b.Visible = true;
                }
                else
                {
                    BoundField b = (BoundField)GridView1.Columns[BomInt + i];
                    b.Visible = false;
                }



            }
           

                        
            ////Set Data To BOM

            

            foreach (GridViewRow row in GridView1.Rows)
            {
                
                for (int i = 0; i < BomCount; i++)
                {
                    //���obomId
                    BOMBookingEntity bookingBom = (BOMBookingEntity)fr.BOMList[i];

                    DataKey data = GridView1.DataKeys[row.RowIndex];

                    BoundField b = (BoundField)GridView1.Columns[BomInt + i];

                    if (fr.BOMPNQtyList.ContainsKey(bookingBom.BOMId + data.Values["FormId"].ToString() + data.Values["PN"].ToString()))
                    {
                        row.Cells[BomInt + i].Text = fr.BOMPNQtyList[bookingBom.BOMId + data.Values["FormId"].ToString() + data.Values["PN"].ToString()];
                    }
                   
                }
            }

            
            
        }

        /// <summary>
        /// ���o���Form��T
        /// </summary>
        /// <returns></returns>
        private FormResponseEntity GetFormData(EnumRole role)
        {
            FormResponseEntity obj = new FormResponseEntity();

            FormLogic logic = new FormLogic();

            obj.FormId = FormId;

            switch (role)
            { 
                case EnumRole.Sourcer:
                    obj.PNList = logic.QueryFormPNList(FormId, ddlPNGroup.SelectedValue, SourcerPNGroup);
                    break;
                case EnumRole.PM:
                    obj.PNList = logic.QueryFormPNList(FormId, ddlPNGroup.SelectedValue, SourcerPNGroup);
                    break;
                case EnumRole.Management:
                    obj.PNList = logic.QueryFormPNList(FormId, ddlPNGroup.SelectedValue, SourcerPNGroup);
                    break;
                default:
                    throw new Exception("�L�k���o��@������|�󤸥�Ƹ�����T");
                    
            }


            obj.BOMList = GetBookingBomList(role);

            Dictionary<string, string> dicList = logic.QueryFormBOMPNQtyList(FormId);

            obj.BOMPNQtyList = dicList;

            

            return obj;
        }

        private FormResponseEntity GetDownloadFormData(EnumRole role)
        {
            FormResponseEntity obj = new FormResponseEntity();

            FormLogic logic = new FormLogic();

            obj.FormId = FormId;

            switch (role)
            {
                case EnumRole.Sourcer:

                    DateTime myDate = new DateTime(2009, 6, 23);

                    if (DateUtil.DateDiff(DateInterval.Day, DateTime.Now, myDate) > 0)
                    {
                        obj.PNList = logic.QueryFormPNList(FormId, ddlPNGroup.SelectedValue, SourcerPNGroup);
                    }
                    else
                    {
                        obj.PNList = logic.QueryMainPNListByFormId(FormId, LoginUserInfo.UserId);
                    }

                    //obj.PNList = logic.QueryFormPNList(FormId, ddlPNGroup.SelectedValue, SourcerPNGroup);
                                        

                    break;
                case EnumRole.PM:
                    obj.PNList = logic.QueryFormPNList(FormId);
                    break;
                case EnumRole.Management:
                    obj.PNList = logic.QueryFormPNList(FormId);
                    break;
                default:
                    throw new Exception("�L�k���o��@������|�󤸥�Ƹ�����T");

            }


            obj.BOMList = GetBookingBomList(role);

            Dictionary<string, string> dicList = logic.QueryFormBOMPNQtyList(FormId);

            obj.BOMPNQtyList = dicList;



            return obj;
        }

        /// <summary>
        /// ���oBOM���
        /// Sourcer ���P�@�~
        /// </summary>
        /// <returns></returns>
        private List<BOMBookingEntity> GetBookingBomList(EnumRole role)
        {
            BOMLogic bomLogic = new BOMLogic();

            List<BOMBookingEntity> bomList = null;

            switch (role)
            { 
                case EnumRole.PM:
                    bomList = bomLogic.QueryFromBookingBOM(FormId,this.LoginUserInfo.UserId);
                    break;
                case EnumRole.Sourcer:
                    bomList = bomLogic.QueryFromBookingBOM(FormId);
                    break;
                case EnumRole.Management:
                    bomList = bomLogic.QueryFromBookingBOM(FormId,PMUserId);
                    break;
                default:
                    throw new Exception("�L�k���o�����A������");
                   
            }

           
            return bomList;
        }

        
       

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[0].CssClass = "locked";
            //e.Row.Cells[1].CssClass = "locked";
            //e.Row.Cells[2].CssClass = "locked";
            //e.Row.Cells[3].CssClass = "locked";
        }

        protected void ddlPNGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GenerateColumn();

            QueryData(UseRole);
        }

        /// <summary>
        /// �s�ɵ{��
        /// Fix:2008/11/06 Bin �ק�u���I��W�Ǫ���Ƥ~��W��
        /// </summary>
        /// <returns>�O�_�s�ɦ��\true=���\ false=�����\</returns>
        [HistoryLog("UCResponse", "2008/11/06 10:55:00", "2008/11/06/06 17:00:00", typeof(WenBin), "Fix:2008/11/06 �ק�u���I��i�W�ǡj����Ƥ~��W��")]
        public bool Save()
        {
            

            if (PageState == EnumState.Modify)
            {

                SortedList<string, FormPNEntity> dicList = new SortedList<string, FormPNEntity>();

                foreach (GridViewRow row in GridView1.Rows)
                {
                    //CheckBox cb = ((CheckBox)row.Cells[BomInt + 1 + BomCount].FindControl("cbIsAlert"));
                    CheckBox cb = row.FindControl("cbIsAlert") as CheckBox;

                    if (cb == null)
                    {
                        throw new Exception("�L�k���o�W�ǫ��s����T");
                    }

                    if (cb.Checked)
                    {
                        FormPNEntity pnEntity = new FormPNEntity();

                        DataKey data = GridView1.DataKeys[row.RowIndex];

                        string formId = data.Values["FormId"].ToString();

                        string pn = data.Values["PN"].ToString();

                        pnEntity.FormId = formId;
                        pnEntity.PN = pn;

                        //string aa = ((DropDownList)row.Cells[5].FindControl("ddl" + "PNProperty")).SelectedValue;


                        //a
                        pnEntity.Alert = cb.Checked ? "Y" : "N";

                        //Add RiskBuy
                        CheckBox cb1 = row.FindControl("cb"+"IsRiskBuy") as CheckBox;

                        pnEntity.RiskBuy = cb1.Checked ? "Y" : "N";

                        pnEntity.LTWeeks = ((TextBox)row.FindControl("tb" + "LTWeeks")).Text;

                        pnEntity.PNProperty = ((DropDownList)row.FindControl("ddl" + "PNProperty")).SelectedValue;
                        pnEntity.AddSource = ((DropDownList)row.FindControl("ddl" + "AddSource")).SelectedValue;
                        pnEntity.AddSourceComment = ((TextBox)row.FindControl("tb" + "AddSourceComment")).Text;
                        pnEntity.EOL = ((TextBox)row.FindControl("tb" + "EOL")).Text;

                        //pnEntity.PNProperty = ((DropDownList)row.Cells[BomInt + 1 + BomCount].FindControl("ddl" + "PNProperty")).SelectedValue;
                        //pnEntity.AddSource = ((DropDownList)row.Cells[BomInt + 2 + BomCount].FindControl("ddl" + "AddSource")).SelectedValue;
                        //pnEntity.AddSourceComment = ((TextBox)row.Cells[BomInt + 3 + BomCount].FindControl("tb" + "AddSourceComment")).Text;
                        //pnEntity.EOL = ((TextBox)row.Cells[BomInt + 4 + BomCount].FindControl("tb" + "EOL")).Text;

                        pnEntity.UpdateTime = DateTime.Now.ToString();

                        pnEntity.UpdateUser = this.LoginUserInfo.LoginId;

                        dicList.Add(formId + pn, pnEntity);
                    }

                }

                FormLogic logic = new FormLogic();

                return logic.UpdateResponseForm(dicList);



            }


            return false;
        }

        protected void GridView1_Init(object sender, EventArgs e)
        {
            GenerateColumn();            
        }

        /// <summary>
        /// ����Header Tilte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[3].Text = "Hello World";

                List<BOMBookingEntity> bomList = GetBookingBomList(UseRole);

                for (int i = 0; i < 20; i++)
                {
                    if (i < BomCount)
                    {
                        BOMBookingEntity entity = (BOMBookingEntity)bomList[i];
                        e.Row.Cells[BomInt + i].Text = String.Format("{0}<br>({1})", entity.BOMId, entity.BOMName.Trim()); ;

                        e.Row.Cells[BomInt + i].Text = Server.HtmlDecode(e.Row.Cells[BomInt + i].Text);
                    }

                }

               
            }

        }

        /// <summary>
        /// DownLoad Excel
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

            string templateFile=path + "\\Excel\\BOMTemplate.xls";

            log.Info("�]�w�U���ɮ�");
            string saveFile=path + String.Format("\\TempDoc\\{2}-{0}-{1}.xls",DateTime.Now.ToString("yyyyMMdd"),this.LoginUserInfo.UserEnglishName,FormId);


            ExcelLogic logic = new ExcelLogic(templateFile, saveFile);

            FormResponseEntity entity = GetDownloadFormData(UseRole);

            string workFile = "";

            if (logic.GenerateBomFile(entity))
            {
                workFile = saveFile;
            }
            else
            {
                throw new Exception("�L�k�إ�Excel�ɮסA�Ьd����]");
            }

            return workFile;


            
        }

        public bool CloseForm()
        {
            FormLogic logic = new FormLogic();

            return logic.CloseForm(FormId,EnumFormstatus.Y.ToString());
        }

       
    }
}