﻿using EasyPCIBackend.Data;
using EasyPCIBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyPCIBackend.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext ApplicationDbContext;
        public RepositoryBase(ApplicationDbContext _ApplicationDbContext)
        {
            ApplicationDbContext = _ApplicationDbContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
              ApplicationDbContext.Set<T>().AsNoTracking() :
              ApplicationDbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
              ApplicationDbContext.Set<T>().Where(expression).AsNoTracking() :
              ApplicationDbContext.Set<T>().Where(expression);

        public async Task Create(T entity) => await ApplicationDbContext.Set<T>().AddAsync(entity);

        public void Update(T entity) => ApplicationDbContext.Set<T>().Update(entity);

        public void Delete(T entity) => ApplicationDbContext.Set<T>().Remove(entity);
    }
}
