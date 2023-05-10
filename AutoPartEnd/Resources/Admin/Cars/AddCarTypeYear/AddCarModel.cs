using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin
{
    [ApiController]
    [Route("api/admin")]
    //[Authorize]
    public class AddCarModel : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AddCarModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpPost("addCar")]
        public async Task<object> AddCarReq([FromBody] AddCarModelName request)
        {
            // Here we can add in this api (Car Name & Car Type & Car Year) once or we can create every one once time
            try
            {
                var x = new CarModel(request.CarName);
                if (request.CarName != null)
                {
                    _dbContext.Add(x);
                    await _dbContext.SaveChangesAsync();


                    var x2 = new CarType(request.CarType, x.Id);
                    if (request.CarType != null)
                    {
                        _dbContext.Add(x2);
                        await _dbContext.SaveChangesAsync();
                    }


                    var x3 = new ManufactureYear(request.CarYear, x2.Id);
                    if (request.CarYear != DateTime.MinValue)
                    {
                        _dbContext.Add(x3);
                        await _dbContext.SaveChangesAsync();
                    }



                    return Ok("Success");
                }

            }
            catch (Exception e)
            {

                return($"The Eror is {e.InnerException}");
            }

            return "the car name null";
        }

        
        

       
    }
}