using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace kelly.Areas.Identity.Data;

// Add profile data for application users by adding properties to the kellyUser class
public class kellyUser : IdentityUser
{
    public string FirstName { get; set; }
    public string lastName { get; set; }
}

