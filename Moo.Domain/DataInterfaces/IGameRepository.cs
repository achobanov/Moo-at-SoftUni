using Moo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Domain.DataInterfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        int GetNumberOfWonGamesByUser(int userID);
    }
}
