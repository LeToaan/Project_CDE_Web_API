using CDE_Web_API.DTOs;
using CDE_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface AuthAccountService
{
    public Task<IActionResult> Login(AccountLoginDTO accountDTO);
    public string getAccount();
    public dynamic getAccountSystems();
    public dynamic getAccountSales();
    public dynamic getAccountDistributor();
    public dynamic getAccountGuest();

}
