﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aula_31_RazorPages_Filmes_8.Data;
using Aula_31_RazorPages_Filmes_8.Modelos;

namespace Aula_31_RazorPages_Filmes_8.Pages.Filmes
{
    public class DetailsModel : PageModel
    {
        private readonly Aula_31_RazorPages_Filmes_8.Data.Aula_31_RazorPages_Filmes_8Context _context;

        public DetailsModel(Aula_31_RazorPages_Filmes_8.Data.Aula_31_RazorPages_Filmes_8Context context)
        {
            _context = context;
        }

      public Aula_31_RazorPages_Filmes_8.Modelos.Filmes Filmes { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Filmes == null)
            {
                return NotFound();
            }

            var filmes = await _context.Filmes.FirstOrDefaultAsync(m => m.ID == id);
            if (filmes == null)
            {
                return NotFound();
            }
            else 
            {
                Filmes = filmes;
            }
            return Page();
        }
    }
}
