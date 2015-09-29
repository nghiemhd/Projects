using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Entities;
using TestProject.Core.Infrastructure;
using TestProject.Logging;
using TestProject.Security;
using TestProject.Service.ServiceContracts;

namespace TestProject.Service
{
    public class AuthenticationService : HandleErrorService, IAuthenticationService
    {
        private IUnitOfWork unitOfWork;
        private IRepository<User> userRepository;
        private ILogger logger;

        public AuthenticationService(IUnitOfWork unitOfWork, ILogger logger)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            userRepository = unitOfWork.GetRepository<User>();
        }

        public User GetUserByUsername(string username)
        {
            var user = userRepository.Query().Where(x => x.Username == username).FirstOrDefault();
            return user;
        }

        public bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            var user = GetUserByUsername(username);
            if (user != null)
            {
                isValid = Encryption.ValidatePassword(password, user.Password);
            }
            return isValid;
        }

        public void RegisterUser(User user)
        {
            Process(() =>
            {
                user.Password = Encryption.HashPassword(user.Password);
                var newUser = userRepository.Insert(user);
                unitOfWork.Commit();
            });            
        }

        private string EncryptPassword(string password)
        {
            string encryptedPassword = Encryption.HashPassword(password);
            return encryptedPassword;
        }
    }
}
