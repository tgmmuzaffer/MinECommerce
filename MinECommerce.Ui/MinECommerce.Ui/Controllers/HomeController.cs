using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinECommerce.Service.IServices;
using MinECommerce.Ui.Models;
using System.Diagnostics;

namespace MinECommerce.Ui.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        //[Authorize(Roles = "Admin, Editor")]

        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetProducts();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}