﻿using AutoPartEnd.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin
{
    [ApiController]
    [Route("api/admin")]
    public class UpdateCarType : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateCarType(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpPut("UpdateCarType/{id}/{name}")]
        public async Task<object> UpdateCarInfo([FromRoute] int id, string name)
        {

            var Type = await _dbContext.Set<CarType>().FirstOrDefaultAsync(c => c.Id == id);

            if (Type == null)
                return NoContent();

            Type.update(name);

            await _dbContext.SaveChangesAsync();


            return Ok();


        }
    }
}
