using Moo.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Data.App_Start
{
    class MooAppDbInitializer : System.Data.Entity.CreateDatabaseIfNotExists<MooDbContext>
    {
        protected override void Seed(MooDbContext context)
        {
           
        }
    }
}
