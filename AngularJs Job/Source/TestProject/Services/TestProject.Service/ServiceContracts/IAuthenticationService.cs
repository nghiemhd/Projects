using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Entities;

namespace TestProject.Service.ServiceContracts
{
    public interface IAuthenticationService
    {
        User GetUserByUsername(string username);

        bool ValidateUser(string username, string password);

        void RegisterUser(User user);
    }
}
