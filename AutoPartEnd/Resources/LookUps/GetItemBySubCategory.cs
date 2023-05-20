using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.LookUps
{
    [ApiController]
    [Route("api/lookups")]
    public class GetItemBySubCategory : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public GetItemBySubCategory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet("GetItemBySubCategory/{id}")]
         public async Task<object> GetItemBySubCategoryResquest([FromRoute]int id)
        {

            var items = await _dbContext.Set<Item>()
                .Include(c => c.CarModel)
                .Include(c => c.CarType)
                .Include(c => c.ManufactureYear)
                .Include(c => c.UserProfile)
                .Include(c => c.SubCategory)
                .ThenInclude(c => c.Category)
                .Include(c => c.CompanyProfile)
                               .Where(s => ( s.SubCategoryId == id) || (s.SubCategoryId == id && s.IsUniversalItem == true))

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


            return Ok(items) ;

        }



    }
}
