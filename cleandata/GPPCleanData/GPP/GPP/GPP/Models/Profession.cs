using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GPP.Models
{
    public class Profession
    {
        public int Id { get;  }
        public string ProfName { get; set; }

        public string ProfPic { get; set; }
        [JsonIgnore]
        public ICollection<ApplicationUser> applicationUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Gig> Gigs { get; set; }
    }
}
