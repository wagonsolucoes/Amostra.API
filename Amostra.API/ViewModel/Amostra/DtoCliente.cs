﻿using Amostra.API.Models.Amostra;

namespace Amostra.API.ViewModel.Amostra
{
    public class DtoCliente
    {
        public string CpfCnpj { get; set; }

        public string Nome { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string? Complemento { get; set; }

        public string Bairro { get; set; }

        public string Localidade { get; set; }

        public string Uf { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public bool? Ativo { get; set; }

        public bool? Deleted { get; set; }
    }
}
