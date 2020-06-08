using IHolder.Application.Base;
namespace IHolder.Application.Commands
{
    public class DividirDistribuicaoPorTipoInvestimentoCommand : Command<bool>
    {
        public bool SomenteItensEmCarteira { get; set; }
    }
}
