using IHolder.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class DistribuicaoPorProdutoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int DistribuicaoPorTipoInvestimentoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public EOrientacao Orientacao { get; set; }
        public ProdutoViewModel Produto { get; set; }
    }
}
