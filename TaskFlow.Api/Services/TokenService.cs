using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TaskFlow.Api.Services;

public class TokenService
{
    public string GenerateToken(int userId)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("super_secret_jwt_key_1234567890!@#$%"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "TaskFlow",
            audience: "TaskFlowUsers",
            claims: new[] { new Claim("id", userId.ToString()) },
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
