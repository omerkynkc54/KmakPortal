using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace KmakPortal.Models
{
    public class User : IdentityUser<int>
    {
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("RoleId")]
        public virtual UserRole Role { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
