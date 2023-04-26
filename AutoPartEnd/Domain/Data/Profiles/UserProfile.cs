using AutoPartEnd.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class UserProfile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public UserRole Role { get; private set; }

        public bool IsCompanyOwner { get; private set; }
        public bool IsAdmin { get; private set; }
        public bool IsDeactive { get; private set; }
        public DateTime CreatDate { get; private set; }

        public CompanyProfile CompanyProfile { get; set; }
        public int? CompanyProfileId { get; private set; }

        public UserProfile(string name, string email, string password, string phoneNumber )
        {
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Role = UserRole.Member;
            CreatDate = DateTime.UtcNow;
        }
        public UserProfile(string name, string email, string password, string phoneNumber, bool isCompanyOwner, bool isAdmin)
        {
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Role = UserRole.Admin;
            IsCompanyOwner = isCompanyOwner;
            IsAdmin = isAdmin;
            CreatDate = DateTime.UtcNow;
        }
        
        public void UpdateUserAdmin(string name ,UserRole role ,bool isAdmin ,bool isDeactive)
        {
            Name = name;
            Role = role;
            IsAdmin = isAdmin;
            IsDeactive = isDeactive;
        }

        public void Deactive()
        {
            IsDeactive = true;
        }
        public void Active()
        {
            IsDeactive = false;
        }

        public void setAsAcompanyOwner(int companyId)
        {
            IsCompanyOwner = true;
            CompanyProfileId = companyId;
        }
        public void UnDosetAsAcompanyOwner()
        {
            IsCompanyOwner = false;
            CompanyProfileId = null;
        }
    }

    
}
