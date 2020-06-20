using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Requests
{
    public class ModifyDoctorRequest
    {
        // same as doctor but without id (which is passed in the address) and Required parameters (only modify what's specified)
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
