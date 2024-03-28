using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.DTOs;

public class AccountSalesDTO
{
    [Required]
    public string Fullname { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required]
    public int PositionTitleId { get; set; }
    [Required]
    public int? Superior { get; set; }
    public string? Inferior { get; set; }
    public bool Status { get; set; }
}
