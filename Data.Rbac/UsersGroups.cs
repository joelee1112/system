using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    public class UsersGroups
    {
        [Key]
        public Guid GroupId { get; set; }
        [Key]
        public Guid UserId { get; set; }

        [ForeignKey("GroupId")]
        public Groups Group { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
    }
}