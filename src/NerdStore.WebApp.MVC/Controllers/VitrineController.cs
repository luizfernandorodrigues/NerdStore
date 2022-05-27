using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Servicos;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.MVC.Controllers
{
    public class VitrineController : Controller
    {
        private readonly IProdutoServicoAplicacao _produtoServicoAplicacao;

        public VitrineController(IProdutoServicoAplicacao produtoServicoAplicacao)
        {
            _produtoServicoAplicacao = produtoServicoAplicacao;
        }

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtoServicoAplicacao.ObterTodos());
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            return View(await _produtoServicoAplicacao.ObterPorId(id));
        }
    }
}
