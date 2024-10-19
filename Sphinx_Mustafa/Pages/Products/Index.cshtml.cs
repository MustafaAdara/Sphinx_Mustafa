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
        public async Task OnGetAsync(int page = 1, int pageSize = 10)
        {
            CurrentPage = page;

            Products = await _productService.GetProductWithPaging(page, pageSize);
             
            var TotalProduct = await _productService.CountProducts();
            TotalPages = (int)Math.Ceiling(TotalProduct / (double)pageSize);
        }
    }
}
