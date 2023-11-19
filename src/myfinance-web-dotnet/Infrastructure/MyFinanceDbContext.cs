using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domains;


namespace myfinance_web_dotnet.Infrastructures
{
  public class MyFinanceDbContext : DbContext
  {
    public DbSet<PlanoConta> PlanoConta { get; set; }
    public DbSet<Transacao> Transacao { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string connectionString = @"Server=localhost\SQLEXPRESS;Database=myfinanceweb;Trusted_Connection=True;TrustServerCertificate=True";
      optionsBuilder.UseSqlServer(connectionString);
      base.OnConfiguring(optionsBuilder);
    }
  }
}