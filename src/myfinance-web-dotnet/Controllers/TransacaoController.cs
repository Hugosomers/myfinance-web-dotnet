using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers;

[Route("[controller]")]
public class TransacaoController : Controller
{
  private readonly ILogger<TransacaoController> _logger;
  private readonly ITransacaoService _transacaoService;
  private readonly IPlanoContaService _planoContaService;

  public TransacaoController(ILogger<TransacaoController> logger, ITransacaoService TransacaoService, IPlanoContaService planoContaService)
  {
    _logger = logger;
    _transacaoService = TransacaoService;
    _planoContaService = planoContaService;
  }

  [HttpGet]
  [Route("Index")]
  public IActionResult Index()
  {
    var list = _transacaoService.ListarTransacoes();
    ViewBag.ListaTransacoes = list;
    return View();
  }

  [HttpGet]
  [Route("Cadastro")]
  [Route("Cadastro/{id}")]
  public IActionResult Cadastro(int? id)
  {
    var transacaoModel = new TransacaoModel();

    if (id != null)
    {
      transacaoModel = _transacaoService.RetornarRegistro((int)id);
    }

    var listaPlanoConta = _planoContaService.ListarPlanoContas();
    var planoContaItems = new SelectList(listaPlanoConta, "Id", "Descricao");
    transacaoModel.PlanoContas = planoContaItems;

    return View(transacaoModel);
  }

  [HttpPost]
  [Route("Cadastro")]
  [Route("Cadastro/{id}")]
  public IActionResult Cadastro(TransacaoModel model)
  {
    _transacaoService.Salvar(model);
    return RedirectToAction("Index");
  }

  [HttpGet]
  [Route("Excluir/{id}")]
  public IActionResult Excluir(int id)
  {

    _transacaoService.Excluir(id);
    return RedirectToAction("Index");
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
