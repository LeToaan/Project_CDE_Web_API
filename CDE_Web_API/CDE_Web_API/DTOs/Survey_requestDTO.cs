namespace CDE_Web_API.DTOs;

public class SurveyRequestDTO
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public bool Status { get; set; }

    public int Receiver { get; set; }
}
