using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Presentation.DTO
{
    public class AccountDto
    {
        public Int64 Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public int FailedLoginCount { get; set; }

    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }

}
