using CadastroPessoa.Context;
using CadastroPessoa.Models;

namespace CadastroPessoa.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly Contexto _context;

        public PessoaService(Contexto context)
        {
            _context = context;
        }

        public List<Pessoa> GetPessoas()
        {
            var pessoas = _context.Pessoa.ToList();
            return pessoas;
        }
    }
}
