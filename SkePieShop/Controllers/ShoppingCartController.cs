using Microsoft.AspNetCore.Mvc;
using SkePieShop.Models;
using SkePieShop.Repositories.PieRepo;
using SkePieShop.ViewModels;

namespace SkePieShop.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IPieRepository _pieRepository;
    private readonly ShoppingCart _shoppingCart;
    private readonly ILogger<ShoppingCartController> _logger;

    public ShoppingCartController(IPieRepository pieRepository, 
        ShoppingCart shoppingCart, 
        ILogger<ShoppingCartController> logger)
    {
        _pieRepository = pieRepository;
        _shoppingCart = shoppingCart;
        _logger = logger;
    }

    public ViewResult Index()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        var shoppingCartViewModel = new ShoppingCartViewModel
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };

        return View(shoppingCartViewModel);
    }

    public RedirectToActionResult AddToShoppingCart(Guid pieId)
    {
        var selectedPie = _pieRepository.GetAllPies.FirstOrDefault(p => p.Id == pieId);

        if (selectedPie != null)
        {
            _shoppingCart.AddToCart(selectedPie, 1);
            _logger.LogInformation("Pie with id: {PieId} added to cart", pieId);
        }
        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCart(Guid pieId)
    {
        var selectedPie = _pieRepository.GetAllPies.FirstOrDefault(p => p.Id == pieId);

        if (selectedPie != null)
        {
            _shoppingCart.RemoveFromCart(selectedPie);
            _logger.LogInformation("Pie with id: {PieId} removed from cart", pieId);
        }
        return RedirectToAction("Index");
    }
}