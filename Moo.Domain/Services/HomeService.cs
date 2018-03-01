using Moo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Domain.Services
{
    public class HomeService : IHomeService
    {
        public string Test()
        {
            return "Test string";
        }
    }
}
