using Poputkee.Core.Models;

namespace Poputkee.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Trip> Trips { get; }
        IRepository<Booking> Bookings { get; }
        Task<int> CommitAsync();
    }
}