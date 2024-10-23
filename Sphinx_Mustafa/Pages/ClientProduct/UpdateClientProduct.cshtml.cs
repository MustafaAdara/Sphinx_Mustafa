using Application.DTOs;
using Application.interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sphinx_Mustafa.Pages.ClientProduct
{
    public class UpdateClientProductModel : PageModel
    {
        private readonly IClientProductService _clientProductService;
        private readonly IClientService clientService;
        private readonly IProductService productService;


        public UpdateClientProductModel (
            IClientProductService clientProductService,
            IClientService clientService,
            IProductService productService)
        {
            _clientProductService = clientProductService;
            this.clientService = clientService;
            this.productService = productService;
        }
        [BindProperty]
        public ClientProductDto ClientProductDto { get; set; }

        public SelectList ClientList { get; set; }
        public SelectList ProductList { get; set; }

        public async Task<IActionResult> OnGetAsync(string clientId, string productId)
        {
            await PopulateDropdowns();
            if (string.IsNullOrEmpty(productId) || string.IsNullOrEmpty(clientId))
            {
                return NotFound();
            }
                ClientProductDto = await _clientProductService.GetByIdAsync(clientId, productId);
            if (ClientProductDto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            await _clientProductService.UpdateClientProduct(ClientProductDto);
            return RedirectToPage("./GetCLientProducts");
        }
        private async Task PopulateDropdowns()
        {
            var clients = await clientService.GetAllClient();
            ClientList = new SelectList(clients, "Id", "Name");

            var products = await productService.GetAllActiveProducts();
            ProductList = new SelectList(products, "Id", "Name");
        }
    }
}
