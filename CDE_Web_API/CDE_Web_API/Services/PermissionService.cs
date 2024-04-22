using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface PermissionService
{
    public dynamic GetPermission();
    public Task<IActionResult> SetPermission(int id, PermissionAccountDTO permissions);
}
