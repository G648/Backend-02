using WebAPI_Filmes_manha.Domains;

namespace WebAPI_Filmes_manha.Interfaces
{
    /// <summary>
    ///     Interface responsável pelo repositório GeneroRepository
    ///     Definir os métodos que serão implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //TipoDeRetorno NomeMetodo(TipoParâmetro NomeParâmetro) 

        /// <summary>
        ///  Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        ///  Listar todos os objetos cadastrados
        /// </summary>
        /// <returns> lista com objetos </returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atualiza um objeto existente passando o seu id pelo corpo da requisião
        /// </summary>
        /// <param name="genero">Objeto atualizado pelo corpo </param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizando objeto existente passando o seu id pela url
        /// </summary>
        /// <param name="id"> id do objeto que será atualizado</param>
        /// <param name="genero"> Objeto atualizado (novas informações)</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// deletar um objeto 
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um objeto através do seu id
        /// </summary>
        /// <param name="id"> id do objeto a ser buscado</param>
        /// <returns>Objeto Buscado</returns>
        GeneroDomain BuscarPorId(int id);
    }
}
