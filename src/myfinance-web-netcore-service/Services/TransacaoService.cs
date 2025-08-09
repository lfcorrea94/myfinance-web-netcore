using myfinance_web_netcore_service.Interfaces;
using myfinance_web_netcore_infra;
using myfinance_web_netcore_domain.Entities;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore_infra.Interfaces;

namespace myfinance_web_netcore_service.Service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _dbContext;
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoService(MyFinanceDbContext dbContext,
            ITransacaoRepository transacaoRepository)
        {
            _dbContext = dbContext;
            _transacaoRepository = transacaoRepository;
        }

        public void Post(Transacao model)
        {
            _transacaoRepository.Post(model);
        }

        public void Delete(int id)
        {
            _transacaoRepository.Delete(id);
        } 

        public List<Transacao> Get()
        {
           
            return _transacaoRepository.Get();
        }

        public Transacao Get(int id)
        {
            return _transacaoRepository.Get(id);
        }
    }
}