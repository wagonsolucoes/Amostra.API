using System.ComponentModel.DataAnnotations;

namespace Amostra.API.ViewModel
{
    public class Login
    {
        [Required(ErrorMessage = "Usuário requerido")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Senha requerida")]
        public string? Password { get; set; }
    }
}
