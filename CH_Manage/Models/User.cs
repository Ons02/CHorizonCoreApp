using System;
using System.ComponentModel.DataAnnotations;

namespace CH_Manage.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        public string HashPassWord { get; set; }
    }
}
