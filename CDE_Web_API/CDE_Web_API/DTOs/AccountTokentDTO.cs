using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.DTOs;

public class AccountTokentDTO
{   
    public int Id { get; set; }
    public string FullName { get; set; }
    [Required]
    public string Email { get; set; }
   
}
