using Application.DTOs;
using Application.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Mustafa.Pages.Client
{
    public class EditClientModel : PageModel
    {
        private readonly IClientService _clientService;

        public EditClientModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        [BindProperty]
        public ClientDto ClientDto { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClientDto = await _clientService.GetClientById(id);

            if (ClientDto == null)
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

            try
            {
                await _clientService.UpdateClient(ClientDto);
            }
            catch (Exception)
            {
                if (!await ClientExists(ClientDto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> ClientExists(string id)
        {
            var client = await _clientService.GetClientById(id);
            return client != null;
        }
    }
}
