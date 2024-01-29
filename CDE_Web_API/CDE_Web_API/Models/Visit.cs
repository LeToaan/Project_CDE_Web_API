﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class Visit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public short? Time { get; set; }

    public DateTime? DateTime { get; set; }

    [MaxLength(250)]
    public string Intent { get; set; }

    public short? Status { get; set; }

    [Required]
    public int Creator { get; set; }

    public int? Guest { get; set; }

    [Required]
    public int DistributorId { get; set; }
    public virtual Distributor Distributor { get; set; }

    [Required]
    public int TaskId { get; set; }
    public virtual Task Task { get; set; }
}