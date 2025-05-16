using Poputkee.Core.Models;
using System;
using System.Collections.Generic;

public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}