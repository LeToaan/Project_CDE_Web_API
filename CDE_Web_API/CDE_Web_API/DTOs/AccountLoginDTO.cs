using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.DTOs;

public class AccountLoginDTO
{
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
