using System.ComponentModel.DataAnnotations;

namespace CH_Manage.DTO
{
    public class LoginRequest_dto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
