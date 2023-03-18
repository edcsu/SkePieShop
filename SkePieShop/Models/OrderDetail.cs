using System.ComponentModel.DataAnnotations.Schema;

namespace SkePieShop.Models;

public class OrderDetail : BaseModel
{
    public Guid OrderId { get; set; }
    
    public Guid PieId { get; set; }
    
    public int Amount { get; set; }
    
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public virtual Pie Pie { get; set; } = default!;

    public virtual Order Order { get; set; } = default!;
}