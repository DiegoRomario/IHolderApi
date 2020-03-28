﻿using IHolder.Api.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Api.ViewModels
{
    public class Usuario_resposta_autenticacaoViewModel
    {
        public string Token { get; set; }
        public DateTime Expira_em { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }
}
