
using myfinance_web_netcore_service.Interfaces;
using myfinance_web_netcore_infra;
using myfinance_web_netcore_domain.Entities;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore_infra.Interfaces;

namespace myfinance_web_netcore_service.Service
{
    public class PlanoContaService : IPlanoContaService
    {
        protected IPlanoContaRepository _planoContaRepository;
        public PlanoContaService(IPlanoContaRepository planoContaRepository) 
        {
            _planoContaRepository = planoContaRepository;
        }
        public void Delete(int Id)
        {
            _planoContaRepository.Delete(Id);
        }

        public List<PlanoConta> Get()
        {
            return _planoContaRepository.Get();
        }

        public PlanoConta Get(int Id)
        {
            return _planoContaRepository.Get(Id);
        }

        public void Post(PlanoConta entity)
        {
            _planoContaRepository.Post(entity);
        }
    }
}