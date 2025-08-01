using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_netcore.Models;
using myfinance_web_netcore_domain.Entities;
using myfinance_web_netcore_service.Interfaces;
using System.Drawing;

namespace myfinance_web_netcore.Controllers
{
    [Route("Transacao")]
    public class TransacaoController : Controller
    {
        private readonly ITransacaoService _transacaoService;
        private readonly IPlanoContaService _planoContaService;
        public TransacaoController(ITransacaoService transacaoService,
                IPlanoContaService planoContaService) 
        { 
            _transacaoService = transacaoService;
            _planoContaService = planoContaService;
        }
        // GET: PlanoContaController
        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            List<Transacao> transacoes = _transacaoService.GetTransacoes();

            List<TransacaoModel> transacaoModels = new List<TransacaoModel>();

            foreach (var item in transacoes)
            {
                var model = new TransacaoModel()
                {
                    Id = item.Id,
                    Historico = item.Historico,
                    Data = item.Data,
                    Valor = item.Valor,
                    PlanoContaId = item.PlanoContaId,
                    Tipo = item.PlanoConta.Tipo
                };

                transacaoModels.Add(model);
            }

            ViewBag.ListaTransacao = transacaoModels; // preenche a viewbag que será exibida na view

            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id?}")]
        public ActionResult Cadastrar(int? id)
        {
            var listaPlanoContas = new SelectList(_planoContaService.GetPlanosConta(), "Id", "Descricao");

            TransacaoModel transacaoModel = new TransacaoModel()
            {
                Data = DateTime.Now,
                ListaPlanoContas = listaPlanoContas
            };
            
            
            if (id != null)
            {
                Transacao transacao = _transacaoService.GetTransacao((int)id);

                transacaoModel.Id = transacao.Id;
                transacaoModel.Historico = transacao.Historico;
                transacaoModel.Data = transacao.Data;
                transacaoModel.Valor = transacao.Valor;
                transacaoModel.PlanoContaId = transacao.PlanoContaId;                 
            }

            return View(transacaoModel);
        }

        [HttpPost("Cadastrar")]
        [Route("Cadastrar/{id?}")]
        public ActionResult Cadastrar(TransacaoModel model)
        {
            Transacao transacao = new Transacao()
            {
                Id = model.Id,
                Historico = model.Historico,
                Data = model.Data,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId
            };

            _transacaoService.Put(transacao);

            //return View();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id?}")]
        public ActionResult Excluir(int? id)
        {
            _transacaoService.Delete((int)id);

            return RedirectToAction("Index");
        }
       
    }
}
