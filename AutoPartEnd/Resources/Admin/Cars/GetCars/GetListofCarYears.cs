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
    public class GetListofCarYears : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetListofCarYears(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("GetListofCarYears/{typeId}")]
        public async Task<object> GetListOfCarYearsRequest([FromRoute]int typeId)
        {
            var years = await _dbContext.Set<ManufactureYear>()
                .Where(c => c.TypeId == typeId)
                .Select(c => new GetManufactureResponse
                {
                    Id = c.Id,
                    Years = c.Year.Year.ToString(),
                    TypeId = c.TypeId
                }).ToListAsync();


            if (years == null)
                return NoContent();

            return Ok(years);
        }
    }
}