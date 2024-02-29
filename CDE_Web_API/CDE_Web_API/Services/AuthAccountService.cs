using CDE_Web_API.DTOs;
using CDE_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface AuthAccountService
{
    public Task<IActionResult> register(AccountDTO accountDTO);
    public Task<IActionResult> Login(AccountLoginDTO accountDTO);
    public Task<IActionResult> getAccount(string email);
}
