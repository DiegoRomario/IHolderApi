using System;

namespace IHolder.Application.ViewModels
{
    public class AtivoViewModel
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get;  set; }
        public string ProdutoDescricao { get; set; }
        public string TipoDescricao { get; set; }
        public string Descricao { get; set; }
        public string Caracteristicas { get; set; }
        public string Ticker { get;  set; }
        public decimal Cotacao { get;  set; }
        public string Situacao { get; set; }
        public Guid UsuarioId { get; set; }

    }
}
