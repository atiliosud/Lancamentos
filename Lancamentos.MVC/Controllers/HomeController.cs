using Lancamentos.Business.Contracts.Services;
using Lancamentos.MVC.Helpers;
using Lancamentos.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lancamentos.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICaixaService _caixaService;

        public HomeController(
            ILogger<HomeController> logger,
            ICaixaService caixaService
            )
        {
            _logger = logger;
            _caixaService = caixaService;
        }

        public IActionResult Index()
        {

            var hoje = DateTimeOffset.Now;
            var caixa = _caixaService.PegarCaixaPorDia(hoje, User.GetUserId());
            var vm = HomeVM.MapperToVM(caixa);
            return View(vm);
        }
        public IActionResult Diario(string dia)
        {
            var data = DateTimeOffset.Parse(dia);
            var caixa = _caixaService.PegarFluxoCaixaPorDia(data, User.GetUserId());

            var viewModel = FluxoCaixaVM.MapperToVM(caixa);
            return View(viewModel);
        }



        public IActionResult Lancar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Lancar(LancamentoNovoVM lacamento)
        {

            if (ModelState.IsValid)
            {
                var lancamentoDomain = lacamento.MapperToModel();
                lancamentoDomain.Instante = DateTimeOffset.Now;
                _caixaService.InserirLancamento(lancamentoDomain, User.GetUserId());
                return RedirectToAction(nameof(Index));
            }

            return View(lacamento);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}