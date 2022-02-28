using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objetos;
using dal = BE.DAL;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;
using BE.DAL.EF;

namespace BE.BS
{
    public class Products : ICRUD<data.Products>
    {
        private dal.Products _dal;
        public Products(NDbContext dbContext)
        {
            _dal = new dal.Products(dbContext);
        }
        public void Delete(data.Products t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Products> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Products>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Products GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Products> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Products t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Products t)
        {
            _dal.Update(t);
        }
    }
}
