using IHolder.Api.ViewModels.Base;
using IHolder.Business.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class Distribuicao_por_tipo_investimentoViewModel : Valores_baseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Tipo_investimento_id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Usuario_id { get; set; }
        public EOrientacao Orientacao { get; private set; }
        public Tipo_investimentoViewModel Tipo_investimento { get; private set; }
        public IEnumerable<Distribuicao_por_produtoViewModel> Distribuicoes_por_produtos { get; private set; }
    }
}
