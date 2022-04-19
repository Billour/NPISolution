using System;
using System.Collections.Generic;
using System.Text;
using Asus.Analysis.Attribute;

namespace AsusLibrary.Config
{
    /// <summary>
    /// Doc 設定參數
    /// </summary>
    public class DocApp
    {
        /// <summary>
        /// 版本1 分別至V1.0
        /// </summary>
        public const string Version1 = "V1.0";


        /// <summary>
        /// 給設定版本文件內容使用-來自客戶的要求
        /// Request by User 
        /// </summary>
        [RefVersion(DocApp.Version1)]
        public const string Ref_Request = "來自客戶的要求";
    }
}
