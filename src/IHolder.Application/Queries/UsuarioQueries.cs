using IHolder.Application.ViewModels;
using IHolder.Domain.DomainObjects;
using System.Threading.Tasks;
using IHolder.Domain.Entities;
using AutoMapper;
using IHolder.Application.Base;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.Extensions.Options;

namespace IHolder.Application.Queries
{
    public class UsuarioQueries : IUsuarioQueries
    {
        private readonly IRepositoryBase<Usuario> _repositoryBase;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UsuarioQueries(IRepositoryBase<Usuario> repositoryBase, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this._repositoryBase = repositoryBase;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<UsuarioAutenticadoViewModel> AutenticarUsuario(UsuarioLoginArgs login)
        {
            Usuario usuario = await _repositoryBase.GetBy(u => u.Email == login.Email && u.Senha == login.Senha);

            if (usuario != null)
            {
                var usuario_logado = _mapper.Map<UsuarioAutenticadoViewModel>(usuario);
                GerarToken(usuario_logado);
                return usuario_logado;
            }

            return null;

        }

        private void GerarToken(UsuarioAutenticadoViewModel usuario)
        {
            Claim[] claims = new Claim[] {
                new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email.ToString()),
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Chave);
            DateTime ExpiresIn = DateTime.UtcNow.AddHours(_appSettings.Expiracao_horas);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.Valido_em,
                Subject = new ClaimsIdentity(claims),
                Expires = ExpiresIn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string encodedToken = tokenHandler.WriteToken(token);

            usuario.Token = encodedToken;

        }
    }
}
