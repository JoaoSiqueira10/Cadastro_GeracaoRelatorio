using CadastroCRUD_Teste.Models;

namespace CadastroCRUD_Teste.Service
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

            // Mapear os dados para o modelo de relatório
            var relatorio = pessoas.Select(p => new Pessoa
            {
                Nome = p.Nome,
                Email = p.Email,
                CPF = p.CPF,
                // Mapear outros campos do relatório
            }).ToList();

            return pessoas;
        }
    }
}
