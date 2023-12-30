using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula_31_RazorPages_Filmes_8.Modelos;

namespace Aula_31_RazorPages_Filmes_8.Data
{
    public class Aula_31_RazorPages_Filmes_8Context : DbContext
    {
        public Aula_31_RazorPages_Filmes_8Context (DbContextOptions<Aula_31_RazorPages_Filmes_8Context> options)
            : base(options)
        {
        }

        public DbSet<Aula_31_RazorPages_Filmes_8.Modelos.Filmes> Filmes { get; set; } = default!;
    }
}
