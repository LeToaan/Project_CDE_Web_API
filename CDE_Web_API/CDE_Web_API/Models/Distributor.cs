﻿using System.ComponentModel.DataAnnotations;
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
    public int SaleManagement { get; set; }

    [MaxLength(250)]
    public string Sales { get; set; }

    [MaxLength(250)]
    public string Email { get; set; }

    [MaxLength(250)]
    public string Phone { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public bool Status { get; set; }

    [Required]
    public int PositionGroupId { get; set; }
    public virtual PositionGroup PositionGroup { get; set; }
}
