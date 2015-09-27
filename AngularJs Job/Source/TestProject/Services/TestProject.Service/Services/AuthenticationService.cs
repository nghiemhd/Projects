using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Entities;
using TestProject.Core.Infrastructure;
using TestProject.Security;
using TestProject.Service.ServiceContracts;

namespace TestProject.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUnitOfWork unitOfWork;
        private IRepository<User> userRepository;

        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
            user.Password = Encryption.HashPassword(user.Password);
            var newUser = userRepository.Insert(user);
            unitOfWork.Commit();
        }

        private string EncryptPassword(string password)
        {
            string encryptedPassword = Encryption.HashPassword(password);
            return encryptedPassword;
        }
    }
}
