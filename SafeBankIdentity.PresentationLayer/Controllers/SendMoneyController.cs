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

            
            return View(new SendMoneyForCustomerAccountProcessDto());
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {

            bool success = await _moneyTransferService.SendMoneyToAccoutAsync(sendMoneyForCustomerAccountProcessDto, User.Identity.Name, TempData["mycurrency"].ToString());
            sendMoneyForCustomerAccountProcessDto.Success = success;
            if(!success)
                return View(sendMoneyForCustomerAccountProcessDto);
            return RedirectToAction("Index", "Deneme");
        }
    }
}
