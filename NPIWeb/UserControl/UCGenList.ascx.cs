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
using AsusLibrary;
using Asus.Bussiness.Attribute;

namespace AsusWeb.UserControl
{
    public partial class UCGenList : BaseControl
    {
        public event AsusEventHandler ResultClick;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show()
        {
            this.Visible = true;

            QueryData();

        }

        private string MainId
        {
            set
            {
                ViewState["MainId"] = value;


            }
            get
            {
                if (ViewState["MainId"] == null)
                {
                    throw new Exception("�L�k���oMainId�N���A�Ьd����]");
                }
                return ViewState["MainId"].ToString();
            }

        }

        private void QueryData()
        {
            GenLogic logic = new GenLogic();

            List<GenMainEntity> list = logic.QueryMainList(ddlEnable.SelectedValue);
                        

            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ModifyCommand")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];
                
                DataKey data = GridView1.DataKeys[index];

                MainId= data.Values["MainId"].ToString();

                SetPanelVisibleAndShowInitial2();

                
            }
            else if (e.CommandName == "ModifyCommand2")
            {
                //���o�ثe�W�ǰʧ@
                
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                DataKey data = GridView1.DataKeys[index];

                MainId = data.Values["MainId"].ToString();

                if (ResultClick == null)
                {
                    ResultClick = new AsusEventHandler(DefaultAction);
                }

                ResultClick(this, new string[] { data.Values["MainId"].ToString() });


            }
            else if (e.CommandName == "ModifyCommand3")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                DataKey data = GridView1.DataKeys[index];

                MainId = data.Values["MainId"].ToString();

                string sFile = DownLoadExcel(false);

                Response.AppendHeader("Content-disposition", String.Format("attachment; filename={0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.UserEnglishName));
                Response.ContentType = "Application/vnd.ms-excel";
                Response.WriteFile(sFile);
                Response.End();
            }
            
            
        }


        private void SetPanelVisibleAndShowInitial2()
        {
            pnlVisible2.Visible = true;

            GenLogic logic = new GenLogic();

            DataTable dt = logic.GetGroupListByMainId(MainId);

            if (dt.Rows.Count == 0)
            {
                throw new Exception(String.Format("�L�k���o��MainId={0}���s�ո�ơA�Ьd��", MainId));
            }

            cblGroupList.DataSource = dt;
            cblGroupList.DataTextField = "group_id";
            cblGroupList.DataValueField = "group_id";
            cblGroupList.DataBind();

        }

        /// <summary>
        /// ���ϥ�
        /// </summary>
        private void SetPanelVisibleAndShowInitial()
        {
            pnlVisible.Visible = true;

            GenLogic logic = new GenLogic();

            DataTable dt = logic.GetGroupListByMainId(MainId);

            if (dt.Rows.Count == 0)
            {
                throw new Exception(String.Format("�L�k���o��MainId={0}���s�ո�ơA�Ьd��",MainId));
            }

            ddlGroup.DataSource = dt;
            ddlGroup.DataTextField = "group_id";
            ddlGroup.DataValueField = "group_id";
            ddlGroup.DataBind();

            ListItem li = new ListItem("---ALL---", "*");

            ddlGroup.Items.Insert(0, li);
        }

        
        public string DownLoadExcel(bool isInit)
        {
            log.Info("�U��Excel");

            string path = Server.MapPath(Request.ApplicationPath);

            if (path.Substring(path.Length - 1, 1) == "\\")
            {
                path = path.Substring(0, path.Length - 1);
            }

            string templateFile = path + "\\Excel\\BOMTemplate.xls";

            log.Info("�]�w�U���ɮ�");
            string saveFile = path + String.Format("\\TempDoc\\{2}-{0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.UserEnglishName, MainId);


            ExcelLogic logic = new ExcelLogic(templateFile, saveFile);

            FormResponseEntity entity = GetDownloadFormData(isInit);

            string workFile = "";

            if (logic.GenerateMainBomFile(entity))
            {
                workFile = saveFile;
            }
            else
            {
                throw new Exception("�L�k�إ�Excel�ɮסA�Ьd����]");
            }

            return workFile;



        }

        public string DownLoadExcelByRule()
        {
            log.Info("�U��Excel");

            string path = Server.MapPath(Request.ApplicationPath);

            if (path.Substring(path.Length - 1, 1) == "\\")
            {
                path = path.Substring(0, path.Length - 1);
            }

            string templateFile = path + "\\Excel\\BOMTemplate.xls";

            log.Info("�]�w�U���ɮ�");
            string saveFile = path + String.Format("\\TempDoc\\{2}-{0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.UserEnglishName, MainId);


            ExcelLogic logic = new ExcelLogic(templateFile, saveFile);

            DownLoadMainEntity queryObj = GetQueryRule();

            FormResponseEntity entity =GetDownloadFormDataByRule(queryObj);

            string workFile = "";

            if (logic.GenerateMainBomFile(entity))
            {
                workFile = saveFile;
            }
            else
            {
                throw new Exception("�L�k�إ�Excel�ɮסA�Ьd����]");
            }

            return workFile;



        }

        public string DownLoadExcelByRule2()
        {
            log.Info("�U��Excel");

            string path = Server.MapPath(Request.ApplicationPath);

            if (path.Substring(path.Length - 1, 1) == "\\")
            {
                path = path.Substring(0, path.Length - 1);
            }

            string templateFile = path + "\\Excel\\BOMTemplate.xls";

            log.Info("�]�w�U���ɮ�");
            string saveFile = path + String.Format("\\TempDoc\\{2}-{0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.UserEnglishName, MainId);


            ExcelLogic logic = new ExcelLogic(templateFile, saveFile);

            DownLoadMain2Entity queryObj = GetQueryRule2();

            FormResponseEntity entity = GetDownloadFormDataByRule2(queryObj);

            string workFile = "";

            if (logic.GenerateMainBomFile(entity))
            {
                workFile = saveFile;
            }
            else
            {
                throw new Exception("�L�k�إ�Excel�ɮסA�Ьd����]");
            }

            return workFile;



        }

        /// <summary>
        /// �B�zDownLoad ���
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        private FormResponseEntity GetDownloadFormData(bool isInit)
        {
            FormResponseEntity obj = new FormResponseEntity();

            FormLogic logic = new FormLogic();

            BOMLogic bomLogic = new BOMLogic();

            obj.FormId = MainId;

            obj.PNList = logic.QueryMainPNList(MainId,LoginUserInfo.UserId);

            obj.BOMList = bomLogic.QueryFromBookingBOMByGenId(MainId);

            Dictionary<string, string> dicList = logic.QueryFormBOMPNQtyListByGenId(MainId);

            obj.BOMPNQtyList = dicList;

            return obj;
        }

        /// <summary>
        /// ���o�Ҧ������e
        /// </summary>
        /// <param name="queryObj"></param>
        /// <returns></returns>
        private FormResponseEntity GetDownloadFormDataByRule(DownLoadMainEntity queryObj)
        {
            FormResponseEntity obj = new FormResponseEntity();

            FormLogic logic = new FormLogic();

            BOMLogic bomLogic = new BOMLogic();

            GenLogic genLogic = new GenLogic();

            obj.FormId = MainId;

            obj.PNList = logic.QueryMainPNList(queryObj.MainId,queryObj.GroupId,queryObj.PMUser,queryObj.BomList,LoginUserInfo.UserId);

            obj.BOMList = genLogic.GetMainIdBomListByUserGroup(queryObj.MainId,queryObj.GroupId,queryObj.PMUser,queryObj.BomList);

            Dictionary<string, string> dicList = logic.QueryFormBOMPNQtyListByGenId(MainId);

            obj.BOMPNQtyList = dicList;

            return obj;
        }

        /// <summary>
        /// ���o�Ҧ���PN List By MainID
        /// </summary>
        /// <param name="queryObj"></param>
        /// <returns></returns>
        private FormResponseEntity GetDownloadFormDataByRule2(DownLoadMain2Entity queryObj)
        {
            FormResponseEntity obj = new FormResponseEntity();

            FormLogic logic = new FormLogic();

            BOMLogic bomLogic = new BOMLogic();

            GenLogic genLogic = new GenLogic();

            obj.FormId = MainId;

            // ���oPN List
            obj.PNList = logic.QueryMainPNList2(queryObj.MainId, queryObj.GroupList, queryObj.BomList, LoginUserInfo.UserId);

            obj.BOMList = genLogic.GetBOMListByMainId2<BOMBookingEntity>(queryObj.MainId,queryObj.GroupList,queryObj.BomList);

            Dictionary<string, string> dicList = logic.QueryFormBOMPNQtyListByGenId(MainId);

            obj.BOMPNQtyList = dicList;

            return obj;
        }

        protected void ddlEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryData();
        }

        //�T�{���@�Ǹs��
        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenLogic logic = new GenLogic();

            List<KeyValuePair<string, string>> list = logic.GetUserPMByMainId(ddlGroup.SelectedValue, MainId);


            ddlPM.DataSource = list;
            ddlPM.DataTextField = "Value";
            ddlPM.DataValueField = "Key";
            ddlPM.DataBind();

            ListItem li = new ListItem("---ALL---", "*");

            ddlPM.Items.Insert(0, li);

            if (ddlPM.SelectedValue == "*")
            {
                pnlPNVisible.Visible = false;
            }
            else
            {
                pnlPNVisible.Visible = true;
            }

        }

        /// <summary>
        /// PM ���ܪ����p
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPM.SelectedValue == "*")
            {
                pnlPNVisible.Visible = false;

            }
            else
            {
                pnlPNVisible.Visible = true;

                SetPNList();
            }
        }

        private void SetPNList()
        {
            GenLogic logic = new GenLogic();

            List<BOMBookingEntity> list = logic.GetBOMListByMainId(MainId, ddlPM.SelectedValue);

            

            GridView2.DataSource = list;
            GridView2.DataBind();
        }

        /// <summary>
        /// ��ܥ���/������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView2.Rows)
            {
                CheckBox cb = row.FindControl("cbIsSelected") as CheckBox;

                if (cb == null)
                {
                    throw new Exception("�L�k���oCheckBox������ID=IsSelected");
                }

                cb.Checked = cbSelectAll.Checked;
            }
        }

        /// <summary>
        /// �U��Excel �}�l
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            

            string sFile =DownLoadExcelByRule();

            Response.AppendHeader("Content-disposition", String.Format("attachment; filename={0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.UserEnglishName));
            Response.ContentType = "Application/vnd.ms-excel";
            Response.WriteFile(sFile);
            Response.End();
        }

        private DownLoadMainEntity GetQueryRule()
        {
            DownLoadMainEntity obj = new DownLoadMainEntity();

            List<string> list=new List<string>();

            foreach (GridViewRow row in GridView2.Rows)
            {
                CheckBox cb = row.FindControl("cbIsSelected") as CheckBox;

                if (cb == null)
                {
                    throw new Exception("�L�k���oCheckBox������ID=IsSelected");
                }

                if (cb.Checked)
                {
                    DataKey data = GridView2.DataKeys[row.RowIndex];

                    string bomId = data.Values["BOMId"].ToString();

                    list.Add(bomId);
                }

            }

            obj.BomList = list;
            obj.GroupId=ddlGroup.SelectedValue;
            obj.MainId=MainId;
            obj.PMUser=ddlPM.SelectedValue;
            

            return obj;
        }

        private DownLoadMain2Entity GetQueryRule2()
        {
            DownLoadMain2Entity obj = new DownLoadMain2Entity();

            // Get Group List
            List<string> groupList = new List<string>();

            foreach (ListItem li in cblGroupList.Items)
            {
                if (li.Selected)
                {
                    // �p�JGroup List �̭�
                    groupList.Add(li.Value);
                }
            }

            // �[�JBOM List ���
            List<string> list = new List<string>();

            foreach (GridViewRow row in GridView3.Rows)
            {
                CheckBox cb = row.FindControl("cbIsSelected") as CheckBox;

                if (cb == null)
                {
                    throw new Exception("�L�k���oCheckBox������ID=IsSelected");
                }

                if (cb.Checked)
                {
                    DataKey data = GridView3.DataKeys[row.RowIndex];

                    string bomId = data.Values["BOMId"].ToString();

                    list.Add(bomId);
                }

            }

            obj.BomList = list;
            obj.GroupList = groupList;
            obj.MainId = MainId;
           


            return obj;
        }

        protected void GridView2_Init(object sender, EventArgs e)
        {
            this.GenerateGridViewColumn<QueryColumn3Attribute>(GridView2, typeof(BOMEntity));
        }

        /// <summary>
        /// ��ܥثe�Ҧ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnShowBOM_Click(object sender, EventArgs e)
        {
            GenLogic logic = new GenLogic();

            lbShowMsg.Text = "";

            List<string> groupList = new List<string>();

            foreach (ListItem li in cblGroupList.Items)
            {
                if (li.Selected)
                {
                    groupList.Add(li.Value);
                }
            }

            if (groupList.Count > 0)
            {
                List<GroupBOMEntity> list = logic.GetBOMListByMainId2<GroupBOMEntity>(MainId, groupList);

                if (list.Count > 0)
                {
                    pnlShowBOM.Visible = true;

                    GridView3.DataSource = list;
                    GridView3.DataBind();
                }
                else
                {
                    pnlShowBOM.Visible = false;
                }
            }
            else
            {
                lbShowMsg.Text = "�п�ܸs��(�����O)";

                pnlShowBOM.Visible = false;

                GridView3.DataSource = new List<GroupBOMEntity>();
                GridView3.DataBind();

            }

            

            
        }

        protected void GridView3_Init(object sender, EventArgs e)
        {
            this.GenerateGridViewColumn<QueryColumn3Attribute>(GridView3, typeof(GroupBOMEntity));
        }

        protected void chkSelect2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView3.Rows)
            {
                CheckBox cb = row.FindControl("cbIsSelected") as CheckBox;

                if (cb == null)
                {
                    throw new Exception("�L�k���oCheckBox������ID=IsSelected");
                }

                cb.Checked = chkSelect2.Checked;
            }
        }

        /// <summary>
        /// �U�� Excel �ɮ׸��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadExcel2_Click(object sender, EventArgs e)
        {
            // �ĤG�� ���e
            // ���e �U����Excel �O�H
            
            string sFile = DownLoadExcelByRule2();

            Response.AppendHeader("Content-disposition", String.Format("attachment; filename={0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.UserEnglishName));
            Response.ContentType = "Application/vnd.ms-excel";
            Response.WriteFile(sFile);
            Response.End();
        }
    }
}