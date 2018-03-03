using Moo.Data.Context;
using Moo.Data.Generic;
using Moo.Domain.DataInterfaces;
using Moo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(MooDbContext context) : base(context)
        { }

        public Role Get(string name)
        {
            return MooDbContext.Roles
                .Where(r => string.Compare(name, r.RoleName) == 0)
                .SingleOrDefault();
        }

        public MooDbContext MooDbContext
        {
            get { return context as MooDbContext; }
        }
    }
}
