using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Requests;

namespace TaskManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //c# 9. record
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await this.mediator.Send(request);
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return View();
        }
    }
}
