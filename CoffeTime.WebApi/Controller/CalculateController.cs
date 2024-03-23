using Mediator.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Converter;

namespace WebApi.Controller;

[Route("v1/[controller]")]
[ApiController]
public class CalculateController : ControllerBase
{
    private readonly IMediator mediador;
    private readonly CalculateConverter converter;

    public CalculateController(
        IMediator mediator,
        CalculateConverter converter)
    {
        this.mediador = mediator;
        this.converter = converter;
    }

    [HttpPost]
    public async Task<IActionResult> CoffeeConsumption(IList<CoffeeConsumptionViewModel.CoffeeConsumptionViewModel> viewModel)
    {
        var contract = viewModel.Select(converter.ConvertToContract).ToList();
        var request = new CoffeeConsumptionCommand(contract);
        var result = await mediador.Send(request, cancellationToken: default);

        return Ok(result);
    }
}