using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface PositionTitleService
{
    public Task<IActionResult> create_positionTitle(PositionTitleDTO positionTitleDTO);
    public Task<IActionResult> getPosition_Title_user();
}
