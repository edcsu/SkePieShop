using Microsoft.AspNetCore.Mvc;
using SkePieShop.Models;
using SkePieShop.Repositories.CategoryRepo;
using SkePieShop.Repositories.PieRepo;
using SkePieShop.ViewModels;

namespace SkePieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<PieController> _logger;

        public PieController(IPieRepository pieRepository, 
            ICategoryRepository categoryRepository, 
            ILogger<PieController> logger)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.GetAllPies.OrderBy(p => p.Id);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.GetAllPies.Where(p => p.Category.Name == category)
                    .OrderBy(p => p.Id);
                
                currentCategory = _categoryRepository.AllCategories
                    .FirstOrDefault(c => c.Name == category)!.Name;
            }

            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(Guid id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie is null)
            {
                _logger.LogInformation("Pie with id: {ID} not found", id);
                return NotFound();
            }

            return View(pie);
        }
    }
}