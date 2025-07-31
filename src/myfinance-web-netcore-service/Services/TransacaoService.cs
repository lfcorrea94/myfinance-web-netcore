using myfinance_web_netcore_service.Interfaces;
using myfinance_web_netcore_infra;
using myfinance_web_netcore_domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace myfinance_web_netcore_service.Service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _dbContext;

        public TransacaoService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Put(Transacao model)
        {
            var dbSet = _dbContext.Transacao;

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
            var transacao = new Transacao() { Id = id};
            _dbContext.Attach(transacao);
            _dbContext.Remove(transacao);
            _dbContext.SaveChanges();
        } 

        public List<Transacao> GetTransacoes()
        {
            var transacao = _dbContext.Transacao.Include(x => x.PlanoConta);
            return transacao.ToList();
        }

        public Transacao GetTransacao(int id)
        {
            return _dbContext.Transacao.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}