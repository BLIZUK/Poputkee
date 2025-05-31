// Poputkee.Core/Interfaces/IAuthService.cs
using Poputkee.Core.Models;
using System.Threading.Tasks;

namespace Poputkee.Core.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(string name, string email, string password);
        Task<User> LoginAsync(string email, string password);
        void Logout();
        User CurrentUser { get; }
        bool IsAuthenticated { get; }
    }
}