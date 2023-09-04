using System.ComponentModel.DataAnnotations;

namespace WebAPI_Filmes_manha.Domains
{
    public class UsuarioDomain
    {
        /// <summary>
        ///     Classe que representa a entidade(Tabela) Usuario
        /// </summary>

        //atributos
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome do campo é obrigatório")]
        public string EmailUser { get; set; }

        //usado para definir um tamanho mínimo e tamanho máximo para a senha
        [StringLength(20, MinimumLength = 3, ErrorMessage ="A senha deve ter de 3 a 20 caracteres")]
        [Required (ErrorMessage ="o campo senha é obrigatório")]
        public string SenhaUser { get; set; }
        public string PermissaoUser { get; set; }
    }
}
