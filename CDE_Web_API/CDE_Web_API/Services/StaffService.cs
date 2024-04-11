using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface StaffService
{
    public dynamic staff_manager();
    public Task<IActionResult> creater_sales(int idArea, AccountSalesDTO accountSalesDTO);
    public Task<IActionResult> update_sales(AccountSalesUpdateDTO accountSalesDTO, int id);
    public Task<IActionResult> delete_sales(int id);
}
