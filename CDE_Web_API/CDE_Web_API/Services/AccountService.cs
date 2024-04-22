using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface AccountService
{
    public Task<IActionResult> Register(AccountDTO accountDTO);
    public Task<IActionResult> Update_user(AccountDTO accountDTO, int id);
    public Task<IActionResult> Delete_user(int id);
    public Task<IActionResult> Forget_password(string email);
    public Task<IActionResult> Reset_password(string code, ResetPasswordDTO resetPasswordDTO);
}
