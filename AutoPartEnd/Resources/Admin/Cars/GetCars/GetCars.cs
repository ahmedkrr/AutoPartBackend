using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin
{
    [ApiController]
    [Route("api/admin")]
    //[Authorize]
    public class GetCars : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCars(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("GetAllCars")]
        public async Task<object> GetAlCars()
        {
            var Cars = await _dbContext.Set<CarModel>()
                .Include(ct => ct.CarTypes)
                .ThenInclude(ct => ct.ManufactureYears)
                .Select(s => new GetCarResponse
                {
                    Id = s.Id,
                    Name = s.Name,
                    Type=s.CarTypes.Select(s => new GetTypeResponse
                    { 
                        Id = s.Id,
                        Type = s.Name,
                        Year= s.ManufactureYears.Select(s => new GetManufactureResponse 
                        {
                            Id = s.Id,
                            Years = s.Year.Year.ToString()
                        }).ToList()

                    }).ToList()
                })
                .ToListAsync();


            return Cars;
        }

    }
}
