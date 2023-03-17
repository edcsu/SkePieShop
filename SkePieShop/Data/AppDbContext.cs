using Microsoft.EntityFrameworkCore;
using SkePieShop.Models;

namespace SkePieShop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Id)
            .IsUnique();
        
        modelBuilder.Entity<Pie>()
            .HasIndex(p => p.Id)
            .IsUnique();
        
        modelBuilder.Entity<ShoppingCartItem>()
            .HasIndex(s => s.Id)
            .IsUnique();
        
        modelBuilder.Entity<Order>()
            .HasIndex(o => o.Id)
            .IsUnique();
        
        modelBuilder.Entity<OrderDetail>()
            .HasIndex(o => o.Id)
            .IsUnique();
    }
    
    public DbSet<Pie> Pies { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderDetail> OrderDetails { get; set; }
}