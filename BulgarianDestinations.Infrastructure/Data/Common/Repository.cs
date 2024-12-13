using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(ApplicationDbContext _context)
        {
            context = _context;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return context.Set<T>();
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<T?> GetById<T>(int id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdCollection<T>(int id, int id1) where T : class
        {
            return await DbSet<T>().FindAsync(id, id1);
        }

        public async Task DeleteAsync<T>(int id) where T : class
        {
            T? entity = await GetById<T>(id);

            if(entity != null) 
            {
                DbSet<T>().Remove(entity);
            }
        }
        public async Task DeleteCollectionAsync<T>(int id, int id1) where T : class
        {
            T? entity = await GetByIdCollection<T>(id, id1);

            if (entity != null)
            {
                DbSet<T>().Remove(entity);
            }
        }

        public async Task DeleteObjectAsync<T>(T entity) where T : class
        {            
           DbSet<T>().RemoveRange(entity);
        }

        public async Task DeleteSingleObjectAsync<T>(T entity) where T : class
        {
            DbSet<T>().Remove(entity);
        }

        public async Task<T?> GetByIdString<T>(string id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }
    }
}
