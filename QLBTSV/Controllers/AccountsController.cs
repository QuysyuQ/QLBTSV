using DataAccessLayer;
using DataAccessLayer.interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace QLBTSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private IAccountsResponsitory _accountBUS;

        public AccountsController(IAccountsResponsitory Account)
        {
            _accountBUS = Account;
        }

        [Route("getbyid_account/{id}")]
        [HttpGet]
        public AccountsModel GetByID(int id)
        {
            return _accountBUS.Getbyid(id);
        }

        [Route("get_all_account")]
        [HttpGet]
        public IEnumerable<AccountsModel> GetallAccountModel()
        {
            return _accountBUS.GetallAccount();
        }

        [Route("sp_create_account")]
        [HttpPost]
        public bool Create(AccountsModel model)
        {
            return _accountBUS.Create(model);
        }

        [Route("sp_update_account")]
        [HttpPut]
        public bool Update(AccountsModel model)
        {
            return _accountBUS.Update(model);
        }

        [Route("sp_delete_account/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return _accountBUS.Delete(id);
        }
    }
}
