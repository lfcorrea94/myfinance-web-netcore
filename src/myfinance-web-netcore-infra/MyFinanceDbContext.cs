using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using myfinance_web_netcore_domain.Entities;

namespace myfinance_web_netcore_infra;

public class MyFinanceDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<PlanoConta> PlanoConta { get; set; }
    public DbSet<Transacao> Transacao { get; set; }

    public MyFinanceDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("Database");
        
        optionsBuilder.UseSqlServer(connectionString);
        //optionsBuilder.UseSqlServer(@"Server=myfinancewebsqlserver.database.windows.net;Database=myfinance;User Id=user;Password=@Tubarao9;");
    }
}
