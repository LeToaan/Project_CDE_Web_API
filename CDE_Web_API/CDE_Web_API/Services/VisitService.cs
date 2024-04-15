using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface VisitService
{
 

    public Task<IActionResult> create_visit(VisitDTO visitDTO);

    public dynamic getVisit();

    public Task<dynamic> visitDetail(int id);

    public Task<dynamic> searchVisit(string? keyword);
}
