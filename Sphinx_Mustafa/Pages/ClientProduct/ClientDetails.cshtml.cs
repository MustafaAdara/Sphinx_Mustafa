using Application.DTOs;
using Application.interfaces;
//using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sphinx_Mustafa.Pages.ClientProduct
{
    public class ClientDetailsModel : PageModel
    {
        private readonly IClientService _clientService;

        public ClientDetailsModel(IClientService clientService)
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
