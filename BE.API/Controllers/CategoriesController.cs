using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            //return null;
            return new BE.BS.Categories(_context).GetAll().ToList();
        }
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetCategories(int id)
        {
            var categories = new BE.BS.Categories(_context).GetOneById(id);

            if (categories == null)
            {
                return NotFound();
            }

            return categories;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories(int id, Categories categories)
        {
            if (id != categories.CategoryId)
            {
                return BadRequest();
            }


            try
            {
                new BE.BS.Categories(_context).Update(categories);
            }
            catch (Exception ee)
            {
                if (!CategoriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //private bool CategoriesExists(int id)
        //    {
        //        return ( new BE.BS.Categories(_context).GetOneById(id) != null);
        //    }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Categories>> PostCategories(Categories categories)
        {
            try
            {
                new BE.BS.Categories(_context).Insert(categories);
            }
            catch (Exception)
            {

                BadRequest();
            }
            

            return CreatedAtAction("GetCategories", new { id = categories.CategoryId }, categories);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categories>> DeleteCategories(int id)
        {
            var categories = new BE.BS.Categories(_context).GetOneById(id);
            if (categories == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Categories(_context).Delete(categories);
            }
            catch (Exception)
            {

                BadRequest();
            }

            return categories;
        }

        private bool CategoriesExists(int id)
        {
            return (new BE.BS.Categories(_context).GetOneById(id) != null);
        }
    }
}