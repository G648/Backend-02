using WebAPI_Filmes_manha.Domains;

namespace WebAPI_Filmes_manha.Interfaces
{
    public interface IUsuarioRepository
    {

        //TipoDeRetorno NomeMetodo(TipoParâmetro NomeParâmetro) 

        UsuarioDomain Login (string EmailUser, string SenhaUser);
    }
}
