using FluentValidation;

namespace Amostra.API.ViewModel.Amostra
{
    public class Filter
    {
        public string TermoBusca { get; set; }
        public int IniciaEm { get; set; }
        public int QtdLinhas { get; set; }
    }
}
