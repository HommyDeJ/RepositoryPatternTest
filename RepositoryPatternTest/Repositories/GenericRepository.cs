using Microsoft.EntityFrameworkCore;
using RepositoryPatternTest.Interfaces;
using RepositoryPatternTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternTest.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DatabaseContext _databaseContext;


        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _databaseContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _databaseContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await _databaseContext.Set<TEntity>().AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            _databaseContext.Set<TEntity>().Update(entity);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _databaseContext.Set<TEntity>().FindAsync(id);

            _databaseContext.Set<TEntity>().Remove(entity);

            await _databaseContext.SaveChangesAsync();
        }
        
    }
}
