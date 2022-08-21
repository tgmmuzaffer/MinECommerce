using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MinECommerce.Entity;
using MinECommerce.Service.Dtos;
using MinECommerce.Service.IServices;
using System.Diagnostics;

namespace MinECommerce.Ui.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFeatureDescriptionService _featureDescriptionService;
        private readonly IDiscountService _discountService;
        private readonly IFeatureService _featureService;
        public ProductController(IProductService productService, IFeatureDescriptionService featureDescriptionService, IDiscountService discountService, IFeatureService featureService)
        {
            _productService = productService;
            _featureDescriptionService = featureDescriptionService;
            _discountService = discountService;
            _featureService = featureService;
        }

        public IActionResult MasterPage()
        {
            return View();
        }


        public async Task<IActionResult> GetFeatureDescriptions()
        {
            var list = await _featureDescriptionService.GetFeaturesDescription();
            return View(list);
        }

        public IActionResult AddFeatureDescription()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFeatureDescription(FeatureDescription featureDescription)
        {
            var result = await _featureDescriptionService.CreateFeatureDescription(featureDescription);
            if (result)
            {
                return RedirectToAction(nameof(GetFeatureDescriptions));
            }
            return View(nameof(GetFeatureDescriptions));
        }

        [HttpGet]
        public async Task<IActionResult> GetFeatures()
        {
            var features = await _featureService.GetFeatures();
            return View(features);
        }
        [HttpGet]
        public async Task<IActionResult> AddFeature()
        {
            var featureDescList = await _featureDescriptionService.GetFeaturesDescription();
            if (featureDescList != null && featureDescList.Count > 0)
            {
                List<SelectListItem> featDescList = new();

                foreach (var item in featureDescList)
                {
                    featDescList.Add(new SelectListItem() { Text = item.Description, Value = item.Id.ToString(), Selected = (item.Id == 1) });
                }
                ViewBag.featDescList = featDescList;
            }
            var result = await _discountService.GetDiscounts();
            if (result != null && result.Count > 0)
            {
                List<SelectListItem> discountlist = new();

                foreach (var item in result)
                {
                    discountlist.Add(new SelectListItem() { Text = item.Rate.ToString(), Value = item.Id.ToString(), Selected = (item.Id == 1) });
                }
                ViewBag.discountlist = discountlist;
            }

            return View();
        }

        
        public async Task<IActionResult> CreateFeature(FeatureDto featureDto)
        {
            var featureDesc= await _featureDescriptionService.GetFeaturesDescription();
            featureDesc=featureDesc.Where(a=>featureDto.FeatureDescriptionIds.Contains(a.Id)).ToList();
            var discounts= await _discountService.GetDiscount(featureDto.DiscountId);
            Feature feature = new()
            {
                Name = featureDto.Name,
                DiscountId = featureDto.DiscountId,
                Discount = discounts,
                FeatureDescriptions = featureDesc,

            };

            var result = await _featureService.CreateFeature(feature);
            if (result)
                return RedirectToAction(nameof(AddProduct));
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscount()
        {
            var discounts = await _discountService.GetDiscounts();
            return View(discounts);
        }
        [HttpPost]

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var result = await _featureService.GetFeatures();
            if (result != null && result.Count > 0)
            {
                List<SelectListItem> featureList = new();

                foreach (var item in result)
                {
                    featureList.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString(), Selected = (item.Id == 1) });
                }
                ViewBag.featureList = featureList;
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products =await _productService.GetProducts();
            return View(products);
        }
    }
}
