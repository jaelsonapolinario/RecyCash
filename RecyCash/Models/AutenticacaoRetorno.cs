namespace RecyCash.Models
{
    public class AutenticacaoRetorno
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public bool Autenticado { get; set; }
                
    }
}