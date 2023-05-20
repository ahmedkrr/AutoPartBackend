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
    public class panel : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public panel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("GetPanelInfo")]
        public async Task<object> GetPanelInfoRequest()
        {
            var users = await _dbContext.Set<UserProfile>().CountAsync();
            var admin = await _dbContext.Set<UserProfile>().Where(c => c.IsAdmin ==true).CountAsync();

            var companies = await _dbContext.Set<CompanyProfile>().CountAsync();
            var items = await _dbContext.Set<Item>().CountAsync();
            var car = await _dbContext.Set<CarModel>().CountAsync();
            var type = await _dbContext.Set<CarType>().CountAsync();
            var category = await _dbContext.Set<Category>().CountAsync();
            var subCategory = await _dbContext.Set<SubCategory>().CountAsync();





            return Ok(new GetPanelInfoResponse
            { 
                Users = users,
                Companies = companies,
                Items = items,
                Car = car ,
                Type = type,
                Category = category,
                SubCategory = subCategory,
                Admin = admin
            
            }
                );
        }

    }
}
