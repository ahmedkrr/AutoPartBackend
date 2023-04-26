using AutoPartEnd.Domain;
using AutoPartEnd.Model;
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
    [Route("api/item")]
    // [Authorize]
    public class GetItem : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _config;
        public GetItem(ApplicationDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        [HttpGet("{companyid}/GetallItem")]
        public async Task<object> GetItems([FromRoute]int companyid)
        {

            var Items = await _dbContext.Set<Item>()
                .Include(c => c.CarModel)
                .Include(c => c.CarType)
                .Include(c => c.ManufactureYear)
                .Include(c => c.UserProfile)
                .Include(c => c.SubCategory)
                .ThenInclude(c => c.Category)
                .Include(c => c.CompanyProfile)
                .Where(s => s.CompanyProfileId == companyid)
                .Select(c => new GetItemResponsee
                {
                    Id = c.Id,
                    CompanyName = c.CompanyProfile.Name,
                    Name = c.Name,
                    Discription = c.Discription,
                    Price = c.Price,
                    CreatedTime = c.CreatedTime,
                    CarName = c.CarModel.Name,
                    CarType = c.CarType.Name,
                    CarYear = c.ManufactureYear.Year.Year.ToString(),
                    UserName = c.UserProfile.Name,
                    CatName = c.SubCategory.Category.CategoryName,
                    SubCatName = c.SubCategory.SubCategoryName
                })
                .ToListAsync();


            if (Items ==  null || Items.Count == 0)
                return "There is no value or items";

           return Items;
        }
    }
}
