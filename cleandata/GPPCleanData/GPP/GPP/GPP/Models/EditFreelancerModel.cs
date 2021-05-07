using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GPP.Models
{
    public class EditFreelancerModel
    {
        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(50)]
        public string userName { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }

        [Required, StringLength(256)]
        
        public string WorkCountry { get; set; }
        [Required, StringLength(128)]
        public string WorkCity { get; set; }
        [Required, StringLength(128)]
        public string WorkDistrict { get; set; }
        
        [Required, StringLength(128)]
        public string Phone { get; set; }
    }
}
