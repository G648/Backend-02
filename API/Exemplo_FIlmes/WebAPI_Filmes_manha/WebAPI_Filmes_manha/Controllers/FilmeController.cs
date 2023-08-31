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

        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referência aos métodos no repositório
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
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

        /// <summary>
        /// Método para realizar o cadastro de um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto recebido na requisição</param>
        /// <returns>Status Code 201 (created)</returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.cadastrar(novoFilme);

                return Created("Objeto criado com sucesso!", novoFilme);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método para realizar o delete de um determinado filme
        /// </summary>
        /// <param name="id">id recebido para identificar o filme que será excluido</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método para realizar busca em um Id Específico
        /// </summary>
        /// <param name="IdFilme"></param>
        /// <returns></returns>
        [HttpGet("{IdFilme}")]
        public IActionResult Get(int IdFilme)
        {
            try
            {
                FilmeDomain buscarPorId = _filmeRepository.BuscarPorId(IdFilme);

                if (buscarPorId == null)
                {
                    return NotFound("nenhum filme foi encontrado");
                }
                return Ok(buscarPorId);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método para realizar a atualização de um fime pelo corpo
        /// </summary>
        /// <param name="filme">Retornando o objeto todo para realizar o update pelo corpo do objeto</param>
        /// <returns>Retorna o objeto atualizado como um todo</returns>
        [HttpPut]
        public IActionResult Update(FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarIdCorpo(filme);

                return Ok(filme);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método para realizar a atualização de um determinado filme, especificando o ID do mesmo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmUpdate = _filmeRepository.BuscarPorId(id);

                if (filmUpdate == null)
                {
                    return NotFound("Objeto não foi encontrado");
                }

                _filmeRepository.AtualizarIdUrl(id, filme);
                
                return Ok(filme);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
