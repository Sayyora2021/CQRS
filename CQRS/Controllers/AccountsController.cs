using Microsoft.AspNetCore.Mvc;
using CQRS.UseCases.Accounts.Login;
using CQRS.UseCases.Accounts.Register;
using MediatR;
using System.Threading.Tasks;

namespace CQRS.Controllers
{
    public class AccountsController : Controller
    {
        private IMediator Mediator { get; }
        public AccountsController(IMediator mediator)
        {
            Mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Login(LoginQuery query)
        {
            if (!ModelState.IsValid)
            {
                var account = await Mediator.Send(query);
                if(account != null)
                {
                    return RedirectToAction("Index", "Home", new {id = account.Email});
                }
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            if (!ModelState.IsValid)
            {
                 await Mediator.Send(command);
                return RedirectToAction(nameof(Login));
                
            }
            return View(command);
        }
    }
}
