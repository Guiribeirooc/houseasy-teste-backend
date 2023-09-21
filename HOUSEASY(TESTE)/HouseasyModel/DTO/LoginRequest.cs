using System.ComponentModel.DataAnnotations;

namespace HouseasyModel.DTO
{
    public class LoginRequest
    {
        [Required]
        public string User { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}