using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface DistributorService
{
    public Task<IActionResult> Creater_distriburot(int idArea,DistributorDTO distributorDTO);
    public Task<IActionResult> Update_distriburot(DistributorUpdateDTO distributorDTO, int id);
    public Task<IActionResult> Delete_distriburot(int idDistributor);

}
