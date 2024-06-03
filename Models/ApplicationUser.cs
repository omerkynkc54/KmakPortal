using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace KmakPortal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }

    }
}
