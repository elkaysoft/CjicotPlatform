using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Persistence.Domain
{
    public class LoginHistory
    {
        [Key]
        public Int64 Id { get; set; }
        public string Username { get; set; }
        public string IpAddress { get; set; }        
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public DateTime InitiatedOn { get; set; }

    }
}
