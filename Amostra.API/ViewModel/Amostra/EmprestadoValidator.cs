using Amostra.API.Models.Amostra;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Amostra.API.ViewModel.Amostra
{
    public class EmprestadoValidator : AbstractValidator<EmprestadoVm>
    {
        public EmprestadoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id requerido.");
            RuleFor(x => x.IdCliente).NotEmpty().WithMessage("IdCliente requerido.");
            RuleFor(x => x.IdLivro).NotEmpty().WithMessage("IdLivro requerido.");
            RuleFor(x => x.Dh).NotEmpty().WithMessage("Dh requerido.");
            RuleFor(x => x.Ativo).NotEmpty().WithMessage("Ativo requerido.");
        }
    }
}
