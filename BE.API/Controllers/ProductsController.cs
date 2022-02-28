using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly NDbContext _context;
        public ProductsController(NDbContext context)
        {
            _context = context;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {           
            var res = await new BE.BS.Products(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = await new BE.BS.Products(_context).GetOneByIdAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.ProductId)
            {
                return BadRequest();
            }           

            try
            {
                 new BE.BS.Products(_context).Update(products);
            }
            catch (Exception ee)
            {
                if (!ProductsExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            try
            {
                new BE.BS.Products(_context).Insert(products);
            }
            catch (Exception ee)
            {

                BadRequest();
            }

            return CreatedAtAction("GetProducts", new { id = products.ProductId }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await new BE.BS.Products(_context).GetOneByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Products(_context).Delete(products);
            }
            catch (Exception)
            {

                BadRequest();
            }

            return products;
        }

        private bool ProductsExists(int id)
        {
            return (new BE.BS.Products(_context).GetOneById(id) != null);
        }
    }
}