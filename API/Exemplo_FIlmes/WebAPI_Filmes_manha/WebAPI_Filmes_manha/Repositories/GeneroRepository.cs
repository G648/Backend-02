using System.Data.SqlClient;
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
            using (SqlConnection conn = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, conn))
                {

                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero) ;

                    cmd.Parameters.AddWithValue("@Nome", genero.NomeGenero);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }             
            }
        }
        
        /// <summary>
        /// Atualizar um gênero com base no seu ID
        /// </summary>
        /// <param name="id">Id do gênero a ser atualizado</param>
        /// <param name="genero">Objeto com as informações a serem atualizadas</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            
        }

        /// <summary>
        /// Buscar um gênero através do seu ID
        /// </summary>
        /// <param name="id"> Id do genero a ser buscado </param>
        /// <returns> Objeto buscado ou null caso não seja encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            //declara a conexão passando a string de conexão como parâmetros
            using (SqlConnection conn = new SqlConnection(StringConexao))
            {
                //declara o sql command cmd passando a query que será executada e a conexão como parametros
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                //abre a conexão com o banco de dados
                conn.Open();

                //declara a variavei para receber os valores da query 
                SqlDataReader rdr;

                //declara o sql command cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectById,conn))
                {
                    //passa o valor para o parâmetro IdGenero
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        //se sim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            //atribui a propriedade idgenero o valor da coluna "IdGenero" da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            //atribui a propriedade nome o valor da coluna "nome" da tabala do banco de dados
                            NomeGenero = rdr["Nome"].ToString()
                        };
                        //Retorna o generoBuscado com os dados obtidos
                        return generoBuscado;
                    }
                    //se não, retorna null
                    return null;
                }
            }            
            
        }

        ///<sumary>
        /// Cadastrar um novo gênero
        /// </sumary>
        /// <param name="novoGenero"> Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //passando a string de conexão com o sql como parâmetro
            using (SqlConnection conn = new SqlConnection(StringConexao))
            {
                //declarar a query que será executada 
                string queryInsert = "INSERT INTO Genero(nome) VALUES (@Nome)";

                //declara o SQLCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, conn))
                {
                    //Passa o valor do parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.NomeGenero);

                    //Abrimos a conexão com o banco de dados
                    conn.Open();

                    //executar a query (query insert)
                    cmd.ExecuteNonQuery();
                }
            }        
        }

        /// <summary>
        ///  Deleta os objetos que foram cadastrados
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int IdGenero)
        {
            //passando a string de conexão com o sql como parâmetro
            using (SqlConnection conn = new SqlConnection(StringConexao)) 
            {
                //declarar a query que será executada
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryDelete, conn))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", IdGenero);

                    conn.Open();

                    cmd.ExecuteNonQuery(); 
                }
            }
        }

        /// <summary>
        ///     Listar todos os objetos gêneros
        /// </summary>
        /// <returns> Lista contendo todos os objetos filmes </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<GeneroDomain> ListarTodos()
        {
            //precisa se conectar com o banco de dados e realizar uma consulta

            //Cria uma lista de objetos do tipo gênero
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();

            //declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection conn = new SqlConnection(StringConexao))
            {
                //declara a instrução a ser executada, no nosso caso, o select no banco de dados
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //vamos abrir a conexão com o banco de dados
                conn.Open();

                SqlDataReader rdr;

                //declara o sqlcommand passando a query que será executada e a conexão com o DB
                using (SqlCommand command = new SqlCommand(querySelectAll, conn))
                {
                    //executa a query e armazena os dados no reader
                    rdr = command.ExecuteReader();

                    //vamos instanciar um novo objeto para armazenar os dados 
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]),

                            NomeGenero = rdr["Nome"].ToString()
                        };

                        //adiciona cada objeto dentro da lista
                        ListaGeneros.Add(genero);
                    }
                }

            }

            return ListaGeneros;
        }
    }
}
