//using AutoPartEnd.Domain;
//using AutoPartEnd.Model;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace AutoPartEnd.Resources
//{
//    [ApiController]
//    [Route("api/Cars")]
//    public class GetCarModels : ControllerBase
//    {
//        private readonly ApplicationDbContext _dbContext;

//        public GetCarModels(ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;

//        }


//        [HttpGet("GetModelTypeCar")]
//        public async Task<object> GettAllCar()
//        {
//            var seq = await _dbContext.Set<CarModel>()
//                .Include(c => c.CarTypes)
//                .ThenInclude(c => c.ManufactureYears)
//                .Select(s => new GetData
//                {
//                    Carid = s.Id ,
//                    CarName = s.Name,
                  
                


//                })
//                .ToListAsync();

//        }

//    }
//}
