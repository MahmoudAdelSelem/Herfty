using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GPP.Models
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
        public int GigId { get; set; }
        [Required]
        public string GigName { get; set; }
        
        public string imagePath { get; set; }

    }
}
