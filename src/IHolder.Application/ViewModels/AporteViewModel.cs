﻿using System;

namespace IHolder.Application.ViewModels
{
    public class AporteViewModel
    {
        public Guid Id { get; set; }
        public Guid AtivoId { get; set; }
        public string AtivoTicker { get; set; }
        public string AtivoDescricao { get; set; }
        public string ProdutoDescricao { get; set; }
        public decimal PrecoMedio { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorAplicado { get; set; }
        public decimal ValorAtual { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataPrimeiroAporte { get; set; }

    }
}
