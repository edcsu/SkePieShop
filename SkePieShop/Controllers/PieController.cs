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
        private readonly ILogger<PieController> _logger;

        public PieController(IPieRepository pieRepository, 
            ICategoryRepository categoryRepository, 
            ILogger<PieController> logger)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            _logger = logger;
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