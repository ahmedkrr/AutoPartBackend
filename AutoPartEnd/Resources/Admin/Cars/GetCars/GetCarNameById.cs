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
    public class GetCarNameById : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarNameById(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet("GetCarName/{id}")]
        public async Task<object> GetCarNameRequest([FromRoute]int id)
        {

            var carname = await _dbContext.Set<CarModel>().FirstOrDefaultAsync(c => c.Id == id);

            if (carname == null)
                return NoContent();

            return Ok(carname.Name);
        }



    }
}
