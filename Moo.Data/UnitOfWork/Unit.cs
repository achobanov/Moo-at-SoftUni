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

        public Unit(MooDbContext context)
        {
            this.context = context;
            Games = new GameRepository(this.context);
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
