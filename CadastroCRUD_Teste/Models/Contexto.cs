using Microsoft.EntityFrameworkCore;

namespace CadastroCRUD_Teste.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoa{ get; set; }
    }
}
