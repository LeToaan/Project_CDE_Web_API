using CDE_Web_API.Models;
using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.DTOs;

public class AccountDTO
{
    [Required]
    public string Fullname { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required]
    public int positionTitleId { get; set; }
    public bool? Status { get; set; }
}
