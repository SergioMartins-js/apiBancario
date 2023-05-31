using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiBancario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace apiBancario.Pages.Clientes
{
    public class CadastrarModel : PageModel
    {
        [BindProperty]
        public Cliente Cliente { get; set; }

        public void OnGet()
        {
            Cliente = new Cliente();
        }

        public IActionResult OnPost()
        {
            // Lógica para salvar o cliente no banco de dados
            // ...

            return RedirectToPage("Listar");
        }
    }
}
