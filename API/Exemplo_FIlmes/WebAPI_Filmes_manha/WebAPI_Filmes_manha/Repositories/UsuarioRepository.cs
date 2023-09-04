using System.Data.SqlClient;
using WebAPI_Filmes_manha.Domains;
using WebAPI_Filmes_manha.Interfaces;

namespace WebAPI_Filmes_manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
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

        /// <summary>
        /// Método para realizar a busca dos usuarios criados dentro do banco de dados
        /// </summary>
        /// <param name="EmailUser"> </param>
        /// <param name="SenhaUser"></param>
        /// <returns></returns>
        public UsuarioDomain Login(string EmailUser, string SenhaUser)
        {
            using (SqlConnection conn = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT IdUsuario, EmailUser, SenhaUser, PermissaoUser FROM Usuario WHERE EmailUser = @EmailUser AND SenhaUser = @SenhaUser";

                conn.Open();

                
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, conn))
                {
                    cmd.Parameters.AddWithValue("@EmailUser", EmailUser);

                    cmd.Parameters.AddWithValue("@SenhaUser", SenhaUser);

                    rdr = cmd.ExecuteReader();

                    //podemos executar o cmd com o seguinte comando: sqldatareader rdr = cmd.executereader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),

                            EmailUser = rdr["EmailUser"].ToString(),

                            SenhaUser = rdr["SenhaUser"].ToString(),

                            PermissaoUser = rdr["PermissaoUser"].ToString(),
                        };

                        return usuarioBuscado;

                    }
                    return null;
                }
            }

        }
    }
}



