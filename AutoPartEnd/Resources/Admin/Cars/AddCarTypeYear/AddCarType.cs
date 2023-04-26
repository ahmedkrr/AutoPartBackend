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

        [HttpPost("addCarType")]

        public async Task<object> AddCarTypeReq([FromBody] AddCartype request)
        {

            var car = _dbContext.Set<CarModel>().FirstOrDefault(c => c.Id == request.Id);

            if (car != null)
            {
                var x = new CarType(request.CarType, car.Id);
                _dbContext.Add(x);
                await _dbContext.SaveChangesAsync();

                _dbContext.Add(new ManufactureYear(request.CarYear, x.Id));
                await _dbContext.SaveChangesAsync();

                return "sucess";
            }

            return "error there is no car model name like you entered ";
        }
    }
}
