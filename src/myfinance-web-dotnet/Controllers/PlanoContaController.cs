using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers;

[Route("[controller]")]
public class PlanoContaController : Controller
{
  private readonly ILogger<PlanoContaController> _logger;
  private readonly IMapper _mapper;
  private readonly IPlanoContaService _planoContaService;

  public PlanoContaController(ILogger<PlanoContaController> logger, IPlanoContaService planoContaService, IMapper mapper)
  {
    _logger = logger;
    _mapper = mapper;
    _planoContaService = planoContaService;
  }

  [HttpGet]
  [Route("Index")]
  public IActionResult Index()
  {
    var list = _planoContaService.ListarPlanoContas().Select(_mapper.Map<PlanoContaModel>);
    var listPlanoContasMapped = _mapper.Map<IEnumerable<PlanoContaModel>>(list);
    ViewBag.ListaPlanoContas = listPlanoContasMapped;
    return View();
  }

  [HttpGet]
  [Route("Cadastro")]
  [Route("Cadastro/{id}")]
  public IActionResult Cadastro(int? id)
  {
    if (id != null)
    {
      var registro = _planoContaService.RetornarRegistro((int)id);
      return View(registro);
    }

    return View();
  }

  [HttpPost]
  [Route("Cadastro")]
  [Route("Cadastro/{id}")]
  public IActionResult Cadastro(PlanoContaModel model)
  {
    _planoContaService.Salvar(model);
    return RedirectToAction("Index");
  }

  [HttpGet]
  [Route("Excluir/{id}")]
  public IActionResult Excluir(int? id)
  {

    _planoContaService.Excluir(id);
    return RedirectToAction("Index");
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
