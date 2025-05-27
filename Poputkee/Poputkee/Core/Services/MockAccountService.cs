using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System;

namespace Poputkee.Core.Services
{
    public class MockAccountService : IAccountService
    {
        private Account _currentAccount = new()
        {
            Email = "blizu4enko.andrei@yandex.ru",
            Name = "Близученко Андрей",
            BirthDate = new DateTime(2003, 6, 5),
            Bio = "Software Developer",
        };

        public Account GetAccount() => _currentAccount;

        public void UpdateAccount(Account account)
        {
            _currentAccount = account;
        }
    }
}
