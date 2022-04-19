using System;
using System.Collections.Generic;
using System.Text;

using Asus.Bussiness.Attribute;

namespace AsusLibrary
{
    /// <summary>
    /// 角色列表
    /// </summary>
    public enum EnumRole
    { 
        [EnumDescription("系統管理者")]
        Admin,

        [EnumDescription("管理者")]
        Management,

        [EnumDescription("PM")]
        PM,
        
        [EnumDescription("採購")]
        Sourcer
    }

    /// <summary>
    /// BOM  展開狀態
    /// </summary>
    public enum EnumWorkStatus
    { 
        [EnumDescription("等待展開中")]
        Wait=10,

        [EnumDescription("展開完畢")]
        Complete=20
    }

    /// <summary>
    /// Form 狀態
    /// 這一個參數由Management來控制狀態
    /// </summary>
    public enum EnumFormstatus
    {
        /// <summary>
        /// 已結案
        /// </summary>
        [EnumDescription("已結案")]
        Y,

        /// <summary>
        /// 未結案
        /// </summary>
        [EnumDescription("未結案")]
        N,
    }

    public enum EnumUploadMode
    { 
        PN,

        BOM,

        Main
    }
}
