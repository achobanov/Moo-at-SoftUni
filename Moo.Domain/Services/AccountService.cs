using Moo.Domain.Auth;
using Moo.Domain.DataInterfaces;
using Moo.Entities.Interfaces;
using Moo.Entities.Models;
using Moo.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Moo.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly JavaScriptSerializer JsonConvert = new JavaScriptSerializer();
        private readonly RNGCryptoServiceProvider Random = new RNGCryptoServiceProvider();
        private readonly IUnitOfWork Unit;

        public AccountService(IUnitOfWork unit)
        {
            this.Unit = unit;
        }

        public HttpCookie Login(LoginViewModel loginData)
        {
            if (Membership.ValidateUser(loginData.Username, loginData.Password))
            {
                var user = (CustomMembershipUser) Membership.GetUser(loginData.Username, false);
                if (user != null)
                {
                    CustomSerializeModel userModel = new CustomSerializeModel()
                    {
                        UserId = user.UserId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        RoleNames = user.Roles.Select(r => r.RoleName)
                    };

                    string userData = JsonConvert.Serialize(userModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                    (
                        1, loginData.Username, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                    );

                    string enTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
                    return faCookie;
                }
            }
            return null;
        }

        public bool Register(RegistrationViewModel registrationData)
        {
            string username = Membership.GetUserNameByEmail(registrationData.Email);
            if (!string.IsNullOrEmpty(username))
            {
                return false; //TODO: Proper feedback here plex
            }

            Unit.Users.Add(new User()
            {
                Username = registrationData.Username,
                Password = registrationData.Password,
                Roles = GetUserRoles()
            });
            Unit.Complete();

            return true;
        }

        private List<Role> GetUserRoles()
        {
            var role = Unit.Roles.Get("User");
            if (role == null)
            {
                role = new Role { RoleName = "User" };
                Unit.Roles.Add(role);
                Unit.Complete();
            }
            return new List<Role> { role };
        }

        public void SendVerificationEmail(string email, string link)
        {
            // Put in AccountController
            //var url = string.Format("/Account/ActivationAccount/{0}", registrationData.ActivationCode.ToString());
            //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);
            //service.SendVerificationEmail(registrationData.Email, link);

            var fromEmail = new MailAddress("mehdi.rami2012@gmail.com", "Activation Account - AKKA");
            var toEmail = new MailAddress(email);

            var fromEmailPassword = "******************";
            string subject = "Activation Account !";

            string body = "<br/> Please click on the following link in order to activate your account" + "<br/><a href='" + link + "'> Activation Account ! </a>";

            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            })
            {
                using (var message = new MailMessage(fromEmail, toEmail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                smtp.Send(message);
            }
        }

        //public bool ActivateAccount(int id)
        //{
        //    var userAccount = unit.Users.Get(id);
        //    if (userAccount != null)
        //    {
        //        userAccount.IsActive = true;
        //        unit.Complete();
        //        return true;
        //    }

        //    return false;
        //}

        public HttpCookie Logout()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            FormsAuthentication.SignOut();
            return cookie;
        }
    }
}
