using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Items
{
    [ApiController]
    [Route("api/item")]
    public class UpdateItem : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateItem(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPut("UpdateItem/{id}")]
        public async Task<object> UpdateItems([FromForm] UpdateItemsRequest Request ,[FromRoute] int id)
        {
            var item = await _dbContext.Set<Item>()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (item == null)
                return NoContent();

            item.Update(Request.Name ,Request.Discription ,Request.Price);

          

            await _dbContext.SaveChangesAsync();
            return Ok("Updated Success");


        }



    }
}
