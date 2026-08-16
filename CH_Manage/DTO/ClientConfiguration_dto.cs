using System.ComponentModel.DataAnnotations;

namespace CH_Manage.DTO
{
    public class ClientConfiguration_dto
    {
        [Required(ErrorMessage = "Client name is required.")]
        [StringLength(255, ErrorMessage = "Client name cannot exceed 255 characters.")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Client email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters.")]
        public string ClientEmail { get; set; }
    }
}
