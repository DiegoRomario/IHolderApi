using IHolder.Api.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class ProdutoViewModel : Informacoes_baseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Tipo_investimento_id { get; set; }

        public Tipo_investimentoViewModel Tipo_investimento { get; private set; }

        public IEnumerable<Distribuicao_por_produtoViewModel> Distribuicoes_por_produtos { get; private set; }

        public IEnumerable<AtivoViewModel> Ativos { get; private set; }
    }
}
