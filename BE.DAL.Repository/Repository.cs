using BE.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BE.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly NDbContext dbContext;
        public Repository(NDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void AddRange(IEnumerable<T> t)
        {
            dbContext.Set<T>().AddRange(t);
        }

        public IQueryable<T> AsQueryble()
        {

            return dbContext.Set<T>().AsQueryable();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(T t)
        {
            try
            {
                dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetOne(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado).FirstOrDefault();
        }

        public T GetOnebyID(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            try
            {
                if(dbContext.Entry<T>(t).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                {
                    dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                else
                {
                    dbContext.Set<T>().Add(t);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<T> t)
        {
            dbContext.Set<T>().RemoveRange(t);
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado);
        }

        public void Update(T t)
        {
            try
            {
                if (dbContext.Entry<T>(t).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                {
                    dbContext.Set<T>().Attach(t);
                }
                dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateRange(IEnumerable<T> t)
        {
            dbContext.Set<T>().UpdateRange(t);
        }
    }
}
