using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        public string Username { get; set; } 
        public string Password { get; set; }
    }
}
