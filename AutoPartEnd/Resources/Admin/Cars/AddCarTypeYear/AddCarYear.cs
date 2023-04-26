using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin
{
    //here we can add the year for any car have name and type and dont have 
    [ApiController]
    [Route("api/admin")]
    //[Authorize]
    public class AddCarYear : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AddCarYear(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }


        [HttpPost("addcaryear")]
        public async Task<object> AddCarYearReq([FromBody] AddCaryear request)
        {

            var car = _dbContext.Set<CarModel>().FirstOrDefault(c => c.Id == request.CarId);
            var type = _dbContext.Set<CarType>().FirstOrDefault(c => c.Id == request.TypeId);

            if (car != null && type != null)
            {
                _dbContext.Add(new ManufactureYear(request.CarYear, request.TypeId));
                await _dbContext.SaveChangesAsync();
                return "sucess";
                
            }

            return "error there is no car model name or type like you entered ";
        }
    }
}
