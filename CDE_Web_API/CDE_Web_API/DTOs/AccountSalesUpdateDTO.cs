using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.DTOs;

public class AccountSalesUpdateDTO
{
    [Required]
    public string Fullname { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public int PositionTitleId { get; set; }

   
    [Required]
    public int? Superior { get; set; }
    public string? Inferior { get; set; }

    public int? DistributorId { get; set; }
    public bool? Status { get; set; }



    //public string? SecurityCode { get; set; }

    //public int AreaId { get; set; }


    //public int? TokentId { get; set; }
}
