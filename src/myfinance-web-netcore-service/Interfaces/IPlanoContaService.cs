
using myfinance_web_netcore_domain.Entities;

namespace myfinance_web_netcore_service.Interfaces
{
    public interface IPlanoContaService
    {
        void Put(PlanoConta model);
        void Delete(int Id);
        List<PlanoConta> GetPlanosConta();
        PlanoConta GetPlanoConta(int Id);
    }
}