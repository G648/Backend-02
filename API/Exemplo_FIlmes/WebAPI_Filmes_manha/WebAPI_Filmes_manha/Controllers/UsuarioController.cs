using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebAPI_Filmes_manha.Domains;
using WebAPI_Filmes_manha.Interfaces;
using WebAPI_Filmes_manha.Repositories;

namespace WebAPI_Filmes_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        /// <param name="EmailUser"></param>
        /// <param name="SenhaUser"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult buscarUser(string EmailUser, string SenhaUser)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuariorepository.Login(EmailUser, SenhaUser);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario não encontrado");
                }

                return Ok(usuarioBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
