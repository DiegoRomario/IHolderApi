﻿using IHolder.Application.Base;
namespace IHolder.Application.Commands
{
    public class DividirDistribuicaoPorAtivoCommand : Command<bool>
    {
        public bool SomenteItensEmCarteira { get; set; }
    }
}
