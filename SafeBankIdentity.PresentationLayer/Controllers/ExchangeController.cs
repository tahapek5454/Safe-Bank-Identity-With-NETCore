using Microsoft.AspNetCore.Mvc;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.DtoLayer.Enums;

namespace SafeBankIdentity.PresentationLayer.Controllers
{
    public class ExchangeController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public ExchangeController(ICurrencyService currencyService, IConfiguration configuration)
        {
            _currencyService = currencyService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.USDtoTRY = await _currencyService.GetCurrencyValueAsync(CurrencyEnum.USD);
            ViewBag.EURtoTRY = await _currencyService.GetCurrencyValueAsync(CurrencyEnum.EUR);
            ViewBag.GBPtoTRY = await _currencyService.GetCurrencyValueAsync(CurrencyEnum.GBP);
            return View();
        }
    }
}
