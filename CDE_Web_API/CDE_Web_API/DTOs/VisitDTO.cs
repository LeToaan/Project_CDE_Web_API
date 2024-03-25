namespace CDE_Web_API.DTOs;

public class VisitDTO
{
    public short? Time { get; set; }

    public DateTime? DateTime { get; set; }

    public string Intent { get; set; }

    public int? Guest { get; set; }

    public int DistributorId { get; set; }
}
