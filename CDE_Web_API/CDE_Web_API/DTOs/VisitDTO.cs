using CDE_Web_API.Models;

namespace CDE_Web_API.DTOs;

public class VisitDTO
{
    public DateTime DateTime { get; set; }
    public short Time { get; set; }
    public int? DistributorId { get; set; }
    public string Intent { get; set; }
    public int?[] Guest { get; set; }
}
