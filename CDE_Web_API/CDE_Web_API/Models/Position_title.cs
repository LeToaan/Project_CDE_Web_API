using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class PositionTitle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(250)]
    public string Name { get; set; }

    public DateTime? created { get; set; }

    public string? PermissionIds { get; set; }
    public int PositionGroupId { get; set; }
    public virtual PositionGroup? PositionGroup { get; set; }

    public Dictionary<int, Permission> Permissions = new Dictionary<int, Permission>();
}