﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Bulky.DataAccess.Data.Repository.IRepository;
using Bulky.DataAcess.Data;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        // Constructor
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        // Add an entity
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        // Get a single entity by filter
        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            return query.FirstOrDefault(filter);  // Directly apply the filter in the method call
        }

        // Get all entities (without any filter)
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        // Remove a single entity
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        // Remove multiple entities
        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}