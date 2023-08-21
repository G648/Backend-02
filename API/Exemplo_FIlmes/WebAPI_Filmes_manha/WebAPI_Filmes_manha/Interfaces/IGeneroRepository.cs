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

        void Cadastrar(GeneroDomain novoGenero);
        List<GeneroDomain> ListarTodos();
        void AtualizarIdCorpo(GeneroDomain genero);
        void Deletar(int id);
    }
}
