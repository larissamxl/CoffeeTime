using Domain.Contracts;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Service.Conversor;
using Service.Service.Interface;

namespace Service.Service;

public class CoffeeService : ICoffeeService
{
    
    public readonly CooffeesConverter converter;
    public readonly ILogger<CoffeeService> logger;
    
    public CoffeeService (ILogger<CoffeeService> logger, CooffeesConverter converter)
    {
        this.logger = logger;
        this.converter = converter;
    }

    public async Task<GetAllCoffeesResponseContract> GetAllAsync()
    {
        try
        {
            var coffeesList = CreateCoffeesList();
            logger.LogInformation("Getting coffee list");
            var coffees = coffeesList;
            var contract = converter.ConvertToContract(coffees);
            return contract;
        }
        catch(Exception ex)
        {
            logger.LogError(ex, $"{ex.Message}");
            //throw new NotImplementedException();
            return null;
        }
    }

    public IList<Coffee> CreateCoffeesList()
    {
        IList<Coffee> coffeesList = new List<Coffee>();
        
        coffeesList.Add(new Coffee(name:"Black Coffe", code:"blk"));
        coffeesList.Add(new Coffee(name:"Espresso", code:"esp"));
        coffeesList.Add(new Coffee(name:"Cappuccino", code:"cap"));
        coffeesList.Add(new Coffee(name:"Latte", code:"lat"));
        coffeesList.Add(new Coffee(name:"Flat White", code:"wht"));
        coffeesList.Add(new Coffee(name:"Cold Brew", code:"cld"));
        coffeesList.Add(new Coffee(name:"Decaf Coffee", code:"dec"));
        return coffeesList;
    }
}