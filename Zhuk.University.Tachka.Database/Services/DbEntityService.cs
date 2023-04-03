using Microsoft.EntityFrameworkCore;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Database.Services
{
    public class DbEntityService<T> : IDbEntityService<T> where T : Dbitem
    {
        private readonly TachkaDbContext _dbcontext;
        private bool _disposed;

        public DbEntityService(TachkaDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        private async Task SaveChanges()
        {
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<T> Create(T entity)
        {
            var EntityFromDb = await _dbcontext.Set<T>().AddAsync(entity);
            await SaveChanges();

            return EntityFromDb.Entity;
        }

        public async Task Delete(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            if(_disposed)
                return;

            _dbcontext.Dispose();
            _disposed = true;
        }

        public IQueryable<T> GetAll()
        {
            return _dbcontext.Set<T>();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbcontext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> Update(T entity)
        {
            var EntityFromDb = _dbcontext.Set<T>().Update(entity);
            await SaveChanges();

            return EntityFromDb.Entity;
        }

        public T GetByIdforUser(long id)
        {
            var result = _dbcontext.Set<T>().FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                //todo: need to add logger
                return null;
            }

            return result;
        }
    }
}
