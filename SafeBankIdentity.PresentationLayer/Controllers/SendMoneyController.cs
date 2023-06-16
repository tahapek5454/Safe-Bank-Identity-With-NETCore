using Microsoft.AspNetCore.Mvc;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.DtoLayer.Dtos.CustomerAccountProcessDtos;

namespace SafeBankIdentity.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {

        private readonly IMoneyTransferService _moneyTransferService;

        public SendMoneyController(IMoneyTransferService moneyTransferService)
        {
            _moneyTransferService = moneyTransferService;
        }

        [HttpGet]
        public IActionResult Index(string mycurrency)
        {
            ViewBag.currency = mycurrency;
            TempData["mycurrency"] = mycurrency;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {

            await _moneyTransferService.SendMoneyToAccoutAsync(sendMoneyForCustomerAccountProcessDto, User.Identity.Name, TempData["mycurrency"].ToString());

            return RedirectToAction("Index", "Deneme");
        }
    }
}
