using Domain.Contracts;

namespace Service.Conversor;

public class CoffeeConsumptionConverter
{
    public CoffeeConsumptionResponseContract ConvertToContract(IList<CoffeeTimeConsumptionResponseContract> contract)
    {
        return new CoffeeConsumptionResponseContract(
            Recommendations: contract);
    }
}