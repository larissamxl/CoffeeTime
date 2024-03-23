using Domain.Contracts;

namespace Service.Service.Interface;

public interface ICalculateService
{
    Task<CoffeeConsumptionResponseContract> CalculateCoffeeConsumption(IList<CoffeeConsumptionContract> contract);
}