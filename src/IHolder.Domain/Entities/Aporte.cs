using IHolder.Domain.DomainObjects;
using System;

namespace IHolder.Domain.Entities
{
    public class Aporte : Entity
    {
        public Aporte(Guid ativoId, decimal precoMedio, decimal quantidade, Guid usuarioId, DateTime dataPrimeiroAporte)
        {
            AtivoId = ativoId;
            PrecoMedio = precoMedio;
            Quantidade = quantidade;
            UsuarioId = usuarioId;
            DataPrimeiroAporte = dataPrimeiroAporte;
            CalcularValorAplicado();
        }

        public Guid AtivoId { get; private set; }
        public decimal PrecoMedio { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal ValorAplicado { get; private set; }
        public Guid UsuarioId { get; private set; }
        public DateTime DataPrimeiroAporte { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public Ativo Ativo { get; private set; }
        public Usuario Usuario { get; private set; }


        public void CalcularValorAplicado()
        {
            ValorAplicado = PrecoMedio * Quantidade;
        }
    }
}
