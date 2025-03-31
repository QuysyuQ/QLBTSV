using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.interfaces
{
    public partial interface IAccountsBUSS
    {
        AccountsModel Getbyid(int id);
        public List<AccountsModel> GetallAccount();
        public bool Create(AccountsModel model);
        public bool Update(AccountsModel model);
        public bool Delete(int id);
    }
}
