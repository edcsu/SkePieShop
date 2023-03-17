using SkePieShop.Data;
using SkePieShop.Models;

namespace SkePieShop.Repositories.OrderRepo;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;
    private readonly ShoppingCart _shoppingCart;


    public OrderRepository(AppDbContext dbContext, 
        ShoppingCart shoppingCart)
    {
        _dbContext = dbContext;
        _shoppingCart = shoppingCart;
    }


    public void CreateOrder(Order order)
    {
        order.OrderPlaced = DateTime.Now;

        _dbContext.Orders.Add(order);

        var shoppingCartItems = _shoppingCart.ShoppingCartItems;

        foreach (var shoppingCartItem in shoppingCartItems)
        {
            var orderDetail = new OrderDetail()
            {
                Amount = shoppingCartItem.Amount,
                PieId = shoppingCartItem.Pie.Id,
                OrderId = order.Id,
                Price = shoppingCartItem.Pie.Price
            };

            _dbContext.OrderDetails.Add(orderDetail);
        }

        _dbContext.SaveChanges();
    }
}