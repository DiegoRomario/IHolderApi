using IHolder.Api.ViewModels.Base;
using IHolder.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class Distribuicao_por_ativoViewModel : Valores_baseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Ativo_id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public EOrientacao Orientacao { get; set; }

        public AtivoViewModel Ativo { get; set; }
    }
}
