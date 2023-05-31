using System.Collections.Generic;
using System.Linq;
using apiBancario.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace apiBancario.Pages.Clientes
{
    public class ListarModel : PageModel
    {
        private readonly BancoDbContext _context;

        public ListarModel(BancoDbContext context)
        {
            _context = context;
        }

        public List<Cliente> Clientes { get; set; }

        public void OnGet()
        {
            // Busca os clientes no banco de dados
            Clientes = _context.Clientes.ToList();
        }
    }
}
