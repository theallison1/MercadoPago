﻿using MercadoPago.CheckoutAPI.Application.Dtos.Users.Request;
using MercadoPago.CheckoutAPI.Application.Interfaces;
using MercadoPago.CheckoutAPI.Application.Models.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Settings;
using MercadoPago.CheckoutAPI.Domain.Entities;
using MercadoPago.CheckoutAPI.Infrastructure.Persistences.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MercadoPago.CheckoutAPI.Application.Services
{
    public class AuthApplication : IAuthApplication
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public AuthApplication(IUsersRepository usersRepository, IOptions<JwtSettings> jwtSettings)
        {
            _usersRepository = usersRepository;
            _jwtSettings = jwtSettings;
        }

        public async Task<BaseResponse<string>> Login(TokenRequestDto bodyRequest)
        {
            var response = new BaseResponse<string>()
            {
                Method = "POST"
            };

            var user = await _usersRepository.GetUserByEmail(bodyRequest.Email);

            if (user is not null)
            {
                if (EncryptSHA256(bodyRequest.Password) == user.Password)
                {
                    response.Content = GenerateToken(user);
                    response.Message = "Token generado correctamente";
                }
                else
                {
                    response.Message = "Usuario y/o contraseña invalidos";
                }
            }
            else
            {
                response.Message = "Usuario y/o contraseña invalidos";
            }

            return response;
        }

        private string EncryptSHA256(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) 
                { 
                    sb.Append(bytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.SecretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var userClaims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Description)
            };

            var handler = new JwtSecurityTokenHandler();

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Value.Issuer,
                audience: _jwtSettings.Value.Issuer,
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.Value.Expires),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials);

            return handler.WriteToken(token);
        }
    }
}
