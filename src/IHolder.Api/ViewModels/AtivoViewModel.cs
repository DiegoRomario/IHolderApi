using IHolder.Api.ViewModels.Base;
using IHolder.Business.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class AtivoViewModel : Informacoes_baseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Produto_id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Ticker { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Cotacao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ERisco Risco { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ESituacao Situacao { get; private set; }

        public ProdutoViewModel Produto { get; private set ; }

        public IEnumerable<Distribuicao_por_ativoViewModel> Distribuicoes_por_ativos { get; private set; }

        public IEnumerable<AporteViewModel> Aportes { get; private set; }
    }
}
