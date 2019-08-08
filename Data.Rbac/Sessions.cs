using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class Sessions : BaseEntity
    {
        [Key]
        [Column("UUID")]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime ExpireTime { get; set; }

        [ForeignKey("UserId")]
        public Users User { get; set; }

        public ICollection<SessionsRoles> SessionsRoles { get; set; }
    }
}
