using System.ComponentModel.DataAnnotations;

namespace CH_Manage.DTO
{
    public class User_dto
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 255 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string HashPassWord { get; set; }
    }
}
