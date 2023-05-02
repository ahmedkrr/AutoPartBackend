using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources { 

 [ApiController]
 [Route("api/admin")]
public class DeleteSubCategory : ControllerBase
{

    private readonly ApplicationDbContext _dbContext;
    public DeleteSubCategory(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpDelete("deletesubcategory/{id}")]
    public async Task<object> DeleteCategoryResponse([FromRoute] int Id)
    {
        var subcategory = await _dbContext.Set<SubCategory>().FindAsync(Id);

        if (subcategory != null)
        {
            _dbContext.Remove(subcategory);
            await _dbContext.SaveChangesAsync();

            return new DeleteSubCategoryResponse
            {
                success = true,
                categoryName = subcategory.SubCategoryName
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