using SkePieShop.Models;

namespace SkePieShop.Repositories.OrderRepo;

public interface IOrderRepository
{
    void CreateOrder(Order order);
}