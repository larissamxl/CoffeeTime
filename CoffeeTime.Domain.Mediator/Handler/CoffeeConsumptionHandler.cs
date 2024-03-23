using Domain.Contracts;
using Mediator.Commands;
using MediatR;
using Service.Service.Interface;

namespace Mediator.Handler;

public class CoffeeConsumptionHandler : IRequestHandler<CoffeeConsumptionCommand, CoffeeConsumptionResponseContract>
{
    private readonly ICalculateService service;

    public CoffeeConsumptionHandler(ICalculateService service)
    {
        this.service = service;
    }

    public Task<CoffeeConsumptionResponseContract> Handle(CoffeeConsumptionCommand command, CancellationToken cancellationToken)
    {
        return service.CalculateCoffeeConsumption(command.contract);
    }
}