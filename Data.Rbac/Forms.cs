using Data.Rbac.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class Forms : IRestfulEntity
    {
        [Key]
        [HideForEdit]
        [Column("UUID")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; }

        [MaxLength(4000)]
        [DataType("LayoutEditor")]
        public string Value { get; set; }

        [HideForEdit]
        [HideForDisplay]
        public bool IsDelete { get; set; }

        [HideForEdit]
        [DisplayFormat(DataFormatString = Setting.ymdhms)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public virtual ICollection<FormsValues> Data { get; set; } = new HashSet<FormsValues>();
    }
}