using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Database.Interfaces
{
    public interface IDbEntityService<T> : IDisposable where T:Dbitem
    {
        Task<T?> GetById(int id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(T entity);

        IQueryable<T> GetAll();
    }
}
