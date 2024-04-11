namespace CDE_Web_API.DTOs;

public class DistributorUpdateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int SaleManagement { get; set; }
    public int[] Sales { get; set; }
    public bool Status { get; set; }
}
