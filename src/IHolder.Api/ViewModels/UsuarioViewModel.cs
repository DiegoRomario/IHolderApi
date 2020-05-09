using IHolder.Api.ViewModels.Base;
using IHolder.Domain.Enumerators;
using System;

namespace IHolder.Api.ViewModels
{
    public class UsuarioViewModel : Entidade_baseViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public DateTime Data_nascimento { get; set; }
        public EGenero Genero { get; set; }
        public DateTime Data_inclusao { get; set; }
        public DateTime? Data_alteracao { get; set; }
        public string Token { get; set; }
        public DateTime Expira_em { get; set; }
    }
}
