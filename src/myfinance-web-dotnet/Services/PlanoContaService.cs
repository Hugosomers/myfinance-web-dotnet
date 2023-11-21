using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domains;
using myfinance_web_dotnet.Infrastructures;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Services
{
  public class PlanoContaService : IPlanoContaService
  {
    private readonly MyFinanceDbContext _myFinanceDbContext;
    private readonly IMapper _mapper;

    public PlanoContaService(MyFinanceDbContext myFinanceDbContext, IMapper mapper)
    {
      _myFinanceDbContext = myFinanceDbContext;
      _mapper = mapper;
    }

    public void Excluir(int id)
    {
      var planoConta = _myFinanceDbContext.PlanoConta.Where(planoConta => planoConta.Id == id).First();
      _myFinanceDbContext.PlanoConta.Attach(planoConta);
      _myFinanceDbContext.PlanoConta.Remove(planoConta);
      _myFinanceDbContext.SaveChanges();

    }

    public IEnumerable<PlanoContaModel> ListarPlanoContas()
    {
      var list = _myFinanceDbContext.PlanoConta.ToList();
      var listPlanoContasMapped = _mapper.Map<IEnumerable<PlanoContaModel>>(list);
      return listPlanoContasMapped;
    }

    public PlanoContaModel RetornarRegistro(int id)
    {
      var planoConta = _myFinanceDbContext.PlanoConta.Where(planoConta => planoConta.Id == id).First();
      var planoContaMapped = _mapper.Map<PlanoContaModel>(planoConta);
      return planoContaMapped;
    }

    public void Salvar(PlanoContaModel model)
    {
      var planoContaEntity = new PlanoConta()
      {
        Id = model.Id,
        Descricao = model.Descricao,
        Tipo = model.Tipo,
      };

      if (planoContaEntity.Id == null)
      {
        _myFinanceDbContext.PlanoConta.Add(planoContaEntity);
      }
      else
      {
        _myFinanceDbContext.PlanoConta.Attach(planoContaEntity);
        _myFinanceDbContext.Entry(planoContaEntity).State = EntityState.Modified;
      }

      _myFinanceDbContext.SaveChanges();
    }
  }
}