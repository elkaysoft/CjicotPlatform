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
        private readonly IRepository<LoginHistory> _historyRepository;
        private readonly IRepository<Profile> _profileRepository;

        public AccountManager(IRepository<UserLogin> loginRepository, IRepository<LoginHistory> historyRepository, IRepository<Profile> profileRepository)
        {
            _loginRepository = loginRepository;
            _historyRepository = historyRepository;
            _profileRepository = profileRepository;
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
                    result.IsLocked = loginObj.IsLocked;
                    result.IsActive = loginObj.IsActive;
                    result.AppUserId = loginObj.ProfileId;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;
        }

        public int CreateProfile(RegistrationDto registration)
        {
            var profileId = Guid.NewGuid();
            int accountCreated = 0;

            var profileObj = new Profile
            {
                Country = registration.Country,
                CreatedOn = DateTime.Now,
                Email = registration.Email,
                FullName = registration.FullName,
                IsDeleted = false,
                Gender = registration.Gender,
                MobileNumber = registration.MobileNumber,
                ProfileId = profileId,
                Province = registration.Province                
            };

            accountCreated =  _profileRepository.Insert(profileObj);   
            if(accountCreated > 0)
            {
                AddLoginDetail(registration.Username, registration.Password, profileId);
            }

            return accountCreated;
        }

        private void AddLoginDetail(string username, string password, Guid profileId)
        {
            var loginObj = new UserLogin
            {
                ProfileId = profileId,
                DateCreated = DateTime.Now,
                IsActive = true,
                IsLocked = false,
                Password = helper.EncryptPassword(password),
                Username = username
            };

            _loginRepository.Insert(loginObj);
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

        public bool IsProfileIdValid(Guid profileId)
        {
            bool result = false;

            var profileObj = _profileRepository.GetFirstOrDefault(x => x.ProfileId.Equals(profileId));
            if (profileObj != null)
            {
                result = true;
            }

            return result;
        }

        public void SetLoginHistory(string username, string message, bool status, string ipAddress)
        {
            var loginObj = new LoginHistory
            {
                Username = username,
                Message = message,
                IsSuccessful = status,
                IpAddress = ipAddress,
                InitiatedOn = DateTime.Now
            };

            _historyRepository.Insert(loginObj);
        }

        private void InitProfileLockout(string username)
        {
            var resp = _historyRepository.GetFirstOrDefault(x => x.Username == username);
            if(resp != null)
            {

            }
        }

        public void SetFailedLoginCount(string username)
        {
            //var regObj = _loginRepository.GetFirstOrDefault(x => x.Username == username);
            //if (regObj != null)
            //{
            //    regObj.FailedLoginCount += 1;
            //    _loginRepository.Update(regObj);
            //}
        }

    }
}
