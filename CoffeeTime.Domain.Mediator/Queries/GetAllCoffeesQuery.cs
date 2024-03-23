using Domain.Contracts;
using MediatR;

namespace Mediator.Queries;

public record GetAllCoffeesQuery() : IRequest<GetAllCoffeesResponseContract>;