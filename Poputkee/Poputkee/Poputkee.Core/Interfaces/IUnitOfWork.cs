using Poputkee.Poputkee.Core.Models;

namespace Poputkee.Poputkee.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Trip> Trips { get; }
        IRepository<Booking> Bookings { get; }
        Task<int> CommitAsync();
    }
}