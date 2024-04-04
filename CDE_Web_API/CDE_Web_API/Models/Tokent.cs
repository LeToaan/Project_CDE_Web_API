using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.Models;

public class Tokent
{
    [Key]
    public int Id { get; set; }
    public string? PasswordResetToken { get; set; }
    public DateTime? ResetTokenExpires { get; set; }
    public int? AccountId { get; set; }
    public virtual Account? Account { get; set; }
}
