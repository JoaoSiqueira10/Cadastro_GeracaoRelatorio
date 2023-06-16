using CadastroPessoa.Services;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoa.Controllers
{
    public class RelatorioController : Controller
    {
        public readonly IWebHostEnvironment _webHostEnv;
        private readonly IPessoaService _pessoaService;

        public RelatorioController(IWebHostEnvironment webHostEnv, IPessoaService pessoaService)
        {
            _webHostEnv = webHostEnv;
            _pessoaService = pessoaService;
        }

        [Route("GerarTamplate")]
        public IActionResult GerarTamplate()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\pessoas.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var pessoasList = _pessoaService.GetPessoas();

            freport.Dictionary.RegisterBusinessObject(pessoasList, "pessoasList", 10, true);
            freport.Report.Save(reportFile);

            return Ok($" Relatorio gerado : {caminhoReport}");

        }

        [Route("GerarRelatorioPDF")]
        public IActionResult GerarRelatorioPDF()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\pessoas.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var pessoasList = _pessoaService.GetPessoas();

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(pessoasList, "pessoasList", 10, true);
            //freport.Report.Save(reportFile);
            freport.Prepare();

            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(freport, ms);
            ms.Flush();

            return File(ms.ToArray(), "application/pdf");
            //return Ok($"Relatorio gerado: {caminhoReport}");

        }
    }
}
