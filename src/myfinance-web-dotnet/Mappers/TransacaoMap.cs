using AutoMapper;
using myfinance_web_dotnet.Domains;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Mappers
{
  public class TransacaoMap : Profile
  {
    public TransacaoMap()
    {
      CreateMap<Transacao, TransacaoModel>().ReverseMap();
    }
  }
}