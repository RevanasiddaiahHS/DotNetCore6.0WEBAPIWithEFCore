using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


//This methos is to carete Token and send back to client
namespace SuperHeroAPI
{   
    public static class JwtToken
    {
        private const string SECRET_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        public static readonly SymmetricSecurityKey SIGNING_KEY =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
        public static string GenerateJwtToken()
        {
            var credentials = new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            var header=new  JwtHeader(credentials);

            DateTime Expiry= DateTime.UtcNow.AddMinutes(5);
            int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            var payload = new JwtPayload
            {
                {"sub","testsubject" },
                {"Name","scott" },
                {"email","ss@s.com" },
                {"exp",ts },
                {"iss","https://localhost:44352" },
                { "aud","https://localhost:44352" },
            };
            var secToken=new JwtSecurityToken(header, payload);
            var handler=new JwtSecurityTokenHandler();
            var tokenString=handler.WriteToken(secToken);
            Console.WriteLine(tokenString);
            return tokenString;
        } 
    }
}
