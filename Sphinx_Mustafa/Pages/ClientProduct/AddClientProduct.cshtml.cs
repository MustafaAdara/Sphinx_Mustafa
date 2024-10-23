using Application.DTOs;
using Application.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sphinx_Mustafa.Pages.ClientProduct
{
    public class AddClientProductModel : PageModel
    {
        private readonly IClientProductService _clientProductService;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;

        public AddClientProductModel(
            IClientProductService clientProductService,
            IClientService clientService,
            IProductService productService)
        {
            _clientProductService = clientProductService;
            _clientService = clientService;
            _productService = productService;
        }

        [BindProperty]
        public ClientProductDto ClientProduct { get; set; }

        public SelectList ClientList { get; set; }
        public SelectList ProductList { get; set; }

        public async Task OnGetAsync()
        {
            await PopulateDropdowns();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                await _clientProductService.AddClientWithActiveProduct(ClientProduct);
                return RedirectToPage("./GetCLientProducts");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await PopulateDropdowns();
                return Page();
            }
        }

        private async Task PopulateDropdowns()
        {
            var clients = await _clientService.GetAllClient();
            ClientList = new SelectList(clients, "Id", "Name");

            var products = await _productService.GetAllActiveProducts();
            ProductList = new SelectList(products, "Id", "Name");
        }
    }
}
