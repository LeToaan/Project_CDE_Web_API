using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface AccountService
{
    public Task<IActionResult> register(AccountDTO accountDTO);
    public Task<IActionResult> update_user(AccountDTO accountDTO, int id);

    public Task<IActionResult> creater_sales(AccountSalesDTO accountSalesDTO);

    public Task<IActionResult> update_sales(AccountSalesUpdateDTO accountSalesDTO, int id);
    public Task<IActionResult> delete_user(int id);
    public Task<IActionResult> delete_sales(int id);



    public Task<IActionResult> forget_password(string email);
    public Task<IActionResult> reset_password(string code, ResetPasswordDTO resetPasswordDTO);
}
