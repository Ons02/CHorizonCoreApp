using System.ComponentModel.DataAnnotations;

namespace CH_Manage.DTO
{
    public class ForgotPassword_dto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
    }
}
