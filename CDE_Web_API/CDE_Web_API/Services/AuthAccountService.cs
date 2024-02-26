using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface AuthAccountService
{
    Task<IActionResult> register(AccountDTO accountDTO);
    Task<string> Login(AccountLoginDTO accountDTO);

}
