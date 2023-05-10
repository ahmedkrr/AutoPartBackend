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
    public class GetListOfCars : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetListOfCars(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetListOfCars")]
        public async Task<object> GetListOfCarsRequest()
        {
            var cars = await _dbContext.Set<CarModel>().Select(c => new GetCarResponse
            {
                Id = c.Id,
                Name = c.Name,
            }
            ).ToListAsync();
            ;

            if (cars == null)
                return NoContent();
          
            return Ok(cars);
        }

    }
}
