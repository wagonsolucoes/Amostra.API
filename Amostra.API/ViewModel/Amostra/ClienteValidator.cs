using FluentValidation;
using System.Text.RegularExpressions;

namespace Amostra.API.ViewModel.Amostra
{
    public class ClienteValidator : AbstractValidator<ClienteVm>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Documento).Must(x => x.Length == 10 || x.Length == 11 && IsCpf(x) || x.Length == 14 && IsCnpj(x)).WithMessage("Documento inválido.");
            RuleFor(x => x.Nome).Must(x => x.Length <= 250).WithMessage("Nome, comprimento máximo de 250 caracteres.");
            RuleFor(x => x.Cep).Must(x => x.Length == 8).WithMessage("Cep, comprimento máximo de 8 caracteres.");
            RuleFor(x => x.Endereco).Must(x => x.Length <= 350).WithMessage("Logradouro, comprimento máximo de 350 caracteres.");
            RuleFor(x => x.Numero).Must(x => x.Length <= 100).WithMessage("Número, comprimento máximo de 100 caracteres.");
            RuleFor(x => x.Complemento).Must(x => x.Length >= 0 && x.Length <= 250).WithMessage("Número, comprimento mínimo de 0 e máximo de 250 caracteres.");
            RuleFor(x => x.Bairro).Must(x => x.Length <= 250).WithMessage("Bairro, comprimento máximo de 250 caracteres.");
            RuleFor(x => x.Municipio).Must(x => x.Length <= 250).WithMessage("Localidade, comprimento máximo de 250 caracteres.");
            RuleFor(x => x.Uf).Must(x => x.Length <= 250).WithMessage("Uf, comprimento máximo de 2 caracteres.");
            RuleFor(x => x.Email).Must(x => x.Length <= 350 && IsValidEmail(x)).WithMessage("Email inválido.");
            RuleFor(x => x.Telefone).Must(x => x.Length <= 250).WithMessage("Telefone, comprimento máximo de 2 caracteres.");
        }

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
