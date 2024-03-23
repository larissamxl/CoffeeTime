using Domain.Contracts;
using MediatR;

namespace Mediator.Commands;

public record CoffeeConsumptionCommand(IList<CoffeeConsumptionContract> contract) : IRequest<CoffeeConsumptionResponseContract>;