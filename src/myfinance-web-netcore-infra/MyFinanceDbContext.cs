using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore_domain.Entities;

namespace myfinance_web_netcore_infra;

public class MyFinanceDbContext : DbContext
{
    public DbSet<PlanoConta> DbSetPlanoConta { get; set; }
    public DbSet<Transacao> DbSetTransacao { get; set; }    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESSD;Database=myFinance;Trusted_Connection=True;");
    }
}
