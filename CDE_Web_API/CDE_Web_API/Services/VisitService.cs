using CDE_Web_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Web_API.Services;

public interface VisitService
{
    public dynamic VisitManager();
    public Task<IActionResult> Create_visit(VisitDTO visitDTO);

    public dynamic GetVisit();

    public Task<dynamic> VisitDetail(int id);

    public Task<dynamic> SearchVisit(string? keyword);
}
