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
    public class CarSearch : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CarSearch(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("ss")]
        public async Task<object> ss([FromHeader] int car, [FromHeader] int type, [FromHeader] int year)
        {
            var Result = new List<GetItemResponsee>();
            if (car != 0 && type != 0 && year != 0)
            {
                Result = await _dbContext.Set<Item>()
                .Include(c => c.CarModel)
                .Include(c => c.CarType)
                .Include(c => c.ManufactureYear)
                .Include(c => c.UserProfile)
                .Include(c => c.SubCategory)
                .ThenInclude(c => c.Category)
                .Include(c => c.CompanyProfile)
                .Where(s => s.CarModelId == car && s.CarTypeId == type && s.ManufactureYearId == year)
                .Select(c => new GetItemResponsee
                {
                    Id = c.Id,
                    CompanyName = c.CompanyProfile.Name,
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
            }
            if (car != 0 && type == 0 && year == 0)
            {
                Result = await _dbContext.Set<Item>()
                .Include(c => c.CarModel)
                .Include(c => c.CarType)
                .Include(c => c.ManufactureYear)
                .Include(c => c.UserProfile)
                .Include(c => c.SubCategory)
                .ThenInclude(c => c.Category)
                .Include(c => c.CompanyProfile)
                .Where(s => s.CarModelId == car && s.CarTypeId == type)
                .Select(c => new GetItemResponsee
                {
                    Id = c.Id,
                    CompanyName = c.CompanyProfile.Name,
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
            }
            if (car != 0 && type == 0 && year == 0)
            {
                Result = await _dbContext.Set<Item>()
                .Include(c => c.CarModel)
                .Include(c => c.CarType)
                .Include(c => c.ManufactureYear)
                .Include(c => c.UserProfile)
                .Include(c => c.SubCategory)
                .ThenInclude(c => c.Category)
                .Include(c => c.CompanyProfile)
                .Where(s => s.CarModelId == car)
                .Select(c => new GetItemResponsee
                {
                    Id = c.Id,
                    CompanyName = c.CompanyProfile.Name,
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
            }

            return Result;
        }
    }
}
