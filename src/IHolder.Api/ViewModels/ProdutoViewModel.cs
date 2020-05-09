using IHolder.Api.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class ProdutoViewModel : InformacoesBaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TipoInvestimentoId { get; set; }

        public TipoInvestimentoViewModel TipoInvestimento { get; private set; }

        public IEnumerable<DistribuicaoPorProdutoViewModel> DistribuicoesPorProdutos { get; private set; }

        public IEnumerable<AtivoViewModel> Ativos { get; private set; }
    }
}
