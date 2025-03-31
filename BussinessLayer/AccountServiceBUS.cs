using BussinessLayer.Interface;
using DataAccessLayer.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class AccountServiceBUS : IAccountServiceBUSS
    {
        private readonly IAccountServiceRepository _accountServiceRepository;

        public AccountServiceBUS(IAccountServiceRepository serviceRepository)
        {
            _accountServiceRepository = serviceRepository;
        }

        public bool Register(string email, string password, string roll)
        {
            if (_accountServiceRepository.GetByEmail(email) != null)
            {
                return false; // Email đã tồn tại
            }

            var newAccount = new AccountModel
            {
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password), // Hash mật khẩu
                Roll = roll,
                DateCreate = DateTime.Now
            };

            _accountServiceRepository.Add(newAccount);
            return true;
        }

        public Account Authenticate(string email, string password)
        {
            var account = _accountServiceRepository.GetByEmail(email);
            if (account == null || !BCrypt.Net.BCrypt.Verify(password, account.Password))
            {
                return null;
            }
            return account;
        }
    }

}
