using Application.DTOs;
using Application.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Mustafa.Pages.Client
{
    public class AddClientModel : PageModel
    {
        private readonly IClientService _clientService;

        [BindProperty]
        public ClientDto ClientDto { get; set; }

        public AddClientModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _clientService.AddClient(ClientDto);
            return RedirectToPage("Index");
        }
    }
}
