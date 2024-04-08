using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface DistributorService
{
    public Task<IActionResult> creater_distriburot(DistributorDTO distributorDTO);
    public Task<IActionResult> update_distriburot(DistributorUpdateDTO distributorDTO, int id);
    public Task<IActionResult> delete_distriburot(int idDistributor);

}
