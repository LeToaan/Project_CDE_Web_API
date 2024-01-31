namespace CDE_Web_API.DTOs;

public class NotificationDTO
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime? Created { get; set; }
}
