using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Model
{
    public class CompanyModel
    {
    

    }
    public class AddCompanyModel
    {
        public string Name { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string Address { get; set; }
    }
    
    public class AddAvatarCompanyResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
    public class GetCompanyInfoReq
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string CompanyPhoneNumber { get;  set; }
        public string Address { get;  set; }
        public string Avatar { get;  set; }
        public string BackgroundImage { get;  set; }
        public string CreatDate { get;  set; }
        public bool IsDeactive { get;  set; }



    }
}
