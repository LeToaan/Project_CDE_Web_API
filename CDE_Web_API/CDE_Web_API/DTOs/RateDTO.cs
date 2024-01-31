namespace CDE_Web_API.DTOs;

public class RateDTO
{
    public int Id { get; set; }

    public short? RateValue { get; set; }

    public string Comment { get; set; }

    public DateTime? Created { get; set; }

    public int Rater { get; set; }

    public int TaskId { get; set; }
}

