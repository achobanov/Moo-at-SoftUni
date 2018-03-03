using Moo.Domain.DataInterfaces;
using Moo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Domain.Services
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork unit;

        public HomeService(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public string Test()
        {
            return unit.Games.GetUserWonGames().ToString();
        }
    }
}
