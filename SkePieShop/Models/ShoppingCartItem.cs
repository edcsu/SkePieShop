namespace SkePieShop.Models;

public class ShoppingCartItem : BaseModel
{
    public Pie Pie { get; set; } = default!;
    
    public int Amount { get; set; }
    
    public string ShoppingCartId { get; set; } = default!;
}