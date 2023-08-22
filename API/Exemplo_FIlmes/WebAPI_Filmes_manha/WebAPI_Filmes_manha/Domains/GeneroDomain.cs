using System.ComponentModel.DataAnnotations;

namespace WebAPI_Filmes_manha.Domains
{
    /// <summary>
    ///     Classe que representa a entidade(Tabela) Genero
    /// </summary>
    public class GeneroDomain
    {
        //atributos
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O nome do campo é obrigatório")]
        public string? NomeGenero { get; set; }

    }
}
