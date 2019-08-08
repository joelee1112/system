using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    [Description("Api")]
    public class Apis : BaseEntity
    {
        [Key]
        [Column("UUID")]
        [Description("系統編號")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Description("名稱")]
        public string Name { get; set; }
        [Description("頁面編號")]
        public Guid? PageId { get; set; }
        [Description("操作編號")]
        public Guid? OperationId { get; set; }
        [Description("Url")]
        public string Url { get; set; }
        [Description("排序值")]
        public int Sequence { get; set; }

        [ForeignKey("PageId")]
        public Pages Page { get; set; }
        [ForeignKey("OperationId")]
        public Operations Operation { get; set; }

        public ICollection<RolesApis> RolesApis { get; set; } = new HashSet<RolesApis>();

        public Apis Clone()
        {
            return new Apis
            {
                Name = this.Name,
                Url = this.Url,
                Sequence = this.Sequence
            };
        }
    }
}
