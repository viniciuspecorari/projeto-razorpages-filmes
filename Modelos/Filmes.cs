using System.ComponentModel.DataAnnotations;

namespace Aula_31_RazorPages_Filmes_8.Modelos
{
    public class Filmes
    {
        public int ID { get; set; }
        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        public DateTime DatLancamento { get; set; }
        public string Genero { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Pontos { get; set; } = 0;
    }
}
