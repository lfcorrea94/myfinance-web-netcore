using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using myfinance_web_netcore_domain.Entities;
using myfinance_web_netcore_service.Interfaces;

namespace myfinance_web_netcore.Controllers
{
    [Route("PlanoConta")]
    public class PlanoContaController : Controller
    {
        private readonly IPlanoContaService _planoContaService;
        public PlanoContaController(IPlanoContaService planoContaService) 
        { 
            _planoContaService = planoContaService;
        }
        // GET: PlanoContaController
        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            List<PlanoConta> listaPlanoContas = _planoContaService.GetPlanosConta();

            List<PlanoContaModel> listaPlanoContasModel = new List<PlanoContaModel>();

            foreach (var item in listaPlanoContas)
            {
                var model = new PlanoContaModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                };

                listaPlanoContasModel.Add(model);
            }

            ViewBag.ListaPlanoConta = listaPlanoContasModel; // preenche a viewbag que será exibida na view

            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id?}")]
        public ActionResult Cadastrar(int? id)
        {
            if (id != null)
            {
                PlanoConta planoConta = _planoContaService.GetPlanoConta((int)id);

                PlanoContaModel planoContaModel = new PlanoContaModel()
                {

                    Id = planoConta.Id,
                    Descricao = planoConta.Descricao,
                    Tipo = planoConta.Tipo

                };

                return View(planoContaModel);
            }

            return View();
        }

        [HttpPost("Cadastrar")]
        [Route("Cadastrar/{id?}")]
        public ActionResult Cadastrar(PlanoContaModel model)
        {
            PlanoConta planoConta = new PlanoConta()
            {
                Id = model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo
            };

            _planoContaService.Post(planoConta);

            //return View();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id?}")]
        public ActionResult Excluir(int? id)
        {
            _planoContaService.Delete((int)id);

            return RedirectToAction("Index");
        }
       
    }
}
