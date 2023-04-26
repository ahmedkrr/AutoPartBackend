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

        [HttpPut("UpdateItem")]
        public async Task<object> UpdateItems([FromBody] UpdateItemsRequest Request)
        {
            var Items = _dbContext.Set<Item>()
                .Find(Request.Id); 

            Items.Update(Request.Name ,Request.Discription ,Request.Price);

            var UpdatedItems = _dbContext.Set<Item>()
               .Find(Request.Id);

            await _dbContext.SaveChangesAsync();
            return "Successfullty" + UpdatedItems;


        }



    }
}
