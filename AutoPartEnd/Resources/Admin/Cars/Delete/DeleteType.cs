using AutoPartEnd.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources
{
    [ApiController]
    [Route("api/admin")]
    public class DeleteType : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteType(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpDelete("deleteType/{id}")]
        public async Task<object> DeleteYearRequest([FromRoute] int id)
        {
            var TypeToDelete = await _dbContext.Set<CarType>()
        .Include(ct => ct.ManufactureYears)
        .FirstOrDefaultAsync(c => c.Id == id);

            if (TypeToDelete != null)
            {
                _dbContext.Remove(TypeToDelete);
                await _dbContext.SaveChangesAsync();
                return Ok("success");
            }
            else
            {
                return NotFound();
            }

        }


    }
}
