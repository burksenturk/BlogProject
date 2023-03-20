using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Jwt_BlogProject.DAL
{
    public class BuildToken
    {
        public string CreateToken()
        {
            var bytes = Encoding.UTF8.GetBytes("Blogprojectaspnetcore"); //startup daki key i aldım
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes); //key i kullandım
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256); //jwt algoritması
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
