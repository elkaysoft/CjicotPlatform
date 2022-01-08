using Cjicot.Persistence.Domain;
using Cjicot.Persistence.Repository;
using Cjicot.Presentation.DTO;
using Cjicot.Presentation.IManager;
using Cjicot.Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Presentation.Manager
{
    public class AccountManager : IAccountManager
    {
        private readonly IRepository<UserLogin> _loginRepository;

        public AccountManager(IRepository<UserLogin> loginRepository)
        {
            _loginRepository = loginRepository;
        }
             
        public AccountDto AppLogin(LoginDto login)
        {
            var result = new AccountDto();

            try
            {
                login.Password = helper.EncryptPassword(login.Password);
                var loginObj = _loginRepository.GetFirstOrDefault(x => x.Username == login.Username && 
                x.Password == login.Password);

                if(loginObj != null)
                {
                    result.Id = loginObj.Id;
                    result.Username = loginObj.Username;
                    result.Email = loginObj.Email;
                    result.FailedLoginCount = loginObj.FailedLoginCount;
                    result.MobileNumber = loginObj.MobileNumber;
                    result.IsLocked = loginObj.IsLocked;
                    result.IsActive = loginObj.IsActive;
                    result.FullName = loginObj.FullName;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;
        }

        public int RegisterAuthor(RegistrationDto registration)
        {
            var registerationModel = new UserLogin
            {
                AppUserId = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                IsActive = true,
                Email = registration.Email,
                FailedLoginCount = 0,
                MobileNumber = registration.MobileNumber,
                FullName = registration.FullName,
                IsLocked = false,
                Password = registration.Password,
                Username = registration.Username                               
            };

            return _loginRepository.Insert(registerationModel);
        }

        public bool IsUserExists(string username)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(username))
            {
                var accountObj = _loginRepository.GetFirstOrDefault(x => x.Username.Equals(username));
                if (accountObj != null)
                {
                    result = true;
                }
            }

            return result;
        }

    }
}
