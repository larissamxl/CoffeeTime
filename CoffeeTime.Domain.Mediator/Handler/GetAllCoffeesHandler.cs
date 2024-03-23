using Domain.Contracts;
using Mediator.Queries;
using MediatR;
using Service.Service.Interface;

namespace Mediator.Handler;

public class GetAllCoffeesHandler : IRequestHandler<GetAllCoffeesQuery, GetAllCoffeesResponseContract>
{
    private readonly ICoffeeService service;

    public GetAllCoffeesHandler(ICoffeeService service)
    {
        this.service = service;
    }

    public Task<GetAllCoffeesResponseContract> Handle(GetAllCoffeesQuery query, CancellationToken cancellationToken)
    {
        return service.GetAllAsync();
    }
}