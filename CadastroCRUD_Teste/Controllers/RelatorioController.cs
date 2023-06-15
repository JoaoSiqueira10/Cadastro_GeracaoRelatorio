using CadastroCRUD_Teste.Service;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using MvcFastReport.Services;

namespace CadastroCRUD_Teste.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly PessoaService _pessoaService;

        public RelatorioController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public IActionResult GerarRelatorio()
        {
            var dadosRelatorio = _pessoaService.GetPessoas();
            return View(dadosRelatorio);
        }
    }
}
