using Application.DTOs;
using Application.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Mustafa.Pages.Client
{
    public class DeleteClientModel : PageModel
    {
        private readonly IClientService _clientService;
         
        public ClientDto ClientDto { get; set; }

        public DeleteClientModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
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

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            await _clientService.DeleteClient(id);
            return RedirectToPage();
        }
    }
}
