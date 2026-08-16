using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CH_Manage.Models
{
    public class ClientConfiguration
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        [Required]
        [StringLength(255)]
        public string ClientName { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string ClientEmail { get; set; }

        [Required]
        public Guid Token { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ConfigurationOption> ConfigurationOptions { get; set; }
    }
}
