using System.ComponentModel.DataAnnotations;

namespace RecyCash.Models
{
    public class Autenticacao
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}