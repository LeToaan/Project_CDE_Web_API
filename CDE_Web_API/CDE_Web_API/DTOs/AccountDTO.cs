﻿using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.DTOs;

public class AccountDTO
{
    //public int Id { get; set; }

    // public string Password { get; set; }
    [Required]
    public string Fullname { get; set; }
    [Required]
    public string Email { get; set; }

    //public string? Phone { get; set; }

    //public string? Address { get; set; }

    //public string? Photo { get; set; }

    //public string? Description { get; set; }

    // public bool? Status { get; set; }

    // public DateTime? Created { get; set; }
    [Required]
    public int? Superior { get; set; }

    //public string? SecurityCode { get; set; }

    //public int AreaId { get; set; }
    [Required]
    public int PositionGroupId { get; set; }

    //public int? TokentId { get; set; }
}
