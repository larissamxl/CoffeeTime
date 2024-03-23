using Domain.Contracts;

namespace WebApi.Converter;

public class CalculateConverter
{
    public CoffeeConsumptionContract ConvertToContract(CoffeeConsumptionViewModel.CoffeeConsumptionViewModel viewModel)
    {
        return new CoffeeConsumptionContract(
            Code: viewModel.Code,
            Time: viewModel.Time);
    }
}