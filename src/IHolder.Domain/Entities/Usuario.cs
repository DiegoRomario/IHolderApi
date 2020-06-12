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

        public DateTime DataInclusao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }

        public IEnumerable<DistribuicaoPorTipoInvestimento> DistribuicoesPorTiposInvestimentos { get; private set; }
        public IEnumerable<DistribuicaoPorAtivo> DistribuicoesPorAtivos { get; private set; }
        public IEnumerable<DistribuicaoPorProduto> DistribuicoesPorProdutos { get; private set; }
        public IEnumerable<Ativo> Ativos { get; private set; }
        public IEnumerable<AtivoEmCarteira> AtivosEmCarteira { get; private set; }

    }


}
