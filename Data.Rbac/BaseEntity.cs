using Data.Rbac.Bindings;
using System;
using System.ComponentModel;

namespace Data.Rbac
{
    public class BaseEntity
    {
        [HideForEdit]
        [HideForDisplay]
        [Description("建立時間")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        [HideForEdit]
        [HideForDisplay]
        [Description("修改時間")]
        public DateTime? ModifyTime { get; set; }
    }
}