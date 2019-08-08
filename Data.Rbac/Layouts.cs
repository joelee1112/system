using Data.Rbac.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Rbac
{
    public class Layouts
    {
        [Key]
        [HideForEdit]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; }

        [MaxLength(4000)]
        [DataType("TemplateEditor")]
        public string Value { get; set; }

        [HideForEdit]
        [HideForDisplay]
        public bool IsDelete { get; set; }

        [HideForEdit]
        [DisplayFormat(DataFormatString = Setting.ymdhms)]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
