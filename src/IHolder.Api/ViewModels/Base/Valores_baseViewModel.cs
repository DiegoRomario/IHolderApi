using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels.Base
{
    public class Valores_baseViewModel : Entidade_baseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, 100, ErrorMessage = "O Percentual Objetivo deve ser entre {1} e {2}.")]
        public decimal Percentual_objetivo { get; set; }
        public decimal Percentual_atual { get; set; }
        public decimal Percentual_diferenca { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor_atual { get; set; }
        public decimal Valor_diferenca { get; set; }
    }
}
