using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace kelly.Areas.Identity.Data;

// Add profile data for application users by adding properties to the kellyUser class
public class kellyUser : IdentityUser
{
    [Required(ErrorMessage = "Please fill in this field")]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    public string FullName
    {
        get
        {
            return FirstName + " " + LastName;
        }
    }
    

    [Display(Name ="Moblie Number")]
    [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid Moblie number")]
    public string PhoneNumber { get; set; }

    //[StringLength(50, ErrorMessage = "The first name field should have a maximum of 50 characters")]
    //[Display(Name = "Address")]
    //public string? Address { get; set; }
}

