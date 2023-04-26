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
        [HttpPost]
        public async Task<object> UpdateCarInfo([FromBody] UpdateCarRequest request)
        {
            var Car = await _dbContext.Set<CarModel>().FirstOrDefaultAsync();
            if (Car == null)
            {
                return "There is no car ";
            }
            Car.update(request.Name);

              await  _dbContext.SaveChangesAsync();

            


            return null;


        }




    }
}
