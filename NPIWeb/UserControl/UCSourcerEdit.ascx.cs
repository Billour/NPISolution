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
using Asus;
using AsusLibrary;
using AsusLibrary.Utility;
using System.Collections.Generic;

using AsusWeb.Page;


namespace AsusWeb.UserControl
{
    public partial class UCSourcerEdit : BaseControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //取得目前的狀態
            EnumState state = EnumUtil.StringToEnum<EnumState>(lbPageState.Text);

            this.CreateTable<SourcerEntity>("A", "~/Layout/TableLayout.ascx", ph1, state, Asus.EnumTableColumn.OneColumn, "", "", "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 員工工號資料
        /// </summary>
        public string AccountNo
        {
            set
            {
                ViewState["AccountNo"] = value;
            }
            get
            {
                if (ViewState["AccountNo"] == null)
                {
                    throw new Exception("無法取得工號資料");
                }
                return ViewState["AccountNo"].ToString();
            }

        }

        /// <summary>
        /// 顯示資料
        /// </summary>
        public void Show()
        {

            if (PageState == EnumState.Modify || PageState == EnumState.Query)
            {
                SourcerLogic logic = new SourcerLogic();

                SourcerEntity obj = logic.GetSourcerUser(AccountNo,LoginInfo.Company);

                this.SetClassValueToControl("A", obj, PageState);

                List<ComponentRefEntity> list = logic.GetSourcerComponentList(AccountNo,LoginInfo.Company);

                CheckBoxList cbl = (CheckBoxList)this.FindControl("A" + "cbl" + "Component");

                foreach (ListItem li in cbl.Items)
                {
                    if (IsSelected(li.Value, list))
                    {
                        li.Selected = true;
                    }
                    else
                    {
                        li.Selected = false;
                    }
                }
            }           
           
        }

        private bool IsSelected(string idValue, List<ComponentRefEntity> list)
        {
            bool isFlag=false;

            foreach (ComponentRefEntity c in list)
            {
                if (idValue == c.ComponentId)
                {
                    isFlag = true;
                    break;
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

            SourcerLogic logic = new SourcerLogic();

            SourcerEntity obj = OnSave<SourcerEntity>("A");


            if (PageState == EnumState.Create)
            {
                //先確定是否有此人存在

                EmployeeEntity emp = logic.GetUserInfo(obj.AccountNo, LoginInfo.Company);

                if (emp == null)
                {
                    ShowAlertMessage("此帳號不存在");
                    return false;
                }

                string userName = String.Format("{0}({1})",emp.EmpEnglishName,emp.EmpChineseName);

               
                    obj.AccountName = userName;

                    obj.Role = EnumRole.Sourcer.ToString();
                    obj.CompanyId = emp.CompanyId;

                    obj.CreateUser = LoginUserInfo.LoginId;
                    obj.CreateTime = DateTime.Now.ToString();
                    obj.UpdateUser = LoginUserInfo.LoginId;
                    obj.UpdateTime = DateTime.Now.ToString();

                    //New List<>

                    List<ComponentRefEntity> list = new List<ComponentRefEntity>();

                    //Find Control
                    CheckBoxList cbl = (CheckBoxList)this.FindControl("A" + "cbl" + "Component");

                    foreach (ListItem li in cbl.Items)
                    {
                        if (li.Selected)
                        {
                            ComponentRefEntity entity = new ComponentRefEntity();

                            entity.EmpId = obj.AccountNo;
                            entity.ComponentId = li.Value;
                            entity.CompanyId = emp.CompanyId;

                            list.Add(entity);
                        }
                    }

                    obj.ComponentList = list;

                    return logic.CreateNewSourcer(obj);
                


            }
            else if (PageState == EnumState.Modify)
            {
                obj.Role = EnumRole.Sourcer.ToString();
                obj.CompanyId = LoginInfo.Company;

                obj.UpdateUser = LoginUserInfo.LoginId;
                obj.UpdateTime = DateTime.Now.ToString();

                ////Find Control
                List<ComponentRefEntity> list = new List<ComponentRefEntity>();

                CheckBoxList cbl = (CheckBoxList)this.FindControl("A" + "cbl" + "Component");

                foreach (ListItem li in cbl.Items)
                {
                    if (li.Selected)
                    {
                        ComponentRefEntity entity = new ComponentRefEntity();

                        entity.EmpId = obj.AccountNo;
                        entity.ComponentId = li.Value;
                        entity.CompanyId = LoginInfo.Company;

                        list.Add(entity);
                    }
                }

                obj.ComponentList = list;

                return logic.UpdateSourcer(obj);
            }


            return false;
        }

       
    }
}