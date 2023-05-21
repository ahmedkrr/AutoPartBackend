using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin
{
    [ApiController]
    [Route("api/admin")]
    public class UpdateSubCategory : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateSubCategory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPut("UpdateSubCategory/{id}")]
        public async Task<object> UpdateCarInfo([FromRoute] int id ,[FromForm] UpdateCategoryRequest model)
        {

            var subCategory = await _dbContext.Set<SubCategory>().FirstOrDefaultAsync(c => c.Id == id);

            if (subCategory == null)
                return NoContent();


            if (model.file == null)
            {
                subCategory.UpdateSubCatgory(model.CategoryName);


            }
            if (model.file != null)
            {
                using (var stream = new MemoryStream())
                {
                    await model.file.CopyToAsync(stream);
                    var fileBytes = stream.ToArray();
                    string base64String = Convert.ToBase64String(fileBytes);
                    subCategory.UpdateSubCatgory(model.CategoryName, base64String);
                }
            }


            await _dbContext.SaveChangesAsync();


            return Ok();


        }
    }
}
