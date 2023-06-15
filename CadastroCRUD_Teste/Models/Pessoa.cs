using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCRUD_Teste.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Column("Id")]
        [Display(Name = "Identidade")]
        public int Id { get; set; }

        [Column("CPF")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        
        [Column("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
