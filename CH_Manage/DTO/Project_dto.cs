using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CH_Manage.DTO
{
    public class Project_dto
    {
        [Required(ErrorMessage = "Project title is required.")]
        [StringLength(255, ErrorMessage = "Title cannot exceed 255 characters.")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Base price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Base price must be greater than zero.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BasePrice { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
