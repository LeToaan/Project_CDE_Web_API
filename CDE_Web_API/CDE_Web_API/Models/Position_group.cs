using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;


public class PositionGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(250)]
    public string Name { get; set; }

    public virtual ICollection<PositionTitle> PositionTitiles { get; set; } = new List<PositionTitle>();

}
