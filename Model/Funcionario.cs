using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLoguin.Model
{
    [Table("funcionarios")]
    public class Funcionario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string? Name { get; set; }
        [Column("Age")]
        public int Age { get; set; }
        [Column("Photo")]
        public string? Photo { get; set; }


        // column é o nome da coluna no banco e em baixo e como eu vou mapear ela no meu Objeto ou seja como eu vou usar ela no sistema

    }
}
