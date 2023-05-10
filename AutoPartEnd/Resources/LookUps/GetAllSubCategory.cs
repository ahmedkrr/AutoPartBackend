using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources
{
    [ApiController]
    [Route("api/lookups")]
    public class GetAllSubCategory : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GetAllSubCategory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllSubCategory")]
        
        public async Task<object> GetSubCategoryReq()
        {
            var category = _dbContext.Set<SubCategory>()
                .Select(s => new SubCategoriesResponse
                {
                    SubCategoryId = s.Id,
                    CategoryName = s.Category.CategoryName,
                    SubCategoryName = s.SubCategoryName,
                    CategoryId = s.CategoryId,
                    ImageData = s.ImageData

                });
            if (category == null)
                return NoContent();

            return Ok(category);

        }
    }
}
