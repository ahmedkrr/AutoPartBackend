using AutoPartEnd.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin.Cars.Delete
{
    [ApiController]
    [Route("api/admin")]
    public class DeleteYear : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteYear(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpDelete("deleteyear/{id}")]
        public async Task<object> DeleteYearRequest([FromRoute] int id)
        {
            var YearToDelete = await _dbContext.Set<ManufactureYear>()
        .FirstOrDefaultAsync(c => c.Id == id);

            if (YearToDelete != null)
            {
                _dbContext.Remove(YearToDelete);
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
