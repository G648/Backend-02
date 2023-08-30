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
        private string StringConexao = "Data Source = NOTE16-S15; Initial Catalog = Filmes; User id = sa; Pwd = Senai@134";
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection conn = new SqlConnection (StringConexao))
            {
                
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT IdFilme, NomeFilme FROM Filme WHERE IdFilme = @IdFilme";

                conn.Open ();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, conn))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    rdr = cmd.ExecuteReader ();

                    //realizar validação pra ver se o comando funcionou

                    if (rdr.Read())
                    {
                        //se sim, instancia um novo objeto chamado filmeBuscado do tipo filmeDomain

                        FilmeDomain filmeBuscado = new FilmeDomain()
                        {
                            //atribui a propriedade IdFilme o valor da coluna "IdFilme" da tabela do banco de dados
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            //atribui a propriedade nome o valor da coluna "nomefilme" da tabela do banco de dados
                            NomeFilme = rdr["NomeFilme"].ToString()
                        };

                        return filmeBuscado;
                    }
                    return null;
                }
            }
        }

        public void cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection conn = new SqlConnection(StringConexao))
            {
                string queryInstertFilm = "INSERT INTO Filme(IdGenero, NomeFilme) VALUES (@IdGenero, @NomeFilme)";

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(queryInstertFilm, conn))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);

                    cmd.Parameters.AddWithValue("@NomeFilme", novoFilme.NomeFilme);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection conn = new SqlConnection (StringConexao))
            {
                string queryDeleteFilm = "DELETE FROM Filme WHERE IdFilme = @IdFilme";

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(queryDeleteFilm, conn))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    cmd.ExecuteNonQuery();
                }
            }
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

            using (SqlConnection conn = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdFilme, Filme.IdGenero ,Filme.NomeFilme, Genero.Nome From Filme LEFT JOIN Genero ON Filme.IdGenero = Genero.IdGenero";

                conn.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, conn))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            NomeFilme = rdr["NomeFilme"].ToString(),

                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                                Nome = rdr["Nome"].ToString()
                            }
                    };

                    ListaFilmes.Add(filme);

                }
            }

            return ListaFilmes;
        }
    }
}
}
