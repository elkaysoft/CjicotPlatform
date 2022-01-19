using Cjicot.Presentation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Presentation.IManager
{
    public interface IAccountManager
    {
        AccountDto AppLogin(LoginDto login);
        bool IsUserExists(string username);
        int CreateProfile(RegistrationDto registration);
        void SetLoginHistory(string username, string message, bool status, string ipAddress);
        bool IsProfileIdValid(Guid profileId);
    }
}
