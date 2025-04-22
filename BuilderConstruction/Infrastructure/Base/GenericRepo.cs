using BuilderConstruction.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuilderConstruction.Infrastructure.Base
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly InvContext _context;
        private DbSet<T> _dbset;


        public GenericRepo(InvContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();

        }
        public virtual async Task Add(T entity)
        {
            await _dbset.AddAsync(entity);
        }
        public async void Add(List<T> entity)
        {
            await _dbset.AddRangeAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void DeletebyID(Expression<Func<T, bool>> predicate)
        {
            var entity = _dbset.Where(predicate).FirstOrDefault();
            if (entity != null)
            {
                _dbset.Remove(entity);
            }
        }
        public void DeleteRange(IEnumerable<T> entitylist)
        {
            _dbset.RemoveRange(entitylist);
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbset.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate,
            string? includeProperties)
        {
            IQueryable<T> query = _dbset;
            try
            {
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }
                if (includeProperties != null)
                {
                    foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(item);
                    }
                }
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _dbset.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            //_context.Entry(entity).State = EntityState.Detached;
        }
    }
}
