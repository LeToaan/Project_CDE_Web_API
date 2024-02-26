using Microsoft.AspNetCore.Identity;

namespace CDE_Web_API.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
