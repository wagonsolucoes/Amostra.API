using FluentValidation;

namespace Amostra.API.ViewModel.Amostra
{
    public class ClienteVm
    {
        public string Documento { get; set; }

        public string Nome { get; set; }

        public string Cep { get; set; }

        public string Endereco { get; set; }

        public string Numero { get; set; }

        public string? Complemento { get; set; }

        public string Bairro { get; set; }

        public string Municipio { get; set; }

        public string Uf { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}
