using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.DTOs;

public class StaffDTO
{
  
    [Required]
    public string Fullname { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public int? Superior { get; set; }
    public string? Inferior { get; set; }
    public bool Status { get; set; }
    [Required]
    public int PositionGroupId { get; set; }

}
