using WebAPI_Filmes_manha.Domains;

namespace WebAPI_Filmes_manha.Interfaces
{
    public interface IUsuarioRepository
    {

        //TipoDeRetorno NomeMetodo(TipoParâmetro NomeParâmetro) 

        /// <summary>
        /// Classe que será utilizada no UsuarioRepository, usado para logar um novo usuário
        /// </summary>
        /// <param name="EmailUser"></param>
        /// <param name="SenhaUser"></param>
        /// <returns></returns>
        UsuarioDomain Login (string EmailUser, string SenhaUser);
    }
}
