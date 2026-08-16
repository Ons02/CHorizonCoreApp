using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CH_Manage.DTO
{
    public class Option_dto
    {
        [Required(ErrorMessage = "Project ID is required.")]
        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "Option name is required.")]
        [StringLength(255, ErrorMessage = "Name cannot exceed 255 characters.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Estimated days must be a non-negative number.")]
        public int? EstimatedDays { get; set; }
    }
}
