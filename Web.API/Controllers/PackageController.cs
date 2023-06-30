using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Packages.Create;

namespace Web.API.Controllers;

[Route("packages")]
public class Packages : ApiController
{
    private readonly ISender _mediator;

    public Packages(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePackageCommand command)
    {
        var createPackageResult = await _mediator.Send(command);

        return createPackageResult.Match(
            Reserve => Ok(createPackageResult.Value),
            errors => Problem(errors)
            
            );

    }
    
}
