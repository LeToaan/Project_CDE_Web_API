using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.DTOs;

public class ResetPasswordDTO
{
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required, Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;

}
