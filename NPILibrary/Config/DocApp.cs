using System;
using System.Collections.Generic;
using System.Text;
using Asus.Analysis.Attribute;

namespace AsusLibrary.Config
{
    /// <summary>
    /// Doc �]�w�Ѽ�
    /// </summary>
    public class DocApp
    {
        /// <summary>
        /// ����1 ���O��V1.0
        /// </summary>
        public const string Version1 = "V1.0";


        /// <summary>
        /// ���]�w������󤺮e�ϥ�-�Ӧ۫Ȥ᪺�n�D
        /// Request by User 
        /// </summary>
        [RefVersion(DocApp.Version1)]
        public const string Ref_Request = "�Ӧ۫Ȥ᪺�n�D";
    }
}
