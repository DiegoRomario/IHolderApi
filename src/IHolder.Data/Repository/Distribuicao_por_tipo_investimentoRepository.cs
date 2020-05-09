using IHolder.Domain.Entities;
using IHolder.Business.Interfaces.Repositories;
using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Data.Repository
{
    public class Distribuicao_por_tipo_investimentoRepository : RepositoryBase<DistribuicaoPorTipoInvestimento>, IDistribuicaoPorTipoInvestimentoRepository
    {
        public Distribuicao_por_tipo_investimentoRepository(IHolderContext context) : base(context)
        {
        }
    }
}
