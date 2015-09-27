using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Core.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContext DbContext { get; }
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Commit();
    }
}
