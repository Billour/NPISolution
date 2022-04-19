using System;
using System.Collections.Generic;
using System.Text;

using Asus;
using Asus.Bussiness.Attribute;
using Asus.Bussiness.Map;
using System.Web.UI.WebControls;
using AsusLibrary.Logic;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// �w�p����
    /// </summary>
    public class BaseCompnentEntity:BaseEntity
    {
        private string _No = "02G050001120";
        private string _Name = "C.S RS780(A13) FCBGA528";
        private string _Spec = "AMD 215-0674028";

        /// <summary>
        /// ����Ƹ�
        /// </summary>
        [QueryColumn("", "����Ƹ�", "Y", ViewRowType.BoundField, "N", 10)]
        public string No
        {
            set { _No = value; }
            get { return _No; }
        }

        /// <summary>
        ///  
        /// </summary>
        [QueryColumn("", "�~�W", "Y", ViewRowType.BoundField, "N", 20)]
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        [QueryColumn("", "�W��", "Y", ViewRowType.BoundField, "N", 30)]
        public string Spec
        {
            set { _Spec = value; }
            get { return _Spec; }
        }
    }
}
