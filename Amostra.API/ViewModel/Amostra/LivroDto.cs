using Amostra.API.Models.Amostra;

namespace Amostra.API.ViewModel.Amostra
{
    public class LivroDto
    {
        public Guid Id { get; set; }
        public DateTime DhCompra { get; set; }
        public string Titulo { get; set; }
        public string Prefacio { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public DateTime DhExtravio { get; set; }
        public bool Extraviado { get; set; }
        public bool Emprestado { get; set; }        
        public bool Ativo { get; set; }
    }
}
