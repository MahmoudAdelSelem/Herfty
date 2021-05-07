using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPP.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string WorkCountry { get; set; }

        public string WorkCity { get; set; }

        public string WorkDistrict { get; set; }

        public int? Rate { get; set; }

        public int? ProfessionId { get; set; }

        public string profilepic { get; set; }

        public virtual ICollection<Gig> Gigs { get; set; }

        public virtual Profession Profession { get; set; }


    }
}
