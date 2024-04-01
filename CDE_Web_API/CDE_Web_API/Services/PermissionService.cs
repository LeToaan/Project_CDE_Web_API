using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface PermissionService
{
    public dynamic getPermission();
    public Task<IActionResult> setPermission(int id, PermissionAccountDTO permissions);
}
