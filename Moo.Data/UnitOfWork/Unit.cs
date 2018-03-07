using Moo.Data.Context;
using Moo.Data.Repositories;
using Moo.Domain.DataInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Data.UnitOfWork
{
    public class Unit : IUnitOfWork
    {
        private readonly MooDbContext context;

        public IGameRepository Games { get; private set; }
        public IUserRepository Users { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public ITurnRepository Turns { get; private set; }

        public Unit(MooDbContext context)
        {
            this.context = context;
            Games = new GameRepository(this.context);
            Users = new UserRepository(this.context);
            Roles = new RoleRepository(this.context);
            Turns = new TurnRepository(this.context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
