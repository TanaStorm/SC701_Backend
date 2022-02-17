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
    public class Categories : ICRUD<data.Categories>
    {
        private dal.Categories _dal;
        public Categories(NDbContext dbContext)
        {
            _dal = new dal.Categories(dbContext);
        }

        public void Delete(data.Categories t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Categories> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Categories>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Categories GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Categories> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Categories t)
        {
            throw new NotImplementedException();
        }

        public void Update(data.Categories t)
        {
            throw new NotImplementedException();
        }
    }
}
