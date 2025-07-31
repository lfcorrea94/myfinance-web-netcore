using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public TransacaoController(ITransacaoService transacaoService) 
        { 
            _transacaoService = transacaoService;
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
                    Tipo = item.PlanoConta.Tipo,
                    PlanoConta = item.PlanoConta
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
            if (id != null)
            {
                Transacao transacao = _transacaoService.GetTransacao((int)id);

                TransacaoModel transacaoModel = new TransacaoModel()
                {
                    Id = transacao.Id,
                    Historico = transacao.Historico,
                    Data = transacao.Data,
                    Valor = transacao.Valor,
                    PlanoContaId = transacao.PlanoContaId,
                    PlanoConta = transacao.PlanoConta

                };

                return View(transacaoModel);
            }

            return View();
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
                PlanoContaId = model.PlanoContaId,
                PlanoConta = model.PlanoConta

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
