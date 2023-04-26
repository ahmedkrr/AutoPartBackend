using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources
{
    [ApiController]
    [Route("api/Cate")]
   // [Authorize]
    public class AddSubCategory : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AddSubCategory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpPost("AddSubCategory/{Id}")]
        public async Task<object> AddSubCategoryReq([FromForm] AddSubCategories request , [FromForm] IFormFile file ,[FromRoute] int Id)
        {
            var car = _dbContext.Set<Category>().FirstOrDefault(c => c.Id == Id);

            if (car == null || file ==null)
                return "The Category not found";

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var fileBytes = stream.ToArray();
                string base64String = Convert.ToBase64String(fileBytes);

                var subCategory = new SubCategory(request.SubCategoryName, Id, base64String);
                _dbContext.Add(subCategory);
                await _dbContext.SaveChangesAsync();
                return subCategory.Id;

            }




        }




    }
}
