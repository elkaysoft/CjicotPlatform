using System;
using System.ComponentModel.DataAnnotations;

namespace Cjicot.Persistence.Domain
{
    public class UserRole
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public UserLogin UserLogin { get; set; }
    }
}
