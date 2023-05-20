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
    public class GetCarYearByID : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarYearByID(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet("GetCarYear/{id}")]
        public async Task<object> GetCarTypeRequest([FromRoute] int id)
        {

            var carYear = await _dbContext.Set<ManufactureYear>().FirstOrDefaultAsync(c => c.Id == id);

            if (carYear == null)
                return NoContent();

            return Ok(carYear.Year.Year);
        }
    }
}
