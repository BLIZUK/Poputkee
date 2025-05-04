public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Users = new Repository<User>(context);
        Trips = new Repository<Trip>(context);
        Bookings = new Repository<Booking>(context);
    }

    public IRepository<User> Users { get; }
    public IRepository<Trip> Trips { get; }
    public IRepository<Booking> Bookings { get; }

    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}