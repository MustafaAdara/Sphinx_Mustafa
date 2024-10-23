using Application.DTOs;
using Application.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sphinx_Mustafa.Pages.Client
{
    public class IndexModel : PageModel
    {
        private readonly IClientService _clientService;
        public IndexModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IEnumerable<ClientDto> Clients { get; set; }

        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; }
        public async Task OnGetAsync(int pageNumber = 1)
        {
            CurrentPage = pageNumber;
            var totalClients = await _clientService.CountClients();
            TotalPages = (int)Math.Ceiling(totalClients / (double)PageSize);

            Clients = await _clientService.GetAllPagedClient(CurrentPage, PageSize);

        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            await _clientService.DeleteClient(id);
            return RedirectToPage();
        }
    }
}
