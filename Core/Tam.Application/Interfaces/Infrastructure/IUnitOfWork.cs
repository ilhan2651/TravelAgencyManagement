using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Interfaces.Infrastructure
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
