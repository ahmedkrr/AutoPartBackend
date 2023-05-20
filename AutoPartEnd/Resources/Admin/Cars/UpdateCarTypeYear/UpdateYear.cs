using AutoPartEnd.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin
{
    [ApiController]
    [Route("api/admin")]
    public class UpdateYear : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateYear(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpPut("UpdateCarYear/{id}")]
        public async Task<object> UpdateCarInfo([FromRoute] int id,[FromBody] DateTime date)
        {

            var Year = await _dbContext.Set<ManufactureYear>().FirstOrDefaultAsync(c => c.Id == id);

            if (Year == null)
                return NoContent();

            Year.update(date);

            await _dbContext.SaveChangesAsync();


            return Ok();


        }
    }
}
