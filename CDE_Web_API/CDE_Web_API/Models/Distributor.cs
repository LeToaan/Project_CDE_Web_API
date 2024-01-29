using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class Distributor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(250)]
    public string Name { get; set; }

    [MaxLength(250)]
    public string Address { get; set; }

    [MaxLength(250)]
    public string Email { get; set; }

    [MaxLength(250)]
    public string Phone { get; set; }

    [Required]
    public int AreaId { get; set; }
    public virtual Area Area { get; set; }

    [Required]
    public int PositionGroupId { get; set; }
    public virtual PositionGroup PositionGroup { get; set; }
}
