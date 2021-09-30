using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Company_API_.Data;
using Company_API_.Models;

namespace Company_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public CompanyModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CompanyModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyModel>>> GetAll()
        {
            return await _context.CompanyModel.ToListAsync();
        }

        // GET: api/CompanyModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyModel>> GetById(int id)
        {
            var companyModel = await _context.CompanyModel.FindAsync(id);

            if (companyModel == null)
            {
                return NotFound();
            }

            return companyModel;
        }

        // PUT: api/CompanyModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CompanyModel companyModel)
        {
            if (id != companyModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyModelExists(id))
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

        // POST: api/CompanyModels
        [HttpPost]
        public async Task<ActionResult<CompanyModel>> Add(CompanyModel companyModel)
        {
            _context.CompanyModel.Add(companyModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyModel", new { id = companyModel.Id }, companyModel);
        }

        // DELETE: api/CompanyModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var companyModel = await _context.CompanyModel.FindAsync(id);
            if (companyModel == null)
            {
                return NotFound();
            }

            _context.CompanyModel.Remove(companyModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyModelExists(int id)
        {
            return _context.CompanyModel.Any(e => e.Id == id);
        }
    }
}
