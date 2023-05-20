using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin
{  // here in this api we can add the type for car that dont have any type 

    [ApiController]
    [Route("api/admin")]
    //[Authorize]
    public class AddCarType : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public AddCarType(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost("addCarType/{id}")]

        public async Task<object> AddCarTypeReq([FromBody] AddCartype request ,[FromRoute] int id)
        {

            var car = _dbContext.Set<CarModel>().FirstOrDefault(c => c.Id == id);

            if (car != null)
            {
                var x = new CarType(request.CarType, car.Id);
                _dbContext.Add(x);
                await _dbContext.SaveChangesAsync();

             

                return Ok("Type Added Success");
            }

            return BadRequest();
        }
    }
}
