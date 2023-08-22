using WebAPI_Filmes_manha.Domains;
using WebAPI_Filmes_manha.Interfaces;

namespace WebAPI_Filmes_manha.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {    
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros:
        /// Datasource : Nome do Servidor
        /// Initial Catalog: Nome da tabela do banco de dados
        /// Autenticação:
        ///     -windows: Integrated security = true
        ///     -sqlServer: userId = sa; Pwd = senha
        /// </summary>
        private string StringConexao = "Data Source = NOTE16-S15; Initial Catalog = Filmes; User id = sa; Pwd = Senai@134";
                                                                                         // Integrated security = true -> autenticação win
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
