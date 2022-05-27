using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Dto;
using NerdStore.Catalogo.Application.Servicos;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.MVC.Controllers.Admin
{
    public class AdminProdutoController : Controller
    {
        private readonly IProdutoServicoAplicacao _produtoServicoAplicacao;

        public AdminProdutoController(IProdutoServicoAplicacao produtoServicoAplicacao)
        {
            _produtoServicoAplicacao = produtoServicoAplicacao;
        }

        [HttpGet]
        [Route("admin-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtoServicoAplicacao.ObterTodos());
        }

        [HttpGet]
        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto()
        {
            return View(await PopularCategorias(new ProdutoDto()));
        }

        [HttpPost]
        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto(ProdutoDto produtoDto)
        {
            if (!ModelState.IsValid)
                return View(await PopularCategorias(produtoDto));

            await _produtoServicoAplicacao.AdicionarProduto(produtoDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id)
        {
            return View("Estoque", await _produtoServicoAplicacao.ObterPorId(id));
        }

        [HttpPost]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
                await _produtoServicoAplicacao.ReporEstoque(id, quantidade);
            else
                await _produtoServicoAplicacao.DebitarEstoque(id, quantidade);

            return View("Index", await _produtoServicoAplicacao.ObterTodos());
        }

        [HttpGet]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id)
        {
            return View(await PopularCategorias(await _produtoServicoAplicacao.ObterPorId(id)));
        }

        [HttpPost]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id, ProdutoDto produtoDto)
        {
            var produto = await _produtoServicoAplicacao.ObterPorId(id);

            produtoDto.QuantidadeEstoque = produto.QuantidadeEstoque;
            produtoDto.DataCadastro = produto.DataCadastro;

            ModelState.Remove("QuantidadeEstoque");

            if (!ModelState.IsValid)
                return View(await PopularCategorias(produtoDto));

            await _produtoServicoAplicacao.AtualizarProduto(produtoDto);

            return RedirectToAction("Index");
        }

        private async Task<ProdutoDto> PopularCategorias(ProdutoDto produtoDto)
        {
            produtoDto.CategoriasDto = await _produtoServicoAplicacao.ObterCategorias();

            return produtoDto;
        }
    }
}
