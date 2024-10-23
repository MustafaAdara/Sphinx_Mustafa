using Application.DTOs;
using Application.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Mustafa.Pages.ClientProduct
{
    public class GetCLientProducts : PageModel
    {
        private readonly IClientProductService clientProduct;

        public GetCLientProducts(IClientProductService clientProduct)
        {
            this.clientProduct = clientProduct;
        }
        public IEnumerable<ClientProductDto>? ClientProducts { get; set; } = new List<ClientProductDto>();

        public async Task OnGetAsync()
        {
            ClientProducts = await clientProduct.GetAllWithAllRef();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string clientId, string productId)
        {
            await clientProduct.DeleteAsync(clientId, productId);
            return RedirectToPage();
        }
    }
}
