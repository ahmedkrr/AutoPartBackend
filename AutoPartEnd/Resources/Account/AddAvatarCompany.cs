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

namespace AutoPartEnd.Resources
{
    [ApiController]
    [Route("api/Account")]
    public class AddAvatarCompany : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        public AddAvatarCompany(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost("AddAvatarCompany/{id}")]

        public async Task<object> AddAvatarCompanyRequest([FromForm] IFormFile file, [FromRoute]int id)
        {
            if(file.Length == 0 || id == 0)
            {
                return new AddAvatarCompanyResponse
                {
                    success = false
                };
            }

            var company = await _dbContext.Set<CompanyProfile>().FirstOrDefaultAsync(c => c.Id ==id);

            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    var fileBytes = stream.ToArray();
                    string base64String = Convert.ToBase64String(fileBytes);

                    company.SetAvatar(base64String);
                    await _dbContext.SaveChangesAsync();


                    return new AddAvatarCompanyResponse
                    {
                        success = true,
                        message = "The Avatar Added Successfully"

                    };
                }
            }
            catch (DbUpdateException ex)
            {
                return new AddAvatarCompanyResponse
                {

                    message = ex.ToString()
                };
            }

         

                    
        }


        [HttpPost("AddBackgoundImage/{id}")]

        public async Task<object> AddBackGroundImageRequest([FromForm] IFormFile file, [FromRoute] int id)
        {
            if (file.Length == 0 || id == 0)
            {
                return new AddAvatarCompanyResponse
                {
                    success = false
                };
            }

            var company = await _dbContext.Set<CompanyProfile>().FindAsync(id);

            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    var fileBytes = stream.ToArray();
                    string base64String = Convert.ToBase64String(fileBytes);

                    company.SetBackgroundImage(base64String);
                    await _dbContext.SaveChangesAsync();


                    return new AddAvatarCompanyResponse
                    {
                        success = true,
                        message = "The Background Added Successfully"

                    };
                }
            }
            catch (DbUpdateException ex)
            {
                return new AddAvatarCompanyResponse
                {

                    message = ex.ToString()
                };
            }




        }

    }
}
