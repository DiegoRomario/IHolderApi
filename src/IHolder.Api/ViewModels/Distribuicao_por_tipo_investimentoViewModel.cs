using IHolder.Api.ViewModels.Base;
using IHolder.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class DistribuicaoPorTipoInvestimentoViewModel : Valores_baseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid TipoInvestimentoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid usuarioId { get; set; }
        public EOrientacao Orientacao { get; private set; }
        public TipoInvestimentoViewModel TipoInvestimento { get; private set; }
        public IEnumerable<DistribuicaoPorProdutoViewModel> DistribuicoesPorProdutos { get; private set; }
    }
}
