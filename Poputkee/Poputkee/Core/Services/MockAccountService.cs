using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poputkee.Core.Services
{
    public class MockAccountService : IAccountService
    {
        private Account _currentAccount = new Account
        {
            Email = "user@example.com",
            Name = "John Doe",
            BirthDate = new DateTime(1990, 1, 1),
            Bio = "Software Developer",
        };

        public Account GetAccount() => _currentAccount;

        public void UpdateAccount(Account account)
        {
            _currentAccount = account;
        }
    }
}
