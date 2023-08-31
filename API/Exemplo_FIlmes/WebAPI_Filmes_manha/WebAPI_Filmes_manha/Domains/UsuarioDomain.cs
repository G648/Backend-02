namespace WebAPI_Filmes_manha.Domains
{
    public class UsuarioDomain
    {
        /// <summary>
        ///     Classe que representa a entidade(Tabela) Usuario
        /// </summary>

        //atributos
        public int IdUsuario { get; set; }
        public string EmailUser { get; set; }
        public string SenhaUser { get; set; }
        public string PermissaoUser { get; set; }
    }
}
