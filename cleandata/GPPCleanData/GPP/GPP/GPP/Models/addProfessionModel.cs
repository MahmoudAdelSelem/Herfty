using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GPP.Models
{
    public class addProfessionModel
    {
        [Required]
        public string ProfName { get; set; }
        
        public string ProfPic { get; set; }
        [Required]
        public IFormFile files { get; set; }
    }
}
