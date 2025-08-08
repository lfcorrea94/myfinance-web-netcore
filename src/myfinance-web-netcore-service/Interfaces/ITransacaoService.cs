
using myfinance_web_netcore_domain.Entities;

namespace myfinance_web_netcore_service.Interfaces
{
    public interface ITransacaoService
    {
        void Post(Transacao model);
        void Delete(int Id);
        List<Transacao> Get();
        Transacao Get(int Id);
    }
}