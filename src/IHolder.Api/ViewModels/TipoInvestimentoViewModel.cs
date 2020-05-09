using IHolder.Api.ViewModels.Base;
using IHolder.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class TipoInvestimentoViewModel : InformacoesBaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ERisco Risco { get; set; }
        public IEnumerable<DistribuicaoPorTipoInvestimentoViewModel> DistribuicoesPorTiposInvestimentos { get; private set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; private set; }
    }
}
