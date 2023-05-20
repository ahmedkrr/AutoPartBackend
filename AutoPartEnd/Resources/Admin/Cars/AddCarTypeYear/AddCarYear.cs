using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin
{
    [ApiController]
    [Route("api/admin")]
    public class AddCarYear : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AddCarYear(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost("addcaryear/{id}")]
        public async Task<object> AddCarYearReq([FromBody] AddCaryear request ,[FromRoute] int id)
        {
            var type = _dbContext.Set<CarType>().FirstOrDefault(c => c.Id == id);

            if (type != null)
            {
                _dbContext.Add(new ManufactureYear(request.CarYear, id));
                await _dbContext.SaveChangesAsync();
                return Ok();
                
            }

            return BadRequest();
        }
    }
}
