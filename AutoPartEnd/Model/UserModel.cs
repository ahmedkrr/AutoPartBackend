using AutoPartEnd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Model
{
    public class UserModel
    {
    }
    public class LoginResponse
    {
        public string message { get; set; }

        public Boolean sucess { get; set; }
    }


    public class UserRegestrationRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class UserLogin
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class AdminLoginResponse
    {
        public string message { get; set; }
        public bool success  { get; set; }
    }
    public class AdminLoginResponseFailed
    {
        public string failed { get; set; }
        public bool success { get; set; }
    }


    public class GeyUserInfoRequest
    {
        public int Id { get; set; }
    }
    public class UserRegestrationResponsinfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class GetUserResponseinfo
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string PhoneNumber { get;  set; }

        public string Role { get; set; }
        public bool IsCompanyOwner { get;  set; }
        public bool IsAdmin { get;  set; }
        public bool IsDeactive { get;  set; }
        public string CreatDate { get;  set; }
        public string? CompanyProfile { get; set; }
        public int? CompanyProfileId { get;  set; }



    }
    public class UpdatUserReq
    {
        public string Name { get;  set; }
        public string Email { get; set; }
        //public UserRole Role { get;  set; }
        public bool IsAdmin { get;  set; }
        public bool IsDeactive { get;  set; }


    }
    public enum UserRole
    {
        undefined = 0,
        Member = 1,
        Admin = 2
    }
}
