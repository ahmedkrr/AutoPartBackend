using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Http;
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
    public class UpdateCategory : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateCategory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<object> UpdateCarInfo([FromRoute] int id ,[FromForm]UpdateCategoryRequest model)
        {

            var category = await _dbContext.Set<Category>().FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
                return NoContent();


            if (model.file == null)
            {
                category.UpdateCatgory(model.CategoryName);
                

            }
            if(model.file != null)
            {
                  using (var stream = new MemoryStream())
                {
                    await model.file.CopyToAsync(stream);
                    var fileBytes = stream.ToArray();
                    string base64String = Convert.ToBase64String(fileBytes);
                    category.UpdateCatgory(model.CategoryName, base64String);
                }
            }


            await _dbContext.SaveChangesAsync();


            return Ok();


        }
    }
}
