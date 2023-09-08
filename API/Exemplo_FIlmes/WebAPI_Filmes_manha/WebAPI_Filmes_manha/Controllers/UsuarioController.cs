using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPI_Filmes_manha.Domains;
using WebAPI_Filmes_manha.Interfaces;
using WebAPI_Filmes_manha.Repositories;

namespace WebAPI_Filmes_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuariorepository { get; set; }

        public UsuarioController()
        {
            _usuariorepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método para realizar a busca de um determinado usuário cadastrado em nosso sistema
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuariorepository.Login(usuario.EmailUser, usuario.SenhaUser);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario não encontrado");
                }

                //caso encontre o usuário, prossegue para a criação do token

                //1º -> definir as informações (Claims) que serão fornecidos no token (PAYLOAD)

                //realizar instalação dos pacotes no nuget :
                //System.IdentityModel.Tokens.Jwt
                //Microsoft.AspNetCore.Authentication.JwtBearer

                var claims = new[]
                {
                    //formatação da claim 
                    //jti realiza a validação do ID que estamos procurando
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.EmailUser),
                    new Claim(ClaimTypes.Role, usuarioBuscado.PermissaoUser),

                    //existe a possibilidade de criar uma claim personalizada
                    //new Claim("valor personalizado", "valor personalizado")
                };

                //2º -> difinir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));


                //3º -> definir as credenciais do token(HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                //4º -> gerar o token
                //preparando o token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "WebAPI_Filmes_manha",

                    //destinatário do token
                    audience: "WebAPI_Filmes_manha",

                    //dados definidos nas claims(informações)
                    claims: claims,

                    //tempo de expiração do token 
                    expires: DateTime.Now.AddMinutes(5),

                    //por fim, informaremos nossas credenciais do token, definidas como creds
                    signingCredentials: creds
                );
                
                //escrevendo junto com o status code
                //5º -> vamos retornar o token criado
                return Ok(new { 
                    
                    token = new JwtSecurityTokenHandler().WriteToken(token)

                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
