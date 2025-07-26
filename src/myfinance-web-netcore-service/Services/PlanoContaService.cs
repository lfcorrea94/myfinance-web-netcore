
using myfinance_web_netcore_service.Interfaces;
using myfinance_web_netcore_infra;
using myfinance_web_netcore_domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace myfinance_web_netcore_service.Service
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _dbContext;

        public PlanoContaService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Post(PlanoConta model)
        {
            var dbSet = _dbContext.PlanoConta;

            if (model.Id == null)
            {
                dbSet.Add(model);
            }
            else
            {
                dbSet.Attach(model);
                _dbContext.Entry(model).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var planoConta = new PlanoConta() { Id = id};
            _dbContext.Attach(planoConta);
            _dbContext.Remove(planoConta);
            _dbContext.SaveChanges();
        } 

        public List<PlanoConta> GetPlanosConta()
        {
            var planoConta = _dbContext.PlanoConta.ToList();
            return planoConta;
        }

        public PlanoConta GetPlanoConta(int id)
        {
            return _dbContext.PlanoConta.Where(x => x.Id == id).FirstOrDefault();
        }
  
    }
}