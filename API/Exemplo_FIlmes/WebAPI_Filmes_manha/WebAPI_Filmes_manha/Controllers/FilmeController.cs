using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Filmes_manha.Domains;
using WebAPI_Filmes_manha.Interfaces;
using WebAPI_Filmes_manha.Repositories;

namespace WebAPI_Filmes_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        ///<summary>
        /// objeto _generoRepository que iirá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>

        private IGeneroRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referência aos métodos no repositório
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new GeneroRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método ListarTodos no repositório e retorna a resposta para o usuário (front-end)
        /// </summary>
        /// <returns>retorna a resposta para o usuário (front-end)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> ListaFilmes = _filmeRepository.ListarTodos();

                return Ok(ListaFilmes);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
