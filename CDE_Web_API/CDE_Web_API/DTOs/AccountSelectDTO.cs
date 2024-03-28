using CDE_Web_API.Models;
using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.DTOs;

public class AccountSelectDTO
{
    public int Id { get; set; }

    [Required]
    public string? Password { get; set; }

    [MaxLength(250)]
    public string Fullname { get; set; }

    [MaxLength(250), EmailAddress]
    public string Email { get; set; }

    [MaxLength(50)]
    public string? Phone { get; set; }

    [MaxLength(250)]
    public string? Address { get; set; }

    [MaxLength(250)]
    public string? Photo { get; set; }

    [MaxLength(250)]
    public string? Description { get; set; }

    public bool? Status { get; set; }

    public DateTime? Created { get; set; }

    public int? Superior { get; set; }

    public string? Inferior { get; set; }

    public string? SecurityCode { get; set; }
    public int? PositionTitleId { get; set; }
    public int? DistributorId { get; set; }

    public int? AreaId { get; set; }
    public virtual Area? Area { get; set; }

    public int? PositionGroupId { get; set; }
    public virtual PositionGroup? PositionGroup { get; set; }

    public int? TokentId { get; set; }
    public virtual Tokent? Tokent { get; set; }
}
