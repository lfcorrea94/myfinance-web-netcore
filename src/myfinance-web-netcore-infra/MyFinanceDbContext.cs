﻿using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore_domain.Entities;

namespace myfinance_web_netcore_infra;

public class MyFinanceDbContext : DbContext
{
    public DbSet<PlanoConta> PlanoConta { get; set; }
    public DbSet<Transacao> Transacao { get; set; }    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=myFinance;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False;");
    }
}
