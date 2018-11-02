using System;
using SQLite;
namespace AgendaCelulas.Models
{
    [Table("Celula")]
    public class Celula
    {
        [Column("id"), PrimaryKey(),AutoIncrement()]
        public int id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }
    }
}
