using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Domain.DataInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository Games { get; }

        int Complete();
    }
}
