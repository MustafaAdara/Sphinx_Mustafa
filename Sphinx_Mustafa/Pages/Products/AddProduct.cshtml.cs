using Application.DTOs;
using Application.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Mustafa.Pages.Products
{
    public class AddProductModel : PageModel
    {
        private readonly IProductService _productService;

        public AddProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductDto ProductDto { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _productService.AddProduct(ProductDto);
            return RedirectToAction("Index");
        }
    }
}
