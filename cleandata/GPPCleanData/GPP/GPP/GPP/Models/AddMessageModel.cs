using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPP.Models
{
    public class AddMessageModel
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
}
