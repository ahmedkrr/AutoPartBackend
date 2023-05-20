using AutoPartEnd.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin.Cars.GetCars
{
    [ApiController]
    [Route("api/admin")]
    public class GetCarTypeById : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarTypeById(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet("GetCarType/{id}")]
        public async Task<object> GetCarTypeRequest([FromRoute] int id)
        {

            var carType = await _dbContext.Set<CarType>().FirstOrDefaultAsync(c => c.Id == id);

            if (carType == null)
                return NoContent();

            return Ok(carType.Name);
        }
    }
}
