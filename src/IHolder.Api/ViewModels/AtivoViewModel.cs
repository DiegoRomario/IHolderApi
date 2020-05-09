using IHolder.Api.ViewModels.Base;
using IHolder.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class AtivoViewModel : InformacoesBaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Ticker { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Cotacao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ERisco Risco { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ESituacao Situacao { get; private set; }

        public ProdutoViewModel Produto { get; private set ; }

        public IEnumerable<DistribuicaoPorAtivoViewModel> DistribuicoesPorAtivos { get; private set; }

        public IEnumerable<AporteViewModel> Aportes { get; private set; }
    }
}
