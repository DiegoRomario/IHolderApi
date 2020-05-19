using System;
namespace IHolder.Application.ViewModels
{
    public class UsuarioAutenticadoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
