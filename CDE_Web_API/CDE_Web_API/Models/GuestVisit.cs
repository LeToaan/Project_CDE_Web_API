using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class GuestVisit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public int GuestId { get; set; }
    public virtual Account Guest { get; set; }
    public bool? Refuse { get; set; }
    public string? Reason { get; set; }
    public int VisitId { get; set; }
    public virtual Visit Visit { get; set; }
}