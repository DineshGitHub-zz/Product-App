using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWebApp.Models;
using ProductWebApp.Repository;
using ProductWebApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using static ProductWebApp.Utility.Helper;

namespace ProductWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [Route("")]
        [HttpGet,ActionName("List")]
        public IActionResult GetProducts()
        {
           List<Product> products =  _productRepository.GetAllProducts().ToList();
            return View("Products", products);
        }

        [HttpGet]
        [NoDirectAccess]
        public IActionResult AddOrUpdate(int id = 0)
        {
            if (id == 0)
                return View(new Product());
            else
            {
                var productModel = _productRepository.GetProduct(id);
                if (productModel == null)
                {
                    return NotFound();
                }
                return View(productModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _productRepository.AddProduct(product);
                }
                //Update
                else
                {
                    _productRepository.UpdateProduct(product);
                }
                return Json(new { isValid = true,isCreate = id == 0, html = Helper.RenderRazorViewToString(this, "ProductList", _productRepository.GetAllProducts()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrUpdate", product) });
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productRepository.GetProduct((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.DeleteProduct(id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "ProductList", _productRepository.GetAllProducts().ToList()) });
        }
    }
}
