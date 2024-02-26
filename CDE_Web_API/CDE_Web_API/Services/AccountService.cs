using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface AccountService
{
    public Task<IActionResult> register(AccountDTO accountDTO);
    public Task<IActionResult> SignInAsync(AccountDTO accountDTO);

}
