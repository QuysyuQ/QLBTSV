using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IAccountServiceRepository
    {
        AccountServiceModel GetByEmail(string email);
        void Add(AccountServiceModel account);
    }

}
