using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using myfinance_web_netcore_domain.Entities;
using myfinance_web_netcore_service.Interfaces;

namespace myfinance_web_netcore.Controllers
{
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

        // GET: PlanoContaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlanoContaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanoContaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlanoContaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanoContaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlanoContaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanoContaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
