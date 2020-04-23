using IHolder.Business.Entities;
using IHolder.Business.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Interfaces.Services
{
    public interface IUsuarioService : IServiceGetBy<Usuario>, 
                                       IServiceInsert<Usuario>,
                                       IServiceUpdate<Usuario>
    {
    }
}
