using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AutoPartEnd.Resources
{
    [ApiController]
    [Route("api/Admin")]
    
    public class AddCategory : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AddCategory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("addCategory")]
        public async Task<object> AddCategoryReq([FromForm] AddCategories request , [FromForm] IFormFile file)
        {
            var category = new Category(request.CategoryName);

            if (category != null && file.Length > 0)
            {
                var fileName = file.FileName;
                var fileSize = file.Length;
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    var fileBytes = stream.ToArray();
                    string base64String = Convert.ToBase64String(fileBytes);
                    category.ImageData = base64String;




                    _dbContext.Add(category);
                    await _dbContext.SaveChangesAsync();

                }



                return new AddCategoryResponse
                {
                    success = true,
                    Categoryname =category.CategoryName

                };
            }


            return "Failed to add category";
        }



    }
}
