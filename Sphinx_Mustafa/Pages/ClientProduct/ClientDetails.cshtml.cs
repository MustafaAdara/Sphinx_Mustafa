using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Mustafa.Pages.ClientProduct
{
    public class ClientDetailsModel : PageModel
    {
        private readonly ClientService _clientService;

        public ClientDetailsModel(ClientService clientService)
        {
            _clientService = clientService;
        }

        public ClientDetailsDto Client { get; set; }

        public async Task<IActionResult> OnGetAsync(string clientId)
        {
            Client = await _clientService.GetClientDetails(clientId);
            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
