using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLoguin.Model
{
    [Table("usuarios")]
    public class Usuario   //no nome da classe, eu chamo o nome da tabela, correto? uso o mesmo nome. 
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string? Nome { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        [Column("senha")]
        public string? Senha { get; set; }

        [NotMapped]
        public string? Token { get; set; }

        // column é o nome da coluna no banco e em baixo e como eu vou mapear ela no meu Objeto ou seja como eu vou usar ela no sistema

    }
}

