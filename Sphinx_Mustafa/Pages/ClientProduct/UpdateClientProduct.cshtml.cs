using Application.DTOs;
using Application.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Mustafa.Pages.ClientProduct
{
    public class UpdateClientProductModel : PageModel
    {
        private readonly IClientProductService _clientProductService;

        [BindProperty]
        public ClientProductDto ClientProductDto { get; set; }

        public UpdateClientProductModel (IClientProductService clientProductService)
        {
            _clientProductService = clientProductService;
        }

        public async Task<IActionResult> OnGetAsync(string clientId, string productId)
        {
            ClientProductDto = await _clientProductService.GetByIdAsync(clientId, productId);
            if (ClientProductDto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _clientProductService.UpdateClientProduct(ClientProductDto);
            return RedirectToPage("/Clients/Details", new { id = ClientProductDto.ClientId });
        }
    }
}
