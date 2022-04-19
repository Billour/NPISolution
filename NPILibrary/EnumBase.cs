using System;
using System.Collections.Generic;
using System.Text;

using Asus.Bussiness.Attribute;

namespace AsusLibrary
{
    /// <summary>
    /// ����C��
    /// </summary>
    public enum EnumRole
    { 
        [EnumDescription("�t�κ޲z��")]
        Admin,

        [EnumDescription("�޲z��")]
        Management,

        [EnumDescription("PM")]
        PM,
        
        [EnumDescription("����")]
        Sourcer
    }

    /// <summary>
    /// BOM  �i�}���A
    /// </summary>
    public enum EnumWorkStatus
    { 
        [EnumDescription("���ݮi�}��")]
        Wait=10,

        [EnumDescription("�i�}����")]
        Complete=20
    }

    /// <summary>
    /// Form ���A
    /// �o�@�ӰѼƥ�Management�ӱ���A
    /// </summary>
    public enum EnumFormstatus
    {
        /// <summary>
        /// �w����
        /// </summary>
        [EnumDescription("�w����")]
        Y,

        /// <summary>
        /// ������
        /// </summary>
        [EnumDescription("������")]
        N,
    }

    public enum EnumUploadMode
    { 
        PN,

        BOM,

        Main
    }
}
