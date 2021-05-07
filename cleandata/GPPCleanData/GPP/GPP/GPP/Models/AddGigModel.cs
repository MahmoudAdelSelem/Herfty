using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GPP.Models
{
    public class AddGigModel
    {

        [Required]
        public string GigName { get; set; }
        [Required]
        public string Description { get; set; }

        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
       
        public string GigPic { get; set; }
        [Required]
        public virtual int ProfessionId { get; set; }

        public IFormFile files { get; set; }
        public  string UserId { get; set; }

    }
}
