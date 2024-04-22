using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface StaffService
{
    public dynamic Staff_manager();
    public Task<IActionResult> Creater_sales(int idArea, AccountSalesDTO accountSalesDTO);
    public Task<IActionResult> Update_sales(AccountSalesUpdateDTO accountSalesDTO, int id);
    public Task<IActionResult> Delete_sales(int id);
}
