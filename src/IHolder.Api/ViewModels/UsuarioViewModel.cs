using IHolder.Api.ViewModels.Base;
using IHolder.Domain.Enumerators;
using System;

namespace IHolder.Api.ViewModels
{
    public class UsuarioViewModel 
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EGenero Genero { get; set; }
    }
}
