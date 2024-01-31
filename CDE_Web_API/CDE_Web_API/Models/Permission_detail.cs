using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class PermissionDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int PermissionId { get; set; }
    public virtual Permission Permission { get; set; }

    public int PositionGroupId { get; set; }
    public virtual PositionGroup PositionGroup { get; set; }
}
