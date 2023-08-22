using WebAPI_Filmes_manha.Domains;

namespace WebAPI_Filmes_manha.Interfaces
{
    /// <summary>
    ///     Interface responsável pelo repositório FilmeRepository
    ///     Definir os métodos que serão implementados pelo FilmeRepository
    /// </summary>
    public interface IFilmeRepository
    {
        /// <summary>
        ///     Cadastrar um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto que sera cadastrado</param>
        void cadastrar(FilmeDomain novoFilme);

        /// <summary>
        ///     Listar todos os objetos cadastrados
        /// </summary>
        /// <returns> Lista com Objetos </returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Atualiza um objeto existente passando o seu id pelo corpo da requisião
        /// </summary>
        /// <param name="filme">Objeto atualizado pelo corpo</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualizando objeto existente passando o seu id pela url
        /// </summary>
        /// <param name="id">id do objeto que será atualizado</param>
        /// <param name="filme">Objeto atualizado (novas informações)</param>
        void AtualizarIdUrl (int id, FilmeDomain filme);

        /// <summary>
        ///     Deletar um objeto 
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um objeto através do seu id
        /// </summary>
        /// <param name="id">id do objeto a ser buscado</param>
        /// <returns>Objeto Buscado</returns>
        FilmeDomain BuscarPorId(int id);
    }
}
