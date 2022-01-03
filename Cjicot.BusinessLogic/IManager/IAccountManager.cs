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
    }
}
