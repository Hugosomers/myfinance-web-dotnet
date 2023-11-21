using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Services
{
  public interface ITransacaoService
  {
    IEnumerable<TransacaoModel> ListarTransacoes();
    void Salvar(TransacaoModel model);
    TransacaoModel RetornarRegistro(int id);
    void Excluir(int id);
  }
}