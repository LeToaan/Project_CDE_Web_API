using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class Rate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public short? RateValue { get; set; }
    public string Comment { get; set; }
    public DateTime? Created { get; set; }
    [Required]
    public int RaterId { get; set; }
    public virtual Account RaterAccount { get; set; }
    [Required]
    public int TaskId { get; set; }
    public virtual Task Task { get; set; }
}
