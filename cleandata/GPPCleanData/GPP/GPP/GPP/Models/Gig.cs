using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GPP.Models
{
    public class Gig
    {

        public int GigId { get; set; }
        [Required]
        public string GigName { get; set; }
        [Required]
        public string Description { get; set; }

        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        [Required]
        public string GigPic { get; set; }

        [JsonIgnore]
        public virtual string UserId { get; set; }
       [JsonIgnore]
        public virtual ApplicationUser applicationUser { get; set; }
        [JsonIgnore]
        public virtual int ProfessionId { get; set; }
       [JsonIgnore]
        public virtual Profession Profession { get; set; }


    }
}
