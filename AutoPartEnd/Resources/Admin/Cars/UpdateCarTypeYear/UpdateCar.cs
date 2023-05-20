using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin.Cars.UpdateCarTypeYear
{
    [ApiController]
    [Route("api/admin")]
    //[Authorize]
    public class UpdateCar : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateCar(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpPut("UpdateCarName/{id}/{name}")]
        public async Task<object> UpdateCarInfo([FromRoute] int id ,string name)
        {

            var Car = await _dbContext.Set<CarModel>().FirstOrDefaultAsync(c => c.Id == id);

            if (Car == null)
                return NoContent();

            Car.update(name);

           await  _dbContext.SaveChangesAsync();


            return Ok();


        }




    }
}
