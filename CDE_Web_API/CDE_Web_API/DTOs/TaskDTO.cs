namespace CDE_Web_API.DTOs;

public class TaskDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string File { get; set; }
    public string Description { get; set; }
    public short? Status { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public int Report { get; set; }
    public AccountDTO ReportAccount { get; set; }
    public int Implement { get; set; }
    public AccountDTO ImplementAccount { get; set; }
    public int CategoryId { get; set; }
    public CategoryDTO Category { get; set; }
}
