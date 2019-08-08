using Data.Rbac.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public partial class Picklists : BaseEntity, IHierarchyEntity<Picklists>
    {
        [Key]
        [HideForEdit]
        [HideForDisplay]
        [Column("UUID")]
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int Sequence { get; set; }
        public Guid? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Picklists Parent { get; set; }
        public ICollection<Picklists> Children { get; set; }

        public string GetTitle() => Title;
        public string GetTypeName() => "picklist";
        public Picklists Clone() => new Picklists
        {
            Id = Guid.NewGuid(),
            Title = Title,
            Value = Value,
            Sequence = Sequence,
        };
        public void SetTitle(string v)
        {
            this.Title = v;
        }
    }
}
