using IHolder.Domain.DomainObjects;
using IHolder.Domain.Enumerators;
using System;
using System.Collections.Generic;


namespace IHolder.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario(string nome, string email, string senha, EGenero genero)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Genero = genero;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public EGenero Genero { get; private set; }

        public DateTime IncluidoEm { get; private set; }
        public DateTime? AlteradoEm { get; private set; }

        public IEnumerable<DistribuicaoPorTipoInvestimento> DistribuicoesPorTiposInvestimentos { get; private set; }
        public IEnumerable<DistribuicaoPorAtivo> DistribuicoesPorAtivos { get; private set; }
        public IEnumerable<DistribuicaoPorProduto> DistribuicoesPorProdutos { get; private set; }
        public IEnumerable<Ativo> Ativos { get; private set; }
        public IEnumerable<Aporte> Aportes { get; private set; }
        public IEnumerable<SituacaoPorAtivo> SituacoesPorAtivos { get; private set; }

    }


}
