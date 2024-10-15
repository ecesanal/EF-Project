using EFProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFProject.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _repository;
        public HomeController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.Products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repository.CreateProduct(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_repository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _repository.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Index");

        }
    }
}
