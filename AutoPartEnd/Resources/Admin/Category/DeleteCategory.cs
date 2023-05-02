using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin
{
    [ApiController]
    [Route("api/admin")]
    public class DeleteCategory : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        public DeleteCategory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpDelete("deletecategory/{id}")]
        public async Task<object> DeleteCategoryResponse([FromRoute] int Id)
        {
            var category = await _dbContext.Set<Category>().FindAsync(Id);

            if (category != null)
            {
                _dbContext.Remove(category);
                await _dbContext.SaveChangesAsync();

                return new DeleteCategoryResponse
                { 
                    success = true,
                    categoryName = category.CategoryName
                };
            }

            return new DeleteCategoryResponse
            {
                success = false,
                CategoryId = Id
            }; ;
        }
    }
}
