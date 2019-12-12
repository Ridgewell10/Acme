
﻿using System;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AcmeEntities;
using AcmeContracts;

namespace AcmeRepository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AcmeContext AcmeContext { get; set; }

        public RepositoryBase(AcmeContext acmeContext)
        {
            this.AcmeContext = acmeContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.AcmeContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.AcmeContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.AcmeContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.AcmeContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.AcmeContext.Set<T>().Remove(entity);
        }
        public void Save()
        {
            this.AcmeContext.SaveChanges();
        }
    }
}
