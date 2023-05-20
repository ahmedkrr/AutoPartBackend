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
        public async Task<object> AddItemReq([FromForm] AddItems request  )
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

            try
            {
                bool isUniversal = false;
                if(request.CarModelId ==null && request.CartTypeId ==null && request.YearId == null)
                {
                    isUniversal = true;
                }
                using (var stream = new MemoryStream())
                {
                    await request.File.CopyToAsync(stream);
                    var fileBytes = stream.ToArray();
                    string base64String = Convert.ToBase64String(fileBytes);

                    var item = new Item(request.ItemName, request.Discription, request.Price, int.Parse(CompanyId), int.Parse(UserId), request.CarModelId, request.CartTypeId, request.YearId, request.SubCategoryId, DateTime.UtcNow, base64String , isUniversal);
                    _dbContext.Add(item);
                    await _dbContext.SaveChangesAsync();

                    return new AddItemResponse
                    {
                        success = true,
                    };

                }
            }
            catch (Exception ex)
            {
                var x= new AddItemResponse
                {
                    success = false,
                    message = ex.Message
                };
                return BadRequest(x);
                
            }


        }
    }
}
