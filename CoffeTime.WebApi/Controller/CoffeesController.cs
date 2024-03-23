using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[Route("v1/[controller]")]
[ApiController]
public class CoffeesController : ControllerBase
{
    private readonly IMediator mediador;

    public CoffeesController(
        IMediator mediator)
    {
        this.mediador = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllCoffeesQuery();
        var result = await mediador.Send(request, cancellationToken: default);

        return Ok(result);
    }
}