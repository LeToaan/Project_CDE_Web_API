using System.ComponentModel.DataAnnotations;

namespace CDE_Web_API.DTOs;

public class TaskDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
    public DateTime? DateStart { get; set; }
    [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
    public DateTime? DateEnd { get; set; }
    public int Report { get; set; }
    public int Implement { get; set; }
}
