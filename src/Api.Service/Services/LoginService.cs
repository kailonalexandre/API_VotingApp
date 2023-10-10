using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Dtos;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        private IConfiguration _configuration { get; }

        public LoginService(IUserRepository repository,
        SigningConfigurations signingConfigurations,
        TokenConfigurations tokenConfigurations,
        IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            var baseUser = new UserEntity();

            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email);
                if (baseUser == null)
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao Autenticar"
                    };
                else
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),//JTI id do Token
                            new Claim(JwtRegisteredClaimNames.UniqueName, baseUser.Email),
                        }
                    );

                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    var handler = new JwtSecurityTokenHandler();

                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SucessObject(createDate, expirationDate, token, user);
                }
            }
            else
                return new
                {
                    authenticated = false,
                    message = "Falha ao Autenticar"
                };
        }



        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SucessObject(DateTime createDate, DateTime expirationDate, string token, LoginDto user)
        {
            return new
            {
                authenticated = true,
                create = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                message = "Usuário Logado com sucesso"
            };
        }
    }
}
