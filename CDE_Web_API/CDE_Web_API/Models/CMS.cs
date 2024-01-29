using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class CMS
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(250)]
    public string Title { get; set; }

    [MaxLength(250)]
    public string Description { get; set; }

    [MaxLength(250)]
    public string Photo { get; set; }

    [MaxLength(250)]
    public string Link { get; set; }

    public DateTime? Created { get; set; }

    public bool Status { get; set; }

    [Required]
    public int Creator { get; set; }
    public virtual Account CreatorAccount { get; set; }
}