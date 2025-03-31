using BussinessLayer.Interface;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_QLBTSV.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountServiceController : ControllerBase
    {
        private IAccountServiceRepository _accountService;

        public AccountServiceController(IAccountServiceRepository accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] AccountServiceModel account)
        {
            bool isRegistered = _accountService.Register(account.Email, account.Password, account.Roll);
            if (!isRegistered)
            {
                return BadRequest("Email da ton tai");
            }
            return Ok("Dang ki thanh cong");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AccountServiceModel account)
        {
            var user = _accountService.Authenticate(account.Email, account.Password);
            if (user == null)
            {
                return Unauthorized("Password khong dung");
            }
            return Ok(new { message = "login false", user });
        }
    }

}
