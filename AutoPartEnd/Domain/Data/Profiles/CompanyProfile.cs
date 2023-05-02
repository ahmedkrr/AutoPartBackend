using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class CompanyProfile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public Guid AccountId { get; private set; }
        public string Name { get; private set; }
        public string CompanyPhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string Avatar { get; private set; }
        public string BackgroundImage { get; private set; }
        public DateTime CreatDate { get; private set; }
        public bool IsDeactive { get; private set; }

        public IEnumerable<UserProfile> userProfiles { get; set; }

        public void Deactive()
        {
            IsDeactive = true;
        }
        public void Active()
        {
            IsDeactive = false;
        }
        public void SetAvatar(string avatar)
        {
            Avatar = avatar;
        }
        public void SetBackgroundImage(string backgroundImage)
        {
            BackgroundImage = backgroundImage;
        }

        public CompanyProfile(string name, string companyPhoneNumber, string address)
        {
            AccountId = new Guid();

            if (!string.IsNullOrEmpty(name))
                Name = name;

            if (!string.IsNullOrEmpty(companyPhoneNumber))
                CompanyPhoneNumber = companyPhoneNumber;

            if (!string.IsNullOrEmpty(address))
                Address = address;

            CreatDate = DateTime.UtcNow;

        }

    }
}
