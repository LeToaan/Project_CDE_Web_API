using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface PositionTitleService
{
    public Task<IActionResult> create_positionTitle(PositionTitleDTO positionTitleDTO);
    public dynamic getPosition_Title_user();
    public dynamic getPosition_Title_Sales();
    public dynamic getPosition_Title_Distributor();
}
