using System.Data.SqlClient;
using WebAPI_Filmes_manha.Domains;
using WebAPI_Filmes_manha.Interfaces;

namespace WebAPI_Filmes_manha.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parametros:
        /// DataSource : Nome do servidor
        /// Initial Catalog : Nome da tabela do banco de dados
        /// Autenticação:
        ///     -windows: Integrated security = true
        ///     -sqlserver: userId = sa; Pwd = senha
        /// </summary>
        private string StringConxao = "Data Source = NOTE16-S15; Initial Catalog = Filmes; User id = sa; Pwd = Senai@134";
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Listar todos os objetos Filmes
        /// </summary>
        /// <returns>Lista contendo todos os objetos filmes</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FilmeDomain> ListarTodos()
        {
            //precisa se conectar com o banco de dados para realizar a criação dos comandos
            //precisamos criar uma lista de objetos com os filmes que tenho no banco de dados

            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            using (SqlConnection conn = new SqlConnection(StringConxao))
            {
                string querySelectAll = "SELECT IdFilme, NomeFilme, Nome From Filme LEFT JOIN Genero ON FIlme.IdGenero = Genero.IdGenero";

                conn.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, conn))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["id"]),

                            TituloFilme = rdr["Nome"].ToString(),
                        };

                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["id"]),

                            NomeGenero = rdr["nome"].ToString()
                        };

                        ListaFilmes.Add(filme);

                    }
                }

                return ListaFilmes;
            }
        }
    }
}
