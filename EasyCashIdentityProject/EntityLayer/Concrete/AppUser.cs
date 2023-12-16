using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
         public string Name { get; set; }
         public string Surname { get; set; }
         public string District { get; set; }
         public string City { get; set; }
         public string ImageUrl { get; set; }

    }
}