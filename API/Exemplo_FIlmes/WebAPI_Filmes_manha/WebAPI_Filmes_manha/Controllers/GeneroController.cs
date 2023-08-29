using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Filmes_manha.Domains;
using WebAPI_Filmes_manha.Interfaces;
using WebAPI_Filmes_manha.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI_Filmes_manha.Controllers
{
    //define que a rota de uma requisiçãoserá no seguinte formato
    //dominio/api/nomeController
    //ex: http://localhost:5000/api/genero
    [Route("api/[controller]")]

    //define que é um controlador de API
    [ApiController]

    //define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //metodo controlador que herda da controller base
    //onde será criado os EndPoints (Rotas)
    public class GeneroController : ControllerBase
    {
        ///<summary>
        /// objeto _generoRepository que iirá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>

        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referência aos métodos no repositório
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
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
                //cria uma lista que recebe os dados da requisição
                List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

                //retorna a lista no formato JSON com o status code OK(200)
                return Ok(ListaGeneros);
            }
            catch (Exception error)
            {
                //retorna um status code BadRequest (400) e a mensagem do erro
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastro de gênero
        /// </summary>
        /// <param name="NovoGenero">Objeto recebido na requisição</param>
        /// <returns>Status Code 201 (created)</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain NovoGenero)
        {
            try
            {
                //fazendo a chamada para o método cadastrar, passando o objeto como parâmetro
                _generoRepository.Cadastrar(NovoGenero);

                //retorna status code 201 - Created
                return Created("objeto criado", NovoGenero);
            }
            catch (Exception error)
            {
                //retorna um status code 400 (Bad Request) e a mesagem do erro
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint que deleta todos os objetos criados
        /// </summary>
        /// <param name="IdGenero">Objeto deletado na requisição</param>
        /// <returns>Status code 204 (No Content)</returns>
        [HttpDelete("{IdGenero}")]
        public IActionResult Delete(int IdGenero)
        {
            try
            {
                _generoRepository.Deletar(IdGenero);

                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


        /// <summary>
        /// Endpoint que busca um Id Específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{IdGeneroBuscado}")]
        public IActionResult BuscarPorId(int IdGeneroBuscado)
        {
            try
            {
                GeneroDomain buscaPorId = _generoRepository.BuscarPorId(IdGeneroBuscado);

                if (BuscarPorId == null)
                {
                    return NotFound("Nenhum gênero foi encontrado");
                }

                return Ok(buscaPorId);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }


        /// <summary>
        ///     Atualizando os dados 
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdCorpo(genero);

                return Ok(genero);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Atualizando os dados apenas com o ID da requisição
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoAtualizado = _generoRepository.BuscarPorId(genero.IdGenero);

                if (BuscarPorId == null)
                {
                    return NotFound("Nenhum gênero foi encontrado");
                }

                genero.IdGenero = id;

                _generoRepository.AtualizarIdUrl(id, genero);

                return Ok(generoAtualizado);
                
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
