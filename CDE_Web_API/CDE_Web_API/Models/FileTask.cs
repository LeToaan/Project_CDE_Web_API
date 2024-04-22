using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class FileTask
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FileName { get; set; }
    public int? Reporter { get; set; }
    public int? Implementer { get; set; }
    public int TaskId { get; set; }
    public virtual Task Task { get; set; }
}
