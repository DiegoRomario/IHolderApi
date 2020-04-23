using IHolder.Business.Entities.Base;
using System;

namespace IHolder.Business.Entities
{
    public class Aporte : Entidade_base
    {

        public Aporte(Guid ativo_id, decimal preco_medio, decimal quantidade, Guid usuario_id, DateTime data_aporte)
        {
            Ativo_id = ativo_id;
            Preco_medio = preco_medio;
            Quantidade = quantidade;
            Usuario_id = usuario_id;
            Data_aporte = data_aporte;
            CalcularPrecoTotal();
        }

        public Guid Ativo_id { get; private set; }
        public decimal Preco_medio { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal Preco_total { get; private set; }
        public Guid Usuario_id { get; private set; }
        public DateTime Data_aporte { get; private set; }
        public DateTime Data_inclusao { get; private set; }
        public DateTime? Data_alteracao { get; private set; }
        public Ativo Ativo { get; private set; }
        public Usuario Usuario { get; private set; }


        public void CalcularPrecoTotal()
        {
            Preco_total = Preco_medio * Quantidade;
        }
    }
}
