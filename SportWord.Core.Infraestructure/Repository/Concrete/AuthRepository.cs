using System;
using System.Text;
using SportWord.Core.Infraestructure.Repository.Abstract;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using SportWord.Core.Domain.Models;


namespace SportWord.Core.Infraestructure.Repository.Concrete
{
    public class AuthRepository : IAuthRepository<User, string>
    {
        private DB db;
        public AuthRepository(DB db)
        {
            this.db = db;
        }
        public User Login(User entity)
        {
            var currentUser = db.Users
                .Where(u => u.usuario_name == entity.usuario_name &&
                     u.contraseña == entity.contraseña
                ).FirstOrDefault();
            return currentUser;
        }
        public string GetToken(User entity, string key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(key);
            /*Crea clave secreta de cifrado a partir de la
             * cadena definida en las configuraciones de la API*/
            var tokenDescriptor = new SecurityTokenDescriptor
            //Define los atributos relacionados con el token
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, entity.usuario_name)

                }),
                //crea el encabezado con datos del usuario
                Expires = DateTime.UtcNow.AddHours(1),
                //Añade plazo de expiracion del token
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenkey),
                      SecurityAlgorithms.HmacSha256Signature
                    )


                //Define la firma utilizando la clave secreta para cifrar
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }

    }
}