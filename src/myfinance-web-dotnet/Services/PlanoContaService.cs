
using myfinance_web_dotnet.Domains;
using myfinance_web_dotnet.Infrastructures;

namespace myfinance_web_dotnet.Services
{
  public class PlanoContaService : IPlanoContaService
  {
    private readonly MyFinanceDbContext _myFinanceDbContext;

    public PlanoContaService(MyFinanceDbContext myFinanceDbContext)
    {
      _myFinanceDbContext = myFinanceDbContext;
    }
    public IEnumerable<PlanoConta> ListarPlanoContas()
    {
      return _myFinanceDbContext.PlanoConta.ToList();
    }
  }
}