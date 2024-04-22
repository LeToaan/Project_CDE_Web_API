using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface AreaService
{
    public dynamic Area_manager(string? areaSearch);
    public dynamic Area_detail(int idArea, string? userKeyword);
    public Task<IActionResult> Creater_area(AreaDTO areaDTO);
    public Task<IActionResult> Update_area(int idArea, string name);
    public Task<IActionResult> Delete_area(int idArea);
    public Task<IActionResult> Change_area(int idUser, int idArea);

}
