using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class ResetPassword
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public DateTime RequestTime { get; set; }
        public UserProfile UserProfile { get; set; }
        public int UserProfileId { get; set; }


        public ResetPassword(string guid, int id)
        {
            Guid = guid;
            RequestTime = DateTime.UtcNow;
            UserProfileId = id;


        }
    }
}