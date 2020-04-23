using IHolder.Business.Entities;
using IHolder.Business.Interfaces.Repositories;
using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Data.Repository
{
    public class Distribuicao_por_tipo_investimentoRepository : RepositoryBase<Distribuicao_por_tipo_investimento>, IDistribuicao_por_tipo_investimentoRepository
    {
        public Distribuicao_por_tipo_investimentoRepository(IHolderContext context) : base(context)
        {
        }
    }
}
