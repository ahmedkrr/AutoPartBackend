using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.LookUps
{
    [ApiController]
    [Route("api/lookups")]
    public class GetCompanyProfileInfo : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCompanyProfileInfo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("getCompanyInfo/{id}")]
        
        public async Task<object> getCompanyInfoRequest([FromRoute] int id)
        {
            var company = await _dbContext.Set<CompanyProfile>().FirstOrDefaultAsync(c => c.Id == id);
            if (company == null)
                return null;

            var modelcompany = new GetCompanyInfoReq
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                CompanyPhoneNumber = company.CompanyPhoneNumber,
                CreatDate = $"{company.CreatDate.Month}/{company.CreatDate.Year}",
                Avatar = company.Avatar,
                BackgroundImage = company.BackgroundImage,
                IsDeactive = company.IsDeactive


            };


            return modelcompany;
        }
    }
}
