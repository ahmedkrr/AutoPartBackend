using AutoPartEnd.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources
{
    [ApiController]
    [Route("api/lookups")]
    public class GetCategory : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public GetCategory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("GetCategory")]
        public async Task<object> GetCategoryReq()
        {
            var category =   await _dbContext.Set<Category>().ToListAsync();





            return category;

        }
    }
}
