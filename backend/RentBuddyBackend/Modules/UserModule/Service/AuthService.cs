using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Infrastructure;

namespace RentBuddyBackend.Modules.UserModule.Service
{
    public class AuthService(Config config)
    {
        public string HashPassword(string password)
        {
            using var hmac = new HMACSHA512();
            hmac.Key = config.PasswordSalt;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hash);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var passwordHashInBytes = Convert.FromBase64String(hashedPassword);
            using var hmac = new HMACSHA512(config.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHashInBytes);
        }

        public string GenerateJwtToken(UserEntity user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dKt3Y#9^3nTv%2GpB&y8U@C*#w!WqS6D"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "RentBuddyApp",
                audience: "RentBuddyUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}