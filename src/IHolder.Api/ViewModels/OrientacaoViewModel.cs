using IHolder.Api.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class OrientacaoViewModel : InformacoesBaseViewModel
    {
        public IEnumerable<DistribuicaoPorTipoInvestimentoViewModel> DistribuicoesPorTiposInvestimentos { get; set; }

        public IEnumerable<DistribuicaoPorProdutoViewModel> DistribuicoesPorProdutos { get; set; }

        public IEnumerable<DistribuicaoPorAtivoViewModel> DistribuicoesPorAtivos { get; set; }
    }
}
