using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KmakPortal.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        [ForeignKey("UserRole")]
        public int RoleId { get; set; }
        public UserRole UserRole { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
