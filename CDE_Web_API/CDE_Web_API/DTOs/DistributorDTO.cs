namespace CDE_Web_API.DTOs;

public class DistributorDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public int SaleManagement { get; set; }
    public int[] Sales { get; set; }
    public bool Status { get; set; }
}
