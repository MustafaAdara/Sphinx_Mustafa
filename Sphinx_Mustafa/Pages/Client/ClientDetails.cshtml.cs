using Application.DTOs;
using Application.interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Mustafa.Pages.Client
{
    public class ClientDetailsModel : PageModel
    {
        private readonly IClientService clientService;

        public ClientDetailsModel(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public ClientDetailsDto Client { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Client = await clientService.GetClientDetails(id);
            if (Client == null)
            {
                return NotFound();
            }
            return Page();

        }
    }
}
