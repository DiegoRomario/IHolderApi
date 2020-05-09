using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class AporteViewModel
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int AtivoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Preco_medio { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Quantidade { get; set; }

        public AtivoViewModel Ativo { get; set; }
    }
}
