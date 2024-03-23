namespace Domain.Contracts;

public record CoffeeTimeConsumptionResponseContract(
    string Name,
    string Code,
    double Wait);