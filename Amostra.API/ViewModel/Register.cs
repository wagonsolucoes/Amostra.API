using System.ComponentModel.DataAnnotations;

namespace Amostra.API.ViewModel
{
    public class Register
    {
        [Required(ErrorMessage = "Usuário requerido")]
        public string? Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email requerido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha requerida")]
        public string? Password { get; set; }
    }
}
