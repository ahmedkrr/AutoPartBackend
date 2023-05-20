using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Items
{
    [ApiController]
    [Route("api/item")]
    public class GetInfoItemById : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _config;
        public GetInfoItemById(ApplicationDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        [HttpGet("Getiteminfo/{itemId}")]
        public async Task<object> GetItems([FromRoute] int itemId)
        {

            var Item = await _dbContext.Set<Item>()
                .FirstOrDefaultAsync(s => s.Id == itemId);
                


            if (Item == null )
            {
                return NoContent();
            }


            return Ok(new GetItemResponsee 
            {
                Name = Item.Name,
                Discription = Item.Discription,
                Price = Item.Price,

            }
                );
        }
    }
}
