using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface AreaService
{
    public Task<IActionResult> creater_area(AreaDTO areaDTO);
    public Task<IActionResult> update_area(int idArea, string name);
    public Task<IActionResult> delete_area(int idArea);

}
