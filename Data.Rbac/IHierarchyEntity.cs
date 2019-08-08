using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public interface IHierarchyEntity<T>
    {
        Guid Id { get; set; }
        int Sequence { get; set; }
        Guid? ParentId { get; set; }
        DateTime? ModifyTime { get; set; }

        T Parent { get; set; }
        ICollection<T> Children { get; set; }

        string GetTitle();
        void SetTitle(string v);
        string GetTypeName();
        T Clone();
    }
}