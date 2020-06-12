using IHolder.Domain.Entities;
using System.Collections.Generic;
namespace IHolder.Domain.DomainObjects
{
    public class AtivoEmCarteiraComparer : IEqualityComparer<AtivoEmCarteira>
    {
        public bool Equals(AtivoEmCarteira x, AtivoEmCarteira y)
        {
            return x.Id == y.Id;
        }

        int IEqualityComparer<AtivoEmCarteira>.GetHashCode(AtivoEmCarteira ativoEmCarteira)
        {
            return ativoEmCarteira.Id.GetHashCode();
        }
    }


    public class ProdutoAtivoEmCarteiraComparer : IEqualityComparer<AtivoEmCarteira>
    {
        public bool Equals(AtivoEmCarteira x, AtivoEmCarteira y)
        {
            return x.Id == y.Id;
        }

        int IEqualityComparer<AtivoEmCarteira>.GetHashCode(AtivoEmCarteira ativoEmCarteira)
        {
            return ativoEmCarteira.Id.GetHashCode();
        }
    }

    public class TipoInvestimentoAtivoEmCarteiraComparer : IEqualityComparer<AtivoEmCarteira>
    {
        public bool Equals(AtivoEmCarteira x, AtivoEmCarteira y)
        {
            return x.Id == y.Id;
        }

        int IEqualityComparer<AtivoEmCarteira>.GetHashCode(AtivoEmCarteira ativoEmCarteira)
        {
            return ativoEmCarteira.Id.GetHashCode();
        }
    }
}
