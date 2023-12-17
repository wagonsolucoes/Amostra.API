using Amostra.API.Models.Amostra;

namespace Amostra.API.ViewModel.Amostra
{
    public class EmprestadoDto
    {
        public Guid Id { get; set; }
        public string IdCliente { get; set; }
        public Guid IdLivro { get; set; }
        public DateTime Dh { get; set; }
        public DateTime? DhDevolucao { get; set; }
        public int DiasEmprestado { get; set; }
        public bool Ativo { get; set; }
        public ClienteDto Cliente { get; set; }
        public LivroDto Livro { get; set; }
    }
}
