using IHolder.Application.Base;
namespace IHolder.Application.Commands
{
    public class DividirDistribuicaoPorProdutoCommand : Command<bool>
    {
        public bool SomenteItensEmCarteira { get; set; }
    }
}
