using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using log4net;
using Spring.Aop;
using System.Reflection;
using System.Data.OleDb;
//using BankProLibrary.Web.UserControl;
//using BankProLibrary.Web;

namespace AsusWeb.Page.Handler
{
    public class ThrowHanler:IThrowsAdvice
    {
        protected ILog log = LogManager.GetLogger(typeof(ThrowHanler));
        
        public void AfterThrowing(MethodInfo method, Object[] args, Object target, Exception err)
        {
            
            log.Error("------------Error 產生---------------");

            log.Error("------------錯誤訊息如下-----------------");
            
            log.Error(err.ToString());
            
            log.Error("-----------Error 結束------------------");
                        
            //RecordLog(target);

           //User Information

           HttpContext context=(HttpContext)args[0];

           HttpRequest myRequest=context.Request;
           
           log.Info("User Host Information");
           
           log.Info(myRequest.UserHostName+myRequest.UserHostAddress+myRequest.UserAgent.ToString());
        }

        //private void RecordLog(Object target)
        //{
            
        //    if(target.GetType().BaseType.BaseType==typeof(BasePage))
        //    {
                
        //        log.Info("Page="+target.GetType().ToString());
                
        //        System.Web.UI.Page myPage=(System.Web.UI.Page)target;

        //        if(myPage.HasControls())
        //        {
        //            foreach(Control c in myPage.Controls)
        //            {
        //                RecordLog(c);
        //            }
        //        }
        //    }
        //    else if(target.GetType()==typeof(HtmlForm))
        //    {
        //        log.Info("Form="+target.GetType().ToString()); 
                
        //        HtmlForm myForm=(HtmlForm)target;

        //        if(myForm.HasControls())
        //        {
        //            foreach(Control c in myForm.Controls)
        //            {
        //                RecordLog(c);
        //            }
        //        }
        //    }
        //    else if(target.GetType().BaseType.BaseType==typeof(BaseUserControl))
        //    {
        //        log.Info("UserControl="+target.GetType().ToString());

        //        System.Web.UI.UserControl myControl=(System.Web.UI.UserControl)target;

        //        if(myControl.HasControls())
        //        {
        //            foreach(Control c in myControl.Controls)
        //            {
        //                RecordLog(c);
        //            }
        //        }
        //    }
        //    else if(target.GetType()==typeof(TextBox)) 
        //    {
        //        log.Info("資料欄位"+((TextBox)target).ID+"="+((TextBox)target).Text);
        //    }
        //    else if(target.GetType()==typeof(Label)) 
        //    {
        //        log.Info("資料欄位"+((Label)target).ID+"="+((Label)target).Text);
        //    }
        //    else if(target.GetType()==typeof(DropDownList)) 
        //    {
        //        log.Info("資料欄位"+((DropDownList)target).ID+"="+((DropDownList)target).SelectedItem.Text+"("+((DropDownList)target).SelectedValue+")");
        //    }
        //    else if(target.GetType()==typeof(CheckBoxList)) 
        //    {
        //        log.Info("資料欄位"+((CheckBoxList)target).ID+"="+((CheckBoxList)target).SelectedItem.Text+"("+((CheckBoxList)target).SelectedValue+")");
        //    }
        //    else if(target.GetType()==typeof(RadioButtonList)) 
        //    {
        //        log.Info("資料欄位"+((RadioButtonList)target).ID+"="+((RadioButtonList)target).SelectedItem.Text+"("+((RadioButtonList)target).SelectedValue+")");
        //    }

        //    //ToDO All Data 包括

        //}
    }
}
