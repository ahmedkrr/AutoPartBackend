using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Items
{
    [ApiController]
    [Route("api/item")]
    [Authorize]
    public class AddItem : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AddItem(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost("AddItem")]
        public async Task<object> AddItemReq([FromBody] AddItems request)
        {
            var UserId = User.FindFirst("Id")?.Value;
            var CompanyId = User.FindFirst("CompanyId")?.Value;

            if (UserId == null || CompanyId == "")
            {
                throw new Exception("bad ");

            }

            var item = new Item(request.ItemName, request.Discription, request.Price, int.Parse(CompanyId), int.Parse(UserId), request.CarModelId, request.CartTypeId, request.YearId, request.SubCategoryId, DateTime.UtcNow);
           
            _dbContext.Add(item);
            await _dbContext.SaveChangesAsync();

            return item.Id;

        }
    }
}
