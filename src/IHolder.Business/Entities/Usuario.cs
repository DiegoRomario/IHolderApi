using IHolder.Business.Entities.Base;
using IHolder.Business.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Entities
{
    public class Usuario : Entidade_base
    {
        public Usuario(string nome, string email, string senha, string cPF, string celular, DateTime data_nascimento, EGenero genero)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            CPF = cPF;
            Celular = celular;
            Data_nascimento = data_nascimento;
            Genero = genero;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string CPF { get; private set; }
        public string Celular { get; private set; }
        public DateTime Data_nascimento { get; private set; }
        public EGenero Genero { get; private set; }

        public DateTime Data_inclusao { get; private set; }
        public DateTime? Data_alteracao { get; private set; }

        public IEnumerable<Distribuicao_por_tipo_investimento> Distribuicoes_por_tipos_investimentos { get; private set; }
        public IEnumerable<Distribuicao_por_ativo> Distribuicoes_por_ativos { get; private set; }
        public IEnumerable<Distribuicao_por_produto> Distribuicoes_por_produtos { get; private set; }
        public IEnumerable<Ativo> Ativos { get; private set; }
        public IEnumerable<Aporte> Aportes { get; private set; }
        public IEnumerable<Situacao_por_ativo> Situacoes_por_ativos { get; private set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
        public void AlterarCelular(string celular)
        {
            Celular = celular;
        }
        public void AlterarSenha(string senha)
        {
            Senha = senha;
        }

        public void AlterarDataNascimento(DateTime data_nascimento)
        {
            Data_nascimento = data_nascimento;

        }
        public void AlterarGenero(EGenero genero)
        {
            Genero = genero;
        }

    }


}
