using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleShoppingApplication.Contracts;
using SampleShoppingApplication.Data;

namespace SampleShoppingApplication.Controllers
{

    [Authorize]
    public class ProductController : Controller
    {

        private readonly IBaseRepository<Product> _repo;


        public ProductController(IBaseRepository<Product> repo)
        {
            _repo = repo;
        }
        public IActionResult Create()
        {
            return View(new Product());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);
            await _repo.Create(product);

            TempData["Message"] = $"Successfully added the product {product.Name}";
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmedDelete(Product product)
        {
            await _repo.Delete(product.Id);
            TempData["Message"] = $"Succesfully deleted the product {product.Id}";
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Index()
        {
            var products = await _repo.GetAll();

            return View(products);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _repo.GetOne(id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repo.GetOne(id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);


        }



    }
}
