using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class NotifiUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int NotificationId { get; set; }
    public virtual Notification Notification { get; set; }

    public int Staff { get; set; }
    public virtual Account StaffAccount { get; set; }
}
