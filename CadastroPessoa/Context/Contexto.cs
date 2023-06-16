using CadastroPessoa.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
