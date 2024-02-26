using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.DTOs;

public class UserDTO
{
    [Required]
    public string Fullname { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public bool Status { get; set; }
    public int AreaId { get; set; }
    [Required]
    public int PositionGroupId { get; set; }
}
