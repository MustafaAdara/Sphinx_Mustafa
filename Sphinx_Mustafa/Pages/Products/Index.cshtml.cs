using Application.DTOs;
using Application.interfaces;
using Application.Services;
using Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Mustafa.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<ProductDto> Products { get; set; } 
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 5;
        public async Task OnGetAsync(int pageNumber = 1)
        {
            CurrentPage = pageNumber;
             
            var TotalProduct = await _productService.CountProducts();
            TotalPages = (int)Math.Ceiling(TotalProduct / (double)PageSize);

            Products = await _productService.GetProductWithPaging(pageNumber, PageSize);

        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToPage();
        }
    }
}
