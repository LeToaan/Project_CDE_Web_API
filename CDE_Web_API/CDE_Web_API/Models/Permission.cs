using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [MaxLength(250)]
    public string Name { get; set; }

    public int PermissionMuduleId { get; set; }

    public virtual PermissionModule PermissionModules { get; set; }

}
