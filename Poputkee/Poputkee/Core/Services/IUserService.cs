// Poputkee.Core/Services/IUserService.cs
using Poputkee.Core.Models;

public interface IUserService
{
    User CurrentUser { get; set; }
}

// Poputkee.Infrastructure/Services/UserService.cs
public class UserService : IUserService
{
    public User CurrentUser { get; set; }
}