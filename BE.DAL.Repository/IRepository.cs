using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BE.DAL.Repository
{
    public interface IRepository <T> where T:class //generics
    {
        IQueryable<T> AsQueryble(); //Es como un GetAll pero dinamico
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(Expression<Func<T, bool>> predicado);
        T GetOne(Expression<Func<T, bool>> predicado);
        T GetOnebyID(int id);
        void Insert(T t); //Paseme cualquier clase que ud quiera y yo le hago el proceso, le proceso lainfo de forma dinamica
        void Update(T t);
        void Delete(T t);
        void Commit();
        void AddRange(IEnumerable<T> t);
        void UpdateRange(IEnumerable<T> t);
        void RemoveRange(IEnumerable<T> t);
    }
}
