using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;

namespace BE.API.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly NDbContext _context;

        public CategoriesController(NDbContext context)
        {
            _context = context;
        }
        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.DO.Objetos.Categories>>> GetCategories()
        {
            return null;
            //return new BE.BS.Categories(_context).GetAll();
        }
    }
}