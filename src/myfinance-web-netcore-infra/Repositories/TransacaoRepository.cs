using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore_domain.Entities;
using myfinance_web_netcore_infra.Interfaces;

namespace myfinance_web_netcore_infra.Repositories
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        protected readonly MyFinanceDbContext _dbContext;
        public TransacaoRepository(MyFinanceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Transacao> Get()
        {
            var transacao = _dbContext.Transacao.Include(x => x.PlanoConta);
            return transacao.ToList();
        }
    }
}
