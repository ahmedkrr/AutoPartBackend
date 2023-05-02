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
    public class GetSubCategory : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GetSubCategory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetSubCategory/{id}")]
        public async Task<object> GetSubCategoryReq([FromRoute]int id)
        {
            var category =  _dbContext.Set<SubCategory>().Where(s => s.CategoryId == id)
                .Select(s => new SubCategoriesResponse
                {
                    SubCategoryId = s.Id,
                    SubCategoryName = s.SubCategoryName,
                    CategoryId = s.CategoryId,
                    ImageData = s.ImageData

                }) ;


            return  category;

        }

    }
}
