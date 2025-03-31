using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
    public interface IAccountServiceBUSS
    {
        bool Register(string email, string password, string roll);
        AccountServiceModel Authenticate(string email, string password);
    }

}
