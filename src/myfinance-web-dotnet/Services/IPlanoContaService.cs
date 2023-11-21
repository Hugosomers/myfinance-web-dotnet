using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Services
{
  public interface IPlanoContaService
  {
    IEnumerable<PlanoContaModel> ListarPlanoContas();
    void Salvar(PlanoContaModel model);
    PlanoContaModel RetornarRegistro(int id);
    void Excluir(int id);
  }
}