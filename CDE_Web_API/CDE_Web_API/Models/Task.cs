using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class Task
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(250)]
    public string Title { get; set; }

    [MaxLength(250)]
    public string File { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    public short? Status { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    [Required]
    public int Report { get; set; }
    public virtual Account ReportAccount { get; set; }

    [Required]
    public int Implement { get; set; }
    public virtual Account ImplementAccount { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}
