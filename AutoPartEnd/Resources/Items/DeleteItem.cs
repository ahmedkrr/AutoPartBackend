using AutoPartEnd.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources
{

    [ApiController]
    [Route("api/item")]
    // [Authorize]
    public class DeleteItem : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        public DeleteItem(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [HttpDelete("DeleteItem/{Id}")]

    public async Task<object> DeleteItemReq([FromRoute]int Id)

        {
               var Items = await  _dbContext.Set<Item>().FindAsync(Id);

            if (Items != null)
            {
                _dbContext.Remove(Items);
               await _dbContext.SaveChangesAsync();

                return Ok("Deleted Success");
            }

            return BadRequest("The Item Not Found To Delete");


        }


    }
}
