using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T FindByCondition(Expression<Func<T,bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

     
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
