namespace Domain.Contracts;

public record CoffeeConsumptionResponseContract(
    IList<CoffeeTimeConsumptionResponseContract> Recommendations);