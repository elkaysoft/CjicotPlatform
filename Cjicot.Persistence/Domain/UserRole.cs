using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
