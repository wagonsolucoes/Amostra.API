using Amostra.API.Models.Amostra;

namespace Amostra.API.ViewModel.Amostra
{
    public class DtoCliente
    {
        public int ttRows { get; set; }
        public List<Cliente> lst  { get; set; }
        public string msgEx {  get; set; }
    }
}
