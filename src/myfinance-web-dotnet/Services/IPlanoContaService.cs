using myfinance_web_dotnet.Domains;

namespace myfinance_web_dotnet.Services
{
  public interface IPlanoContaService
  {
    IEnumerable<PlanoConta> ListarPlanoContas();
  }
}