using Moo.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Moo.Entities.Interfaces
{
    public interface IAccountService
    {
        HttpCookie Login(LoginViewModel loginData);
        bool Register(RegistrationViewModel registrationData);
        void SendVerificationEmail(string email, string link);
        // bool ActivateAccount(int id);
        HttpCookie Logout();
    }
}
