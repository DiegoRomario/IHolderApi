using IHolder.Api.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class SituacaoViewModel : InformacoesBaseViewModel
    {
        public IEnumerable<AtivoViewModel> Ativos { get; set; }
    }
}
