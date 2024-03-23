using Domain.Contracts;
using Domain.Models;

namespace Service.Conversor;

public class CooffeesConverter
{
    public GetAllCoffeesResponseContract ConvertToContract(IList<Coffee> entity)
    {
        return new GetAllCoffeesResponseContract(
            Coffees: entity);
    }
}