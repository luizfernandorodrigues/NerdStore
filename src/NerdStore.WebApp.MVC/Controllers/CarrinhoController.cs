using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Servicos;
using NerdStore.Core.Bus;
using NerdStore.Vendas.Application.Commands;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoServicoAplicacao _produtoServicoAplicacao;
        private readonly IMediatrHandler _mediatrHandler;

        public CarrinhoController(IProdutoServicoAplicacao produtoServicoAplicacao, IMediatrHandler mediatrHandler)
        {
            _produtoServicoAplicacao = produtoServicoAplicacao;
            _mediatrHandler = mediatrHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoServicoAplicacao.ObterPorId(id);

            if (produto == null)
                return BadRequest();

            if(produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";

                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }

            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);

            await _mediatrHandler.EnviarComando(command);

            TempData["Erro"] = "Produto Indisponível";

            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }
    }
}
