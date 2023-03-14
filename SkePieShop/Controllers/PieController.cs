using Microsoft.AspNetCore.Mvc;
using SkePieShop.Repositories.CategoryRepo;
using SkePieShop.Repositories.PieRepo;
using SkePieShop.ViewModels;

namespace SkePieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, 
            ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            var model = new PiesListViewModel
            {
                CurrentCategory = "Cheese cakes",
                Pies = _pieRepository.GetAllPies
            };
            
            return View(model);
        }
    }
}