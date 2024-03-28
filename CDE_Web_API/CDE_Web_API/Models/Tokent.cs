using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.Models;

public class Tokent
{
    [Key]
    public int Id { get; set; }

    public string? RefreshToken { get; set; }
    public string? Email { get; set; }
    public string? VerificationToken { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public string? PasswordResetToken { get; set; }
    public DateTime? ResetTokenExpires { get; set; }
}
