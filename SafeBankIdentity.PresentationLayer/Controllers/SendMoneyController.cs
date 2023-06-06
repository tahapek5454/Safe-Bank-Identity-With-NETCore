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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {

            await _moneyTransferService.SendMoneyToAccoutAsync(sendMoneyForCustomerAccountProcessDto, User.Identity.Name);

            return RedirectToAction("Index", "Deneme");
        }
    }
}
