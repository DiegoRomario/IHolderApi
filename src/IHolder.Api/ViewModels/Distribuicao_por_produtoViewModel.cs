using IHolder.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class Distribuicao_por_produtoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Distribuicao_por_tipo_investimento_id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Produto_id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public EOrientacao Orientacao { get; set; }

        public Distribuicao_por_tipo_investimentoViewModel Distribuicao_por_tipo_investimento { get; set; }
        public ProdutoViewModel Produto { get; set; }
    }
}
