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
    public class GetCarTypeList : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarTypeList(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetCarTypeList/{Id}")]
        public async Task<object> GetCarTypeListRequest([FromRoute] int Id)
        {

            var types = await _dbContext.Set<CarType>()
                .Where(c => c.ModelId == Id)
                .Select(c => new GetTypeResponse 
                  { 
                    Id = c.Id,
                    Type = c.Name,
                    CarID = c.ModelId
                    
                    
                   })
                .ToListAsync();

            if (types == null)
                return NoContent();


            return Ok(types);
        }
    }
}
