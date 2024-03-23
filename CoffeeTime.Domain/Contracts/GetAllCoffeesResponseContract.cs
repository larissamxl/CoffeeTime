using Domain.Models;

namespace Domain.Contracts;

public record GetAllCoffeesResponseContract(
    IList<Coffee> Coffees);