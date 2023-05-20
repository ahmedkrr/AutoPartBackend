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
    [Route("api/lookups")]
    public class GetItemByCar : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetItemByCar(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet("GetItemByCar/{carId}/{typeId}/{yearId}/{subcategoryId}")]
        public async Task<object> GetItemByCarResquest([FromRoute] int carId, int typeId, int yearId ,int subcategoryId)
        {

            var items = await _dbContext.Set<Item>()
                .Include(c => c.CarModel)
                .Include(c => c.CarType)
                .Include(c => c.ManufactureYear)
                .Include(c => c.UserProfile)
                .Include(c => c.SubCategory )
                .ThenInclude(c => c.Category)
                .Include(c => c.CompanyProfile)
                .Where(s => (s.CarModelId == carId && s.CarTypeId == typeId && s.ManufactureYearId == yearId && s.SubCategoryId == subcategoryId)|| (s.SubCategoryId == subcategoryId && s.IsUniversalItem == true))
                .Select(c => new GetItemResponsee
                {
                    Id = c.Id,
                    CompanyName = c.CompanyProfile.Name,
                    CompanyId = c.CompanyProfileId,
                    Name = c.Name,
                    Discription = c.Discription,
                    Price = c.Price,
                    CreatedTime = $"{c.CreatedTime.Day}/{c.CreatedTime.Month}/{c.CreatedTime.Year}",
                    CarName = c.CarModel.Name,
                    CarType = c.CarType.Name,
                    CarYear = c.ManufactureYear.Year.Year.ToString(),
                    UserName = c.UserProfile.Name,
                    CatName = c.SubCategory.Category.CategoryName,
                    SubCatName = c.SubCategory.SubCategoryName,
                    ImageData = c.ImageData,

                })
                .ToListAsync();

            if (items == null)
                return NoContent();


            return Ok(items);

        }

    }
}
