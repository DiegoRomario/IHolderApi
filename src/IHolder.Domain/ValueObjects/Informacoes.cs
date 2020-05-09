namespace IHolder.Domain.ValueObjects
{
    public class Informacoes
    {
        public Informacoes(string descricao, string caracteristicas)
        {
            Descricao = descricao;
            Caracteristicas = caracteristicas;
        }

        public string Descricao { get; private set; }
        public string Caracteristicas { get; private set; }

    }
}
