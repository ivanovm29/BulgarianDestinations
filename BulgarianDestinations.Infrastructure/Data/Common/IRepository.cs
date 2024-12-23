﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();

        Task<T?> GetById<T>(int id) where T : class;

        Task<T?> GetByIdCollection<T>(int id, int id1) where T : class;

        Task DeleteAsync<T>(int id) where T : class;

        Task DeleteObjectAsync<T>(T entity) where T : class;

        Task DeleteSingleObjectAsync<T>(T entity) where T : class;

        Task DeleteCollectionAsync<T>(int id, int id1) where T : class;

        Task<T?> GetByIdString<T>(string id) where T : class;
    }
}
