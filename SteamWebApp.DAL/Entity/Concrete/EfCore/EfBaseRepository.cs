using SteamWebApp.DAL.Entity.Abstraction;
using SteamWebApp.DAL.Entity.Concrete.EfCore.Context;
using SteamWebApp.Entities.Entity.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SteamWebApp.DAL.Entity.Concrete.EfCore
{
    public class EfBaseRepository<T>:IRepository<T>
        where T :class, ICore, new()
    {
        private ProjectContext _context;
        public EfBaseRepository(ProjectContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Any(exp);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().FirstOrDefault(exp);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public void Update(T entity)
        {
            var update = _context.Entry(entity);
            update.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
