using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore_domain.Entities;
using myfinance_web_netcore_infra.Interfaces;

namespace myfinance_web_netcore_infra.Repositories
{
    public class PlanoContaRepository : Repository<PlanoConta>, IPlanoContaRepository
    {
        public PlanoContaRepository(MyFinanceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
