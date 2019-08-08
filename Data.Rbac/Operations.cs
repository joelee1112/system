using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    [Description("Operation")]
    public class Operations : BaseEntity
    {
        [Key]
        [Column("UUID")]
        [Description("系統編號")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Description("名稱")]
        public string Name { get; set; }
        [Description("頁面編號")]
        public Guid? PageId { get; set; }
        [Description("排序值")]
        public int Sequence { get; set; }

        [ForeignKey("PageId")]
        public Pages Page { get; set; }

        public ICollection<Apis> Apis { get; set; } = new HashSet<Apis>();
        public ICollection<RolesOperations> RolesOperations { get; set; } = new HashSet<RolesOperations>();

        public Operations Clone()
        {
            return new Operations
            {
                Name = this.Name,
                Sequence = this.Sequence
            };
        }
    }
}
