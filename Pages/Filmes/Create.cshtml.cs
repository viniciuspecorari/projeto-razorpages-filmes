using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aula_31_RazorPages_Filmes_8.Data;
using Aula_31_RazorPages_Filmes_8.Modelos;

namespace Aula_31_RazorPages_Filmes_8.Pages.Filmes
{
    public class CreateModel : PageModel
    {
        private readonly Aula_31_RazorPages_Filmes_8.Data.Aula_31_RazorPages_Filmes_8Context _context;

        public CreateModel(Aula_31_RazorPages_Filmes_8.Data.Aula_31_RazorPages_Filmes_8Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Aula_31_RazorPages_Filmes_8.Modelos.Filmes Filmes { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Filmes == null || Filmes == null)
            {
                return Page();
            }

            _context.Filmes.Add(Filmes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
