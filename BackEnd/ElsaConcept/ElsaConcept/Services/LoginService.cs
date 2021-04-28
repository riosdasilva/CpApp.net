using ElsaConcept.Configurations;
using ElsaConcept.Data.DTO;
using ElsaConcept.Interfaces;
using ElsaConcept.Models;
using ElsaConcept.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElsaConcept.Services
{
    public class LoginService : ILoginService
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;

        private IUserService _clientRepository;

        private readonly ITokenService _tokenService;

        public LoginService(TokenConfiguration configuration, IUserService clientRepository, ITokenService tokenService)
        {
            _configuration = configuration;
            _clientRepository = clientRepository;
            _tokenService = tokenService;
        }

        public TokenDTO ValidateCredentials(UserDTO userCredentials)
        {
            var user = _clientRepository.ValidateCredentials(userCredentials);
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.Refresh_token = refreshToken;
            user.Refresh_token_expiry_time = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

           _clientRepository.RefreshUserInfo(user);

            return new TokenDTO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public TokenDTO ValidateCredentials(TokenDTO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFormExpiredToken(accessToken);

            var username = principal.Identity.Name;

            var user = _clientRepository.ValidateCredentials(username);

            if( user == null || 
                user.Refresh_token != refreshToken ||
                user.Refresh_token_expiry_time <= DateTime.Now)
            {
                return null;
            }

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.Refresh_token = refreshToken;

            _clientRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO(
               true,
               createDate.ToString(DATE_FORMAT),
               expirationDate.ToString(DATE_FORMAT),
               accessToken,
               refreshToken
               );
        }
    }
}
