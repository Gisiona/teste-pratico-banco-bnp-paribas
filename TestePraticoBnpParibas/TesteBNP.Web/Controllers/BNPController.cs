using System;
using System.Web.Mvc;
using TesteBNP.Dominio.Entidades;
using TesteBNP.Negocio;
using TesteBNP.Web.Models;

namespace TesteBNP.Web.Controllers
{
    public class BNPController : Controller
    {
        private ProdutoNegocio _produtoNegocio;
        public ProdutoCosifNegocio _produtoCosifNegocio;

        private MovimentoManualNegocio _movimentoManualNegocio;

        public BNPController()
        {
            _produtoNegocio = new ProdutoNegocio();
            _movimentoManualNegocio = new MovimentoManualNegocio();
            _produtoCosifNegocio = new ProdutoCosifNegocio();
        }

        // GET: BNP
        public ActionResult Index()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                @ViewBag.erro = ex.Message;
            }
            return View();
        }

        #region Movimento CadastrarMovimento E ConsultarMovimento
        public ActionResult CadastrarMovimento()
        {
            try
            {               
                return View(ConsultarMovimentoManualViewModel());
            }
            catch (Exception ex)
            {
                @ViewBag.erro = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarMovimento(int? mes, int? ano, string codCosif, string codProduto, decimal? valor, string descricao)
        {
            try
            {
                _movimentoManualNegocio.Cadastrar(new MovimentoManual { MesMovimento = mes, AnoMovimento = ano, CodigoCosif = codCosif, CodigoProduto = codProduto, ValorMovimento = valor, DescricaoMovimento = descricao });
                return View(ConsultarMovimentoManualViewModel());
            }
            catch (Exception ex)
            {
                @ViewBag.erro = ex.Message;
            }
            return View();
        }

        private MovimentoManualViewModel ConsultarMovimentoManualViewModel()
        {
            try
            {
                MovimentoManualViewModel vm = new MovimentoManualViewModel()
                {
                    ProdutoCosifLista = _produtoCosifNegocio.ConsultarTodos(),
                    ProdutoLista = _produtoNegocio.ConsultarTodos(),
                    MovimentoManualLista = _movimentoManualNegocio.ConsultarTodos()
                };
                return vm;
            }
            catch (Exception ex)
            {
                @ViewBag.erro = ex.Message;
            }
            return null;
        }

        public ActionResult ConsultarMovimento()
        {
            try
            {
                return View(ConsultarMovimentoManualViewModel());
            }
            catch (Exception ex)
            {
                @ViewBag.erro = ex.Message;
            }
            return View();
        }

        #endregion

        public ActionResult ConsultarProduto()
        {
            try
            {
                ProdutoViewModel vm = new ProdutoViewModel()
                {
                    ProdutoLista = _produtoNegocio.ConsultarTodos()
                };
                return View(vm);
            }
            catch (Exception ex)
            {
                @ViewBag.erro = ex.Message;
            }
            return View();
        }
    }
}