using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CH_Manage.Models
{
    public class ConfigurationOption
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ConfigurationId { get; set; }

        [ForeignKey("ConfigurationId")]
        public virtual ClientConfiguration ClientConfiguration { get; set; }

        [Required]
        public Guid OptionId { get; set; }

        [ForeignKey("OptionId")]
        public virtual Option Option { get; set; }
    }
}
