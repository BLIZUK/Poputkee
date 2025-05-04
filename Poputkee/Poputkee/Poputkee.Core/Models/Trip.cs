public class Trip
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public string DriverName { get; set; }
    public string FromCity { get; set; }
    public string ToCity { get; set; }
    public DateTime DepartureTime { get; set; }
    public int AvailableSeats { get; set; }
    public List<string> Passengers { get; } = new List<string>();
}