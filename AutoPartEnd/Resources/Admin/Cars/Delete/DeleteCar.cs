using AutoPartEnd.Domain;
using AutoPartEnd.Model;
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
    public class DeleteCar : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteCar(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpDelete("DeleteCar/{id}")]
        public async Task<object> DeleteCarRequest([FromRoute] int id)
        {
            var carToDelete = await _dbContext.Set<CarModel>()
        .Include(ct => ct.CarTypes)
        .ThenInclude(ct => ct.ManufactureYears)
        .FirstOrDefaultAsync(c => c.Id == id);

            if (carToDelete != null)
            {
                _dbContext.Remove(carToDelete);
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
