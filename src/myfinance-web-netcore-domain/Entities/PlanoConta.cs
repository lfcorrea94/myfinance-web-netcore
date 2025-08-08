using myfinance_web_netcore_domain.Entities.Base;

namespace myfinance_web_netcore_domain.Entities
{
    public class PlanoConta : EntityBase
    {
        public string Descricao { get; set; }
        public string Tipo { get; set; }
    }

}
