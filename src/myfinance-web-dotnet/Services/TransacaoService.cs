using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domains;
using myfinance_web_dotnet.Infrastructures;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Services
{
  public class TransacaoService : ITransacaoService
  {
    private readonly MyFinanceDbContext _myFinanceDbContext;
    private readonly IMapper _mapper;

    public TransacaoService(MyFinanceDbContext myFinanceDbContext, IMapper mapper)
    {
      _myFinanceDbContext = myFinanceDbContext;
      _mapper = mapper;
    }

    public void Excluir(int id)
    {
      var transacao = _myFinanceDbContext.Transacao.Where(transacao => transacao.Id == id).First();
      _myFinanceDbContext.Transacao.Attach(transacao);
      _myFinanceDbContext.Transacao.Remove(transacao);
      _myFinanceDbContext.SaveChanges();

    }

    public IEnumerable<TransacaoModel> ListarTransacoes()
    {
      var list = _myFinanceDbContext.Transacao.ToList();
      var listTransacaoMapped = _mapper.Map<IEnumerable<TransacaoModel>>(list);
      return listTransacaoMapped;
    }

    public TransacaoModel RetornarRegistro(int id)
    {
      var transacao = _myFinanceDbContext.Transacao.Where(transacaso => transacaso.Id == id).First();
      var transacaoMapped = _mapper.Map<TransacaoModel>(transacao);
      return transacaoMapped;
    }

    public void Salvar(TransacaoModel model)
    {
      var transacaoEntity = new Transacao()
      {
        Id = model.Id,
        Historico = model.Historico,
        Data = model.Data,
        Valor = model.Valor,
        PlanoContaId = model.PlanoContaId,
        Tipo = model.Tipo,
      };

      if (transacaoEntity.Id == null)
      {
        _myFinanceDbContext.Transacao.Add(transacaoEntity);
      }
      else
      {
        _myFinanceDbContext.Transacao.Attach(transacaoEntity);
        _myFinanceDbContext.Entry(transacaoEntity).State = EntityState.Modified;
      }

      _myFinanceDbContext.SaveChanges();
    }
  }
}