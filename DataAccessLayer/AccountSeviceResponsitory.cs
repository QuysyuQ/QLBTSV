using DataAccessLayer.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccountSeviceResponsitory : IAccountServiceRepository
    {
        private readonly AppDbContext _context;

        public AccountSeviceResponsitory(AppDbContext context)
        {
            _context = context;
        }

        public AccountServiceModel GetByEmail(string email)
        {
            return _context.Accounts.FirstOrDefault(a => a.Email == email);
        }

        public void Add(AccountServiceModel account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }

}
