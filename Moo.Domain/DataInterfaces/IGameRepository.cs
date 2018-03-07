using Moo.Entities.Models;

namespace Moo.Domain.DataInterfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        int GetNumberOfWonGamesByUser(int userID);
        Game Get(int gameId, params string[] includes);
    }
}
