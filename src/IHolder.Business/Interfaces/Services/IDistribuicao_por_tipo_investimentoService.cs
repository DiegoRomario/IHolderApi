using IHolder.Business.Entities;
using IHolder.Business.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Interfaces.Services
{
    public interface IDistribuicao_por_tipo_investimentoService : IServiceInsert<Distribuicao_por_tipo_investimento>,
                                                                  IServiceUpdate<Distribuicao_por_tipo_investimento>,
                                                                  IServiceGetManyBy<Distribuicao_por_tipo_investimento>,
                                                                  IServiceDelete
    {
        Task<bool> Recalcular(Distribuicao_por_tipo_investimento entity);
    }
}
