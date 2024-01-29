using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.Models;

public class Tokent
{
    [Key]
    public int Id { get; set; }

    [MaxLength(250)]
    public string RefreshToken { get; set; }

}
