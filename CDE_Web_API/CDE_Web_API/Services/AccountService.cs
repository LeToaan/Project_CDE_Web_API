using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface AccountService
{
    Task<IActionResult> resiter(AccountDTO accountDTO);
}
