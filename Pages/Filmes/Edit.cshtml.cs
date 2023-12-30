using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aula_31_RazorPages_Filmes_8.Data;
using Aula_31_RazorPages_Filmes_8.Modelos;

namespace Aula_31_RazorPages_Filmes_8.Pages.Filmes
{
    public class EditModel : PageModel
    {
        private readonly Aula_31_RazorPages_Filmes_8.Data.Aula_31_RazorPages_Filmes_8Context _context;

        public EditModel(Aula_31_RazorPages_Filmes_8.Data.Aula_31_RazorPages_Filmes_8Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Aula_31_RazorPages_Filmes_8.Modelos.Filmes Filmes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Filmes == null)
            {
                return NotFound();
            }

            var filmes =  await _context.Filmes.FirstOrDefaultAsync(m => m.ID == id);
            if (filmes == null)
            {
                return NotFound();
            }
            Filmes = filmes;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Filmes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmesExists(Filmes.ID))
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

        private bool FilmesExists(int id)
        {
          return (_context.Filmes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
