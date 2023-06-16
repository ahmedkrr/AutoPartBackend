using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;
using System.Net;
using Microsoft.EntityFrameworkCore;
using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.Extensions.Configuration;

namespace AutoPartEnd.Resources.Account
{
    [ApiController]
    [Route("api/Account")]

    public class RequestResetPasswordByEmail : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _config;
        public RequestResetPasswordByEmail(ApplicationDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }
        [HttpPost("sendEmail")]
        public async Task<object> SendEmailRequest([FromBody] EmailModel model)
        {
            var guid = Guid.NewGuid();

            DateTime expiration = DateTime.UtcNow;

            var user = await _dbContext.Set<UserProfile>().FirstOrDefaultAsync(c => c.Email == model.To);

            if (user == null)
            {
                return BadRequest("The Email Not Found");
            }

            var request = new ResetPassword(guid.ToString(), user.Id);
            _dbContext.Add(request);
            await _dbContext.SaveChangesAsync();

            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_config["EmailSetting:MainEmail"], _config["EmailSetting:Password"]);

                var url = "";
                var emailMessage = new MailMessage
                {
                    From = new MailAddress("infoautopart2023@gmail.com", "Auto Part Reset Paswword"),
                    Subject = "Reset Password",
                    Body = "http://localhost:3000/reset-password/" + guid,
                    IsBodyHtml = true
                };
                emailMessage.To.Add(new MailAddress(model.To));

                client.Send(emailMessage);
                return Ok();
            }


        }

        [HttpPost("resetpassword/{guid}")]
        public async Task<object> SendGuid([FromBody] ResetPasswordReq model ,[FromRoute] Guid guid)
        {
            var requestReset = await _dbContext.Set<ResetPassword>().FirstOrDefaultAsync(c => c.Guid == guid.ToString());
            if (requestReset == null || requestReset.RequestTime.AddMinutes(20) < DateTime.UtcNow)
                return BadRequest("Expired Url");

            try
            {

                var user = await _dbContext.Set<UserProfile>().FirstOrDefaultAsync(c => c.Id == requestReset.UserProfileId);

                user.ResetPassword(model.Password);
                await _dbContext.SaveChangesAsync();
                return Ok("The Password Changed Successfully");

            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }


        }
    }
}
