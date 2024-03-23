using Domain.Contracts;
using Microsoft.Extensions.Logging;
using Service.Conversor;
using Service.Service.Interface;

namespace Service.Service;

public class CalculateService : ICalculateService
{
    public readonly CoffeeConsumptionConverter converter;
    public readonly ILogger<CalculateService> logger;
    public CoffeeService coffeeService;

    private IList<CoffeeTimeConsumptionResponseContract> coffeeTimeList =
        new List<CoffeeTimeConsumptionResponseContract>();

    public CalculateService(
        ILogger<CalculateService> logger,
        CoffeeConsumptionConverter converter,
        CoffeeService coffeeService
    )
    {
        this.logger = logger;
        this.converter = converter;
        this.coffeeService = coffeeService;
    }

    public async Task<CoffeeConsumptionResponseContract> CalculateCoffeeConsumption(
        IList<CoffeeConsumptionContract> contract)
    {
        try
        {
            logger.LogInformation("Getting coffee list");
            var coffeesList = coffeeService.CreateCoffeesList();
            var sum = 0.0;
            double decayConstant = 0.0023104906;

            var coffeeQuantity = new Dictionary<string, int>()
            {
                { "blk", 95 },
                { "esp", 63 },
                { "cap", 63 },
                { "lat", 63 },
                { "wht", 63 },
                { "cld", 120 },
                { "dec", 5 },
            };

            logger.LogInformation("Calculating coffee consumption");
            
            foreach (var coffeeConsumption in contract)
            {
                if (!coffeeQuantity.ContainsKey(coffeeConsumption.Code))
                {
                    throw new Exception("unidentified coffee");
                }

                var remainingQuantity = CalculateDecay(coffeeQuantity[$"{coffeeConsumption.Code}"],
                    coffeeConsumption.Time, decayConstant);
                sum += remainingQuantity;
            }

            foreach (var coffeeConsumption in contract)
            {
                var name = coffeesList.FirstOrDefault(x => x.Code == coffeeConsumption.Code)?.Name ?? null;
                var time = CalculateTime(sum, coffeeQuantity[$"{coffeeConsumption.Code}"], decayConstant);
                
                if (time < 0)
                {
                    time = 0.0;
                    logger.LogInformation($"the user could have already drunk this type of coffee {time*-1} minutes ago");
                }

                coffeeTimeList.Add(new CoffeeTimeConsumptionResponseContract(Name: $"{name}",
                    Code: $"{coffeeConsumption.Code}", Wait: time));
            }

            var contractCoffeeTime = converter.ConvertToContract(coffeeTimeList);
            return contractCoffeeTime;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"{ex.Message}");
            return null;
        }
    }

    private double CalculateDecay(double initialQuantity, double time, double decayConstant)
    {
        double remainingQuantity = initialQuantity * Math.Exp(-decayConstant * time);
        return remainingQuantity;
    }

    private double CalculateTime(double initialQuantity, int coffeeLevel, double decayConstant)
    {
        double time = Math.Log((175 - coffeeLevel) / initialQuantity) / (-decayConstant);
        return time;
    }
}