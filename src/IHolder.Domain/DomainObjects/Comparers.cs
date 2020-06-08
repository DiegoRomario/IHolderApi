using IHolder.Domain.Entities;
using System.Collections.Generic;
namespace IHolder.Domain.DomainObjects
{
    public class AtivoAporteComparer : IEqualityComparer<Aporte>
    {
        public bool Equals(Aporte x, Aporte y)
        {
            return x.Id == y.Id;
        }

        int IEqualityComparer<Aporte>.GetHashCode(Aporte aporte)
        {
            return aporte.Id.GetHashCode();
        }
    }


    public class ProdutoAporteComparer : IEqualityComparer<Aporte>
    {
        public bool Equals(Aporte x, Aporte y)
        {
            return x.Id == y.Id;
        }

        int IEqualityComparer<Aporte>.GetHashCode(Aporte aporte)
        {
            return aporte.Id.GetHashCode();
        }
    }

    public class TipoInvestimentoAporteComparer : IEqualityComparer<Aporte>
    {
        public bool Equals(Aporte x, Aporte y)
        {
            return x.Id == y.Id;
        }

        int IEqualityComparer<Aporte>.GetHashCode(Aporte aporte)
        {
            return aporte.Id.GetHashCode();
        }
    }
}
