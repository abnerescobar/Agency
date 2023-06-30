
using Application.Reserves.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Web.API.Controllers;

[Route("reservers")]
public class Reserves : ApiController
{
    private readonly ISender _mediator;

    public Reserves(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReserveCommand command)
    {
        var createReserveResult = await _mediator.Send(command);

        return createReserveResult.Match(
            Reserve => Ok(createReserveResult.Value),
            errors => Problem(errors)
        );
    }
}
