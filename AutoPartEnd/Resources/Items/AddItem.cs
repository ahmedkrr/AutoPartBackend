using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<object> AddItemReq([FromBody] AddItems request , [FromForm] IFormFile file)
        {
            var UserId = User.FindFirst("Id")?.Value;
            var CompanyId = User.FindFirst("CompanyId")?.Value;

            if (UserId == null || CompanyId == "")
            {
                //throw new Exception("bad ");
                return new AddItemResponse
                {
                    success = false,
                    message = "The User Not Authorize",
            };

        }


            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var fileBytes = stream.ToArray();
                string base64String = Convert.ToBase64String(fileBytes);
                var item = new Item(request.ItemName, request.Discription, request.Price, int.Parse(CompanyId), int.Parse(UserId), request.CarModelId, request.CartTypeId, request.YearId, request.SubCategoryId, DateTime.UtcNow , base64String);
                _dbContext.Add(item);
                await _dbContext.SaveChangesAsync();

                return new AddItemResponse
                {
                    success = true,
                };

            }


        }
    }
}
