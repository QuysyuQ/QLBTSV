using BussinessLayer.interfaces;
using DataAccessLayer.interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public partial class AccountsBUS : IAccountsBUSS
    {
        public IAccountsResponsitory _res;

        public AccountsBUS(IAccountsResponsitory res)
        {
            _res = res;
        }

        public AccountsModel Getbyid(int id)
        {
            return _res.Getbyid(id);
        }
        public List<AccountsModel> GetallAccount()
        {
            return _res.GetallAccount();
        }
        public bool Create(AccountsModel model)
        {
            return _res.Create(model);
        }
        public bool Update(AccountsModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
    }
}
