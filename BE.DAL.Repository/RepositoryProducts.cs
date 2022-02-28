using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL.Repository
{
    public class RepositoryProducts : Repository<data.Products>, IRepositoryProducts
    {
        public RepositoryProducts(NDbContext _dbContext) : base(_dbContext)
        {
            
        }
        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _db.Products.Include(n => n.Category).ToListAsync();
        }

        public async  Task<Products> GetOneByIdAsync(int id)
        {
            return await _db.Products.Include(n => n.Category).SingleOrDefaultAsync(n => n.ProductId == id);
        }
        private NDbContext _db
        {
            get
            {
                return dbContext as NDbContext;
            }
        }
    }
}
