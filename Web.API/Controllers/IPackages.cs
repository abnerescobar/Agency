using Microsoft.AspNetCore.Mvc;
using Application.Reserves.Create;
using Application.Packages.Create;

namespace Web.API.Controllers
{
    public interface IPackages
    {
        Task<IActionResult> Create([FromBody] CreateReserveCommand command);
        Task<IActionResult> Create([FromBody] CreatePackageCommand command);
    }
}