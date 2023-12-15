using Amostra.API.Models.Amostra;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Amostra.API.ViewModel.Amostra
{
    public class LivroValidator : AbstractValidator<LivroVm>
    {
        public LivroValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id requerido.");
            RuleFor(x => x.DhCompra).NotEmpty().WithMessage("DhCompra requerido.");
            RuleFor(x => x.Titulo).Must(x => x.Length <= 350).WithMessage("Titulo, comprimento máximo de 350 caracteres.");
            RuleFor(x => x.Prefacio).Must(x => x.Length <= 8000).WithMessage("Prefacio, comprimento máximo de 8000 caracteres.");
            RuleFor(x => x.Autor).Must(x => x.Length <= 350).WithMessage("Autor, comprimento máximo de 350 caracteres.");
            RuleFor(x => x.Titulo).Must(x => x.Length <= 350).WithMessage("Titulo, comprimento máximo de 350 caracteres.");
            RuleFor(x => x.Editora).Must(x => x.Length <= 350).WithMessage("Editora, comprimento máximo de 350 caracteres.");
            RuleFor(x => x.Ativo).NotEmpty().WithMessage("Ativo requerido.");
        }
    }
}
