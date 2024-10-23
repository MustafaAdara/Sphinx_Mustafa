using Application.DTOs;
using Application.interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Mustafa.Pages.Products
{
    public class EditProductModel : PageModel
    {
        private readonly IProductService _productService;


        public EditProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductDto ProductDto { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ProductDto = await _productService.GetProductByIdAsync(id);

            if (ProductDto == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _productService.UpdateProduct(ProductDto);
            }
            catch (Exception)
            {
                if (!await ClientExists(ProductDto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        private async Task<bool> ClientExists(string id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return product != null;
        }
    }
}
