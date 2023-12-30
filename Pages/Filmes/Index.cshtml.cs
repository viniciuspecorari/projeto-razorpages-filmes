using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aula_31_RazorPages_Filmes_8.Data;
using Aula_31_RazorPages_Filmes_8.Modelos;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Aula_31_RazorPages_Filmes_8.Pages.Filmes
{
    public class IndexModel : PageModel
    {
        private readonly Aula_31_RazorPages_Filmes_8.Data.Aula_31_RazorPages_Filmes_8Context _context;

        public IndexModel(Aula_31_RazorPages_Filmes_8.Data.Aula_31_RazorPages_Filmes_8Context context)
        {
            _context = context;
        }

        public IList<Aula_31_RazorPages_Filmes_8.Modelos.Filmes> Filmes { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string TermoBusca {  get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilmeGenero { get; set; }
       
        public SelectList Generos { get; set; }

        public async Task OnGetAsync()
        {

            var filmes = from m in _context.Filmes select m;            

            if (!string.IsNullOrWhiteSpace(TermoBusca))
            {
                filmes = filmes.Where(f => f.Titulo.Contains(TermoBusca));             

            }

            if (!string.IsNullOrWhiteSpace(FilmeGenero))
            {
                filmes = filmes.Where(f => f.Genero == FilmeGenero);
            }

            Generos = new SelectList(await _context.Filmes.Select(o => o.Genero).Distinct().ToListAsync());
            Filmes = await filmes.ToListAsync();



        }
    }
}
