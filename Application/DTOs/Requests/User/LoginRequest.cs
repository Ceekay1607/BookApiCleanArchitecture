using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Requests.User;

public class LoginRequest
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
    public string? Username { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}
