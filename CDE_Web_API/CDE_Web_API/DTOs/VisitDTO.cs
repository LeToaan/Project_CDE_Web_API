namespace CDE_Web_API.DTOs;

public class VisitDTO
{
    public int Id { get; set; }

    public short? Time { get; set; }

    public DateTime? DateTime { get; set; }

    public string Intent { get; set; }

    public short? Status { get; set; }

    public int Creator { get; set; }

    public int? Guest { get; set; }

    public int DistributorId { get; set; }

    public int TaskId { get; set; }
}
