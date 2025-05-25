using Poputkee.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poputkee.Core.Interfaces
{
    public interface IAccountService
    {
        Account GetAccount();
        void UpdateAccount(Account account);
    }
}
