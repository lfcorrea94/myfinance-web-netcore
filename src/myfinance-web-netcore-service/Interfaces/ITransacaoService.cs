
using myfinance_web_netcore_domain.Entities;

namespace myfinance_web_netcore_service.Interfaces
{
    public interface ITransacaoService
    {
        void Put(Transacao model);
        void Delete(int Id);
        List<Transacao> GetTransacoes();
        Transacao GetTransacao(int Id);
    }
}