using Domain.Contracts;

namespace Service.Service.Interface;

public interface ICoffeeService
{
    Task<GetAllCoffeesResponseContract> GetAllAsync();
}